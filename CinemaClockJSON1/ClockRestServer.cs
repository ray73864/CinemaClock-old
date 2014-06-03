using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grapevine;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

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
        private ClockConfig _myClockConfig;

        public ClockDisplay myClockDisplay { set { this._myClockDisplay = value; } get { return this._myClockDisplay; } }
        public ClockConfig myClockConfig { set { this._myClockConfig = value; } get { return this._myClockConfig; } }
        
        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/(\w+)(.html)")]
        public void HandleHTMLFiles(HttpListenerContext context)
        {
            
        }

        [RestRoute(Method = HttpMethod.POST, PathInfo = @"^/saveprofile$")]
        public void HandleSaveProfile(HttpListenerContext context)
        {
            String json = null;
            ClockSettings clockSettings = new ClockSettings();
            HttpListenerRequest request = context.Request;

            try
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    json = reader.ReadToEnd();
                }

                clockSettings = JsonConvert.DeserializeObject<ClockSettings>(json);
            }
            catch { }

            string json2 = JsonConvert.SerializeObject(clockSettings, Formatting.Indented);

            File.WriteAllText(@"profiles\" + clockSettings.ProfileName + ".json", json);

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, "Test Complete?");
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/testsave$")]
        public void HandleTestSave(HttpListenerContext context)
        {
            WebClient web = new WebClient();

            ClockSettings testClock = new ClockSettings();
            testClock.ProfileName = "REST Test 1";

            web.UploadString("http://localhost:1234/saveprofile", "POST", JsonConvert.SerializeObject(testClock));

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"profiles");

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            List<Profile> profiles = new List<Profile>();

            foreach (FileInfo file in files)
            {
                ClockSettings clock = JsonConvert.DeserializeObject<ClockSettings>(File.ReadAllText(@"profiles\" + file.Name));

                Profile profile = new Profile
                {
                    profileName = clock.ProfileName
                };

                profiles.Add(profile);
            }

            string json = JsonConvert.SerializeObject(profiles, Formatting.Indented);

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, json);            
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/currentprofile$")]
        public void HandleCurrentProfile(HttpListenerContext context)
        {
            String currentProfile = JsonConvert.SerializeObject(_myClockDisplay.cps.LoadedProfile);

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, currentProfile);
        }

        [RestRoute(Method = HttpMethod.GET, PathInfo = @"^/profiles(.*)?$")]
        public void HandleProfilesList(HttpListenerContext context)
        {
            /*
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"profiles");

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            List<Profile> profiles = new List<Profile>();

            foreach (FileInfo file in files)
            {
                ClockSettings clock = JsonConvert.DeserializeObject<ClockSettings>(File.ReadAllText(@"profiles\" + file.Name));

                Profile profile = new Profile {
                    profileName = clock.ProfileName
                };

                profiles.Add(profile);
            }
            */
            string json = JsonConvert.SerializeObject(_myClockDisplay.cps.Profiles, Formatting.Indented);

            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            this.SendTextResponse(context, json);
        }
    }
}
