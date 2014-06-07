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

                myNewClockSettings = JsonConvert.DeserializeObject<ClockSettings>(json);
                File.WriteAllText(@"profiles\" + myNewClockSettings.ProfileName + ".json", json);

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

                myNewClockSettings = JsonConvert.DeserializeObject<ClockSettings>(json);

                ClockProfiles response = _myClockDisplay.cps.Profiles.Find(r => r.ProfileName == myNewClockSettings.ProfileName);

                response.ProfileSettings = JsonConvert.DeserializeObject<ClockSettings>(json);

                File.WriteAllText(@"profiles\" + myNewClockSettings.ProfileName + ".json", json);

                if (response.ProfileSettings.ProfileName == _myClockDisplay.cps.LoadedProfile.ProfileName)
                {
                    _myClockDisplay.cps.LoadedProfile = myNewClockSettings;
                }

                _myClockDisplay.clockSettingsBindingSource.Clear();
                _myClockDisplay.clockSettingsBindingSource.Add(myNewClockSettings);
                _myClockDisplay.settings = myNewClockSettings;
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
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            string appConfig = JsonConvert.SerializeObject(_myClockDisplay.clockAppConfig);
            this.SendTextResponse(context, appConfig);
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
    }
}
