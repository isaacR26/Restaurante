using Android.App;
using Android.Content;
using System.IO;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurante.Dependency;
using Restaurante.Droid.DependencyAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetRuta))]
namespace Restaurante.Droid.DependencyAndroid
{
   public class GetRuta: IGetRuta
    {
        public string GetRutaDB(string dbPath)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(ruta, dbPath);
        }

    }
}