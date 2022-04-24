using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurante.Models;

namespace Restaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProducts : ContentPage
    {

        public ShowProducts()
        {
            
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListProducts.ItemsSource = await App.DbLiteH.GetProductsAsync();
        }

        private async void Bar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var listProducts=await App.DbLiteH.GetProductsAsync();

            ListProducts.ItemsSource = listProducts.Where(s => s.NameProduct.Contains(e.NewTextValue));
        }

        private async void GoReg_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertProduct());

        }
    }
    }
