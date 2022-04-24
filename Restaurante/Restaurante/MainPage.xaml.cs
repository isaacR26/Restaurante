using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Restaurante
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Flyout = new Menu();
            this.Detail = new NavigationPage(new InsertProduct())
            {
                BarBackgroundColor = Color.AntiqueWhite,
                BarTextColor = Color.SaddleBrown,
            };
            App.FlyoutP = this;
        }
    }
}
