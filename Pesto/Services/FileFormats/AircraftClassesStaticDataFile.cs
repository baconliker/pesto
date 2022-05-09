using System;
using System.Collections.Generic;
using System.Xml;

namespace ColinBaker.Pesto.Services.FileFormats
{
    class AircraftClassesStaticDataFile
    {
        public AircraftClassesStaticDataFile(string filePath)
        {
            this.FilePath = filePath;
        }

        public Models.AircraftClass[] Load()
        {
            List<Models.AircraftClass> aircraftClasses = new List<Models.AircraftClass>();

            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);

            foreach (XmlNode aircraftClassNode in document.SelectNodes("/Boris/AircraftClass"))
            {
                aircraftClasses.Add(new Models.AircraftClass(aircraftClassNode.SelectSingleNode("Code").InnerText, aircraftClassNode.SelectSingleNode("Description").InnerText));
            }

            return aircraftClasses.ToArray();
        }

        public string FilePath { get; set; }
    }
}
