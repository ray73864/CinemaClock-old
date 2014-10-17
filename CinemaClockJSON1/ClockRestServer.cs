using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using Grapevine;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace CinemaClockJSON
{
    public class Profile
    {
        private String _profileName;

        public String profileName { set { this._profileName = value; } get { return this._profileName; } }
    }

    public class ClockRestServer : RestServer
    {
        private ClockDisplay _myClockDisplay;

        public ClockDisplay myClockDisplay { set { this._myClockDisplay = value; } get { return this._myClockDisplay; } }

        public string RepairJson(string json)
        {
            JObject jsonObject = JObject.Parse(json);

            try
            {
                if (jsonObject["TopFontSizeOverride"].ToString() == "") { jsonObject["TopFontSizeOverride"] = false; }
            }
            catch (NullReferenceException nre) { jsonObject.Add("TopFontSizeOverride", false); }

            try
            {
                if (jsonObject["BottomFontSizeOverride"].ToString() == "") { jsonObject["BottomFontSizeOverride"] = false; }
            }
            catch (NullReferenceException nre) { jsonObject.Add("bottomFontSizeOverride", false); }

            json = jsonObject.ToString(Newtonsoft.Json.Formatting.None, null);

            return json;
        }

        [RestRoute(Method = HttpMethod.POST, PathInfo = @"^/saveprofile$")]
        public void HandleSaveProfile(HttpListenerContext context)
        {
            String json = null;
            ClockSettings myNewClockSettings = new ClockSettings();
            HttpListenerRequest request = context.Request;

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, Accept");

            try
            {
                using (var reader = new StreamReader(request.InputStream))
                {
                    json = reader.ReadToEnd();
                }
           }
            catch { }
            finally
            {
                json = json.Replace("\"on\"", "\"true\"").Replace("\"off\"", "\"false\"");

                json = RepairJson(json);

                myNewClockSettings = JsonConvert.DeserializeObject<ClockSettings>(json);
                File.WriteAllText(@"profiles\" + myNewClockSettings.ProfileName + ".json", JsonConvert.SerializeObject(myNewClockSettings, Formatting.Indented));

                _myClockDisplay.cps.Profiles.Add(new ClockProfiles(myNewClockSettings.ProfileName, myNewClockSettings));

                _myClockDisplay.clockSettingsBindingSource.Clear();
                _myClockDisplay.clockSettingsBindingSource.Add(myNewClockSettings);
                _myClockDisplay.settings = myNewClockSettings;
            }

            this.SendTextResponse(context, JsonConvert.SerializeObject(myNewClockSettings));
        }

        [RestRoute(Method = HttpMethod.POST, PathInfo = @"^/updateprofile$")]
        public void HandleUpdateProfile(HttpListenerContext context)
        {
            String json = null;
            ClockSettings myNewClockSettings = new ClockSettings();
            HttpListenerRequest request = context.Request;

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, Accept");

            try
            {
                using (var reader = new StreamReader(request.InputStream))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch { }
            finally
            {
                json = json.Replace("\"on\"", "\"true\"").Replace("\"off\"", "\"false\"");

                json = RepairJson(json);

                myNewClockSettings = JsonConvert.DeserializeObject<ClockSettings>(json);

                ClockProfiles response = _myClockDisplay.cps.Profiles.Find(r => r.ProfileName == myNewClockSettings.ProfileName);

                response.ProfileSettings = JsonConvert.DeserializeObject<ClockSettings>(json);

                File.WriteAllText(@"profiles\" + myNewClockSettings.ProfileName + ".json", JsonConvert.SerializeObject(myNewClockSettings, Formatting.Indented));

                if (response.ProfileSettings.ProfileName == _myClockDisplay.cps.LoadedProfile.ProfileName)
                {
                    _myClockDisplay.cps.LoadedProfile = myNewClockSettings;
                    _myClockDisplay.clockSettingsBindingSource.Clear();
                    _myClockDisplay.clockSettingsBindingSource.Add(myNewClockSettings);
                    _myClockDisplay.settings = myNewClockSettings;
                }
            }

            this.SendTextResponse(context, JsonConvert.SerializeObject(myNewClockSettings));
        }

        [RestRoute(Method = HttpMethod.POST, PathInfo = @"^/updateappconfig")]
        public void HandleUpdateConfig(HttpListenerContext context)
        {
            string json = null;
            ClockAppConfig clockAppConfig = new ClockAppConfig();
            HttpListenerRequest request = context.Request;

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, Accept");

            try 
            {
                using (var reader = new StreamReader(request.InputStream))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch { }
            finally
            {
                json = json.Replace("\"on\"", "\"true\"").Replace("\"off\"", "\"false\"");

                clockAppConfig = JsonConvert.DeserializeObject<ClockAppConfig>(json);

                File.WriteAllText(_myClockDisplay.clockAppConfig.getProgramPath() + "\\clockconfig.json", json);

                _myClockDisplay.clockAppConfig = clockAppConfig;
            }

            this.SendTextResponse(context, JsonConvert.SerializeObject(clockAppConfig));
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/testsave$")]
        public void HandleTestSave(HttpListenerContext context)
        {
            WebClient web = new WebClient();

            ClockSettings testClock = new ClockSettings();
            testClock.ProfileName = "REST Test 1";

            web.UploadString("http://localhost:1234/saveprofile", "POST", JsonConvert.SerializeObject(testClock));

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, "Test Comlete!");            
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/currentprofile$")]
        public void HandleCurrentProfile(HttpListenerContext context)
        {
            String currentProfile = JsonConvert.SerializeObject(_myClockDisplay.cps.LoadedProfile);

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, currentProfile);
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/currentprofilename$")]
        public void HandleCurrentProfileName(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, _myClockDisplay.cps.LoadedProfile.ProfileName);
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/profileexists(.*)?$")]
        public void HandleProfileExists(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var profileName = context.Request.QueryString["profile"];

            if (profileName == "")
            {
                context.Response.StatusCode = 404;
                this.SendTextResponse(context, "No Profile specified!");
            }
            else
            {
                var profileFilename = @"profiles\" + profileName + ".json";

                if (File.Exists(profileFilename))
                {
                    context.Response.StatusCode = 200;
                    this.SendTextResponse(context, "Profile Exists");
                }
                else
                {
                    context.Response.StatusCode = 404;
                    this.SendTextResponse(context, "Profile does not exist!");
                }
            }
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/getprofilestate(.*)?$")]
        public void HandleGetProfileState(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, JsonConvert.SerializeObject(_myClockDisplay.cps));
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/loadprofile(.*)?$")]
        public void HandleLoadProfile(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var profileName = context.Request.QueryString["profile"];

            ClockProfiles response = _myClockDisplay.cps.Profiles.Find(r => r.ProfileName == profileName);

            _myClockDisplay.cps.LoadedProfile = response.ProfileSettings;

            _myClockDisplay.clockSettingsBindingSource.Clear();
            _myClockDisplay.clockSettingsBindingSource.Add(_myClockDisplay.cps.LoadedProfile);
            _myClockDisplay.settings = _myClockDisplay.cps.LoadedProfile;

            this.SendTextResponse(context, "Profile loaded!");
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/getprofile(.*)?$")]
        public void HandleGetProfile(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            String clockJson = null;
            var profileName = context.Request.QueryString["profile"];

            if (profileName == "")
            {
                context.Response.StatusCode = 404;
                this.SendTextResponse(context, "No Profile specified!");
            }
            else
            {
                try
                {
                    clockJson = File.ReadAllText(@"profiles\" + profileName + ".json");
                    context.Response.StatusCode = 200;
                    this.SendTextResponse(context, clockJson);
                }
                catch
                {
                    context.Response.StatusCode = 404;
                    this.SendTextResponse(context, "Profile not found!");
                }
            }
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/getappconfig$")]
        public void HandleGetAppConfig(HttpListenerContext context)
        {
            string appConfig = JsonConvert.SerializeObject(_myClockDisplay.clockAppConfig);

            var sourceDomain = context.Request.Headers["Origin"];
            context.Response.AppendHeader("Access-Control-Allow-Origin", sourceDomain);
            this.SendTextResponse(context, appConfig);
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/getpresentations$")]
        public void HandleGetPresentations(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, String.Join(",", _myClockDisplay.settings.Presentations));
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/profiles(.*)?$")]
        public void HandleProfilesList(HttpListenerContext context)
        {
            string json = JsonConvert.SerializeObject(_myClockDisplay.cps.Profiles, Formatting.Indented);

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, json);
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/fontlist$")]
        public void HandleFontList(HttpListenerContext context)
        {
            InstalledFontCollection fontsCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontsCollection.Families;
            List<string> fonts = new List<string>();

            foreach (FontFamily font in fontFamilies)
            {
                fonts.Add(font.Name);
            }

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, JsonConvert.SerializeObject(fonts));
        }

        public static bool CanReadDirectory(string path)
        {
            var readAllow = false;
            var readDeny = false;
            var accessControlList = Directory.GetAccessControl(path);
            if (accessControlList == null) { return false; }

            var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
            if (accessRules == null) { return false; }

            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read) continue;

                if (rule.AccessControlType == AccessControlType.Allow) readAllow = true;
                if (rule.AccessControlType == AccessControlType.Deny) readDeny = true;
            }

            return readAllow && !readDeny;
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/choosesetup(.*)?$")]
        public void HandleChooseSetup(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            ClockFileBrowser browser = new ClockFileBrowser();

            var showListing = context.Request.QueryString["showListing"];
            var dirName = context.Request.QueryString["dir"];
            var dirPath = _myClockDisplay.clockAppConfig.CinemaRoot;
            var fullPath = context.Request.QueryString["fullpath"];

            if (fullPath == "" || fullPath == null) { fullPath = dirPath;  }

            switch (showListing)
            {
                case "fileListing":
                    List<string> files = new List<string>(browser.getFileList(fullPath));
                    this.SendTextResponse(context, JsonConvert.SerializeObject(files));
                    break;
                default:
                    List<string> dirs = new List<string>(browser.getDirectoryList(fullPath));
                    this.SendTextResponse(context, JsonConvert.SerializeObject(dirs));
                    break;
            }
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/dirlist(.*)?$")]
        public void HandleDirList(HttpListenerContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            ClockFileBrowser browser = new ClockFileBrowser();

            var showListing = context.Request.QueryString["showListing"];

            var driveName = "";
            var dirPath = "";
            var dirName = "";

            if (showListing == "" || showListing == null) { showListing = "driveListing";  }

            switch (showListing)
            {
                case "driveListing":
                    List<string> drives = new List<string>(browser.getAllDrives());

                    this.SendTextResponse(context, JsonConvert.SerializeObject(drives));
                    break;
                case "dirListing":

                    driveName = context.Request.QueryString["drive"];
                    if (driveName == "" && driveName == null) { this.SendTextResponse(context, "Invalid drive!"); }

                    dirPath = driveName;

                    dirName = context.Request.QueryString["dir"];
                    if (dirName != "" && dirName != null) { dirPath = Path.Combine(dirPath, dirName); }

                    List<string> dirs = new List<string>(browser.getDirectoryList(dirPath));

                    this.SendTextResponse(context, JsonConvert.SerializeObject(dirs));

                    break;
                case "fileListing": 
                    driveName = context.Request.QueryString["drive"];
                    if (driveName == "" && driveName == null) { this.SendTextResponse(context, "Invalid drive!"); }

                    dirPath = driveName;

                    dirName = context.Request.QueryString["dir"];
                    if (dirName != "" && dirName != null) { dirPath = Path.Combine(dirPath, dirName); }

                    List<string> files = new List<string>(browser.getFileList(dirPath));
                    this.SendTextResponse(context, JsonConvert.SerializeObject(files));

                    break;
            }
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/battstat$")]
        public void HandleBatteryStat(HttpListenerContext context)
        {
            Battery battery = new Battery();

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var obj = new
            {
                batteryCharge = battery.getBatteryCharge(),
                batteryStatus = battery.getPowerStatus()
            };

            this.SendTextResponse(context, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/runpresentation(.*)?$")]
        public void HandleRunPresentation(HttpListenerContext context)
        {
            var presentationFile = context.Request.QueryString["presentation"];

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            if (presentationFile != "" && presentationFile != null)
            {
                _myClockDisplay.RunClockAction(new MethodInvoker(delegate() { _myClockDisplay.RunPowerpointPresentation(presentationFile); }));
                this.SendTextResponse(context, "Running Presentation File");
            }
            else
            {
                this.SendTextResponse(context, "Invalid presentation file!");
            }
        }
    }
}
