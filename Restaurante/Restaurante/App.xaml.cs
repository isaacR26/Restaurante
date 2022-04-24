using System;
using System.IO;
using System.Threading.Tasks;
using Restaurante.Data;
using Restaurante.Dependency;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurante
{
    public partial class App : Application
    {
        static SQLiteH db;

        public static Task SQLiteH;
        public static FlyoutPage FlyoutP { get; set; } 
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static SQLiteH DbLiteH
        {
            get
            {
                if (db==null)
                {
                    db = new SQLiteH(DependencyService.Get<IGetRuta>().GetRutaDB("BDRestaurant"));
                }

                return db;
            }
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
