using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Data;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Lobster-Regular.ttf", Alias = "Lobster")]

namespace Restaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private async void ShowProduct_OnClicked(object sender, EventArgs e)
        {
            await App.FlyoutP.Detail.Navigation.PushAsync(new ShowProducts());
            App.FlyoutP.IsPresented = false;

        }
    }
}