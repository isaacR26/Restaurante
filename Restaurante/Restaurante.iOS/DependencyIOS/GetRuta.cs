using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Restaurante.iOS.DependencyIOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetRuta))]
namespace Restaurante.iOS.DependencyIOS
{
    public class GetRuta
    {
        public string GetRutaDB(string NameBD)
        {
            string docFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, NameBD);
        }
    }
}