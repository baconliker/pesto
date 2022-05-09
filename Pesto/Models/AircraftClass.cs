using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models
{
	class AircraftClass
	{
        public AircraftClass(string code, string description)
		{
			this.Code = code;
            this.Description = description;
		}

        public override string ToString()
        {
            return this.Code;
        }

        public static AircraftClass[] GetAllClasses()
        {
            // Exception handling because I'm modifying this code just before WPC2016
            try
            {
                Services.FileFormats.AircraftClassesStaticDataFile dataFile = new Services.FileFormats.AircraftClassesStaticDataFile(System.Windows.Forms.Application.StartupPath + @"\Resources\StaticData\AircraftClasses.xml");
                return dataFile.Load();
            }
            catch
            {
                return GetAllClassesOld();
            }
        }

        private static AircraftClass[] GetAllClassesOld()
		{
            return new AircraftClass[] { new AircraftClass("PF1", "Paraglider, foot-launched, solo"), new AircraftClass("PF1m", "Paraglider, foot-launched, solo, male"), new AircraftClass("PF1f", "Paraglider, foot-launched, solo, female"), new AircraftClass("PF2", "Paraglider, foot-launched, tandem"), new AircraftClass("PL1", "Paraglider, landplane, solo"), new AircraftClass("PL2", "Paraglider, landplane, tandem"), new AircraftClass("WF1", "Weight-shift, foot-launched, solo"), new AircraftClass("WF2", "Weight-shift, foot-launched, tandem"), new AircraftClass("WL1", "Weight-shift, landplane, solo"), new AircraftClass("WL2", "Weight-shift, landplane, tandem"), new AircraftClass("AL1", "3-axis, landplane, solo"), new AircraftClass("AL2", "3-axis, landplane, tandem"), new AircraftClass("GL1", "Autogyro, landplane, solo"), new AircraftClass("GL2", "Autogyro, landplane, tandem") };
		}

		public static AircraftClass[] GetBackwardCompatibleClasses()
		{
			return new AircraftClass[] { new AircraftClass("PF1", "Foot Launch"), new AircraftClass("PL1", "Paramotor Trike"), new AircraftClass("WF1", "Powered Hang Glider") };
		}

		public string Code { get; set; }
        public string Description { get; set; }
	}
}
