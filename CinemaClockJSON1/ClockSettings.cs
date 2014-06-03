using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CinemaClockJSON
{
    public class ClockProfileState
    {
        private List<ClockProfiles> profiles;
        private ClockSettings loadedProfile;

        public ClockProfileState()
        {
            profiles = new List<ClockProfiles>();
        }

        public List<ClockProfiles> Profiles { set { this.profiles = value; } get { return this.profiles; } }
        public ClockSettings LoadedProfile { set { this.loadedProfile = value; } get { return this.loadedProfile;  } }
    }

    public class ClockProfiles
    {
        private string profileName;
        private ClockSettings profileSettings;

        public ClockProfiles(string profileName, ClockSettings profileSettings)
        {
            this.profileName = profileName;
            this.profileSettings = profileSettings;
        }

        public string ProfileName { set { this.profileName = value; } get { return this.profileName; } }
        public ClockSettings ProfileSettings { set { this.profileSettings = value; } get { return this.profileSettings; } }
    }

    public class ClockSettings : INotifyPropertyChanged
    {
        private string profileName = "Default";
        private string topText = "Rural Cinema";
        private string bottomText = "Rural Cinema";
        private int clockColour = -256;
        private int topOnColour1 = -65536;
        private int topOffColour1 = -16777216;
        private int bottomOnColour1 = -65536;
        private int bottomOffColour1 = -16777216;
        private int topFontSize = 71;
        private int bottomFontSize = 71;
        private string powerpointOne;
        private string powerpointTwo;
        private string topFont = "Microsoft Sans Serif";
        private string bottomFont = "Microsoft Sans Serif";
        private bool topFontSizeOverride = false;
        private bool bottomFontSizeOverride = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ClockSettings()
        {

        }

        public string ProfileName
        {
            get { return profileName; }
            set { 
                profileName = value;
                OnPropertyChanged("ProfileName");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string TopText
        {
            get { return topText; }
            set { 
                topText = value;
                OnPropertyChanged("TopText");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string BottomText
        {
            get { return bottomText; }
            set { 
                bottomText = value;
                OnPropertyChanged("BottomText");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int ClockColour
        {
            get { return clockColour; }
            set { 
                clockColour = value;
                OnPropertyChanged("ClockColour");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int TopOnColour1
        {
            get { return topOnColour1; }
            set { 
                topOnColour1 = value;
                OnPropertyChanged("TopOnColour1");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int TopOffColour1
        {
            get { return topOffColour1; }
            set { 
                topOffColour1 = value;
                OnPropertyChanged("TopOffColour1");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int BottomOnColour1
        {
            get { return bottomOnColour1; }
            set { 
                topOnColour1 = value;
                OnPropertyChanged("BottomOnColour1");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int BottomOffColour1
        {
            get { return bottomOffColour1; }
            set { 
                bottomOffColour1 = value;
                OnPropertyChanged("BottomOffColour1");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int TopFontSize
        {
            get { return topFontSize; }
            set { 
                topFontSize = value;
                OnPropertyChanged("TopFontSize");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public int BottomFontSize
        {
            get { return bottomFontSize; }
            set { 
                bottomFontSize = value;
                OnPropertyChanged("BottomFontSize");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string PowerpointOne
        {
            get { return powerpointOne; }
            set { 
                powerpointOne = value;
                OnPropertyChanged("PowerpointOne");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string PowerpointTwo
        {
            get { return powerpointTwo; }
            set { 
                powerpointTwo = value;
                OnPropertyChanged("PowerpointTwo");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string TopFont
        {
            get { return topFont; }
            set { 
                topFont = value;
                OnPropertyChanged("TopFont");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public string BottomFont
        {
            get { return bottomFont; }
            set { 
                bottomFont = value;
                OnPropertyChanged("BottomFont");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public bool TopFontSizeOverride
        {
            get { return topFontSizeOverride; }
            set { 
                topFontSizeOverride = value;
                OnPropertyChanged("TopFontSizeOverride");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public bool BottomFontSizeOverride
        {
            get { return bottomFontSizeOverride; }
            set { 
                bottomFontSizeOverride = value;
                OnPropertyChanged("BottomFontSizeOverride");
            }
        }

        [System.ComponentModel.Bindable(true)]
        public PowerpointPresentations presentations { get; set; }

        public class PowerpointPresentations
        {
            [System.ComponentModel.Bindable(true)]
            public string presentationName { get; set; }

            [System.ComponentModel.Bindable(true)]
            public string presentation { get; set; }
        }
    }
}
