using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaClockJSON
{
    class Battery
    {
        PowerStatus psBattery = SystemInformation.PowerStatus;

        public int getBatteryCharge()
        {
            return (int) psBattery.BatteryLifePercent * 100;
        }

        public string getPowerStatus()
        {
            switch (psBattery.PowerLineStatus)
            {
                case PowerLineStatus.Online: return "A/C";
                case PowerLineStatus.Offline: return "D/C";
                default: return "";
            }
        }
    }
}
