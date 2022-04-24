using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsProduct : ContentPage
    {
   
        public DetailsProduct(string NameProduct,double PriceProduct, int QuantyProduct,string Description)
        {
           InitializeComponent();
           NameCall.Text= NameProduct;
           PriceCall.Text= Convert.ToString(PriceProduct);
           QuantyCall.Text= Convert.ToString(QuantyProduct) ;
           DescriptionCall.Text= Description;
      
        }

        private async void GoPro_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowProducts());
        }
    }
}