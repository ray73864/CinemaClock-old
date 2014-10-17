using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaClockJSON
{
    public class ClockDriveListing
    {

    }

    public class ClockDirectoryListing
    {

    }

    public class ClockFileListing
    {

    }

    class ClockFileBrowser
    {
        private List<string> driveListing = new List<string>();
        public ClockFileBrowser() {

        }

        public List<string> getAllDrives() {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach(DriveInfo d in allDrives) {
                if (d.IsReady == true)
                {
                    driveListing.Add(d.Name);
                }
            }

            return driveListing;
        }

        public List<string> getDirectoryList(string path)
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
            List<string> removeDirs = new List<string>();

            DirectoryInfo directoryInfo = Directory.GetParent(path);
            DirectoryInfo parent = null;

            try
            {
                parent = directoryInfo.Parent;

                if (parent.FullName != directoryInfo.FullName) { dirs.Insert(0, directoryInfo.FullName); }
            } catch (NullReferenceException nre)
            {

            }

            foreach (string dir in dirs)
            {
                try { List<string> tmpDirs = new List<string>(Directory.EnumerateDirectories(dir)); }
                catch (UnauthorizedAccessException uae) { removeDirs.Add(dir); }
            }

            foreach (string dir in removeDirs)
            {
                dirs.Remove(dir);
            }

            return dirs;
        }

        public List<string> getFileList(string path)
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(path));

            return files;
        }
    }
}
