using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertProduct : ContentPage
    {

        public InsertProduct()
        {
            InitializeComponent();
         
        }


        private async void BtnRegister_OnClicked(object sender, EventArgs e)
        {
            if (ValidateInformation())
            {
                Products products = new Products()
                {
                    
                    NameProduct = txtName.Text,
                    PriceProduct = int.Parse(txtPrice.Text),
                    QuantyProduct = int.Parse(txtQuanty.Text),
                    Description = txtDescrip.Text,

                };
                await App.DbLiteH.SaveProductAsync(products);
                txtName.Text = "";
                txtPrice.Text = "";
                txtQuanty.Text = "";
                txtDescrip.Text = "";
                await DisplayAlert("Registro", "Guardado Exitosamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Rellenar todos los Campos", "OK");
            }
        }

        private async void BtnDelete_OnClicked(object sender, EventArgs e)
        {
            var actionSheet = await DisplayActionSheet("Desea eliminar el producto?", "Cancelar", null,
                "SI", "NO");
            
            switch (actionSheet)
            {
                case "Cancelar":

                    // Que ocurrira cuando el boton respectivo "Cancelar" sea presionado
                    //Se quiebra el metodo

                    break;

                case "SI":
                    //Que ocurrira cuando el boton respectivo "SI" sea presionado
                    //Se ejecutara:
                    if (ValidateInformationSearch())
                    {
                        Products products = new Products
                        {
                            IdProduct = Convert.ToInt32(txtId.Text),
                        };
                        Products productsfound = await App.DbLiteH.SearchOne(products);
                        if (productsfound != null)
                        {
                            await App.DbLiteH.DeleteProductAsync(products);
                        }
                        else
                        {
                            await DisplayAlert("Error", "No encontrado", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Ingrese la ID del producto", "OK");
                    }
                    

                    break;

                case "NO":

                    // Que ocurrira cuando el boton respectivo "NO" sea presionado
                    //Se quiebra el metodo

                    break;
            }
        }

        private async void SearchOne(object sender, EventArgs e)
        {
           
                
                Products products = new Products
                {
                    IdProduct = Convert.ToInt32(txtId.Text)
                };

                Products productsfound = await App.DbLiteH.SearchOne(products);

                if (productsfound!=null)
                {
                    txtName.Text = productsfound.NameProduct;
                    txtPrice.Text = Convert.ToString(productsfound.PriceProduct);
                    txtQuanty.Text = Convert.ToString(productsfound.QuantyProduct);
                    txtDescrip.Text = productsfound.Description;
                    await DisplayAlert("Busqueda", "Producto encontrado con Exito", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No encontrado", "OK");
                    txtName.Text = "";
                    txtPrice.Text = "";
                    txtQuanty.Text = "";
                    txtDescrip.Text = "";
                }


        }

        private async void BtnEdit_OnClicked(object sender, EventArgs e)
        {
            if (ValidateInformation())
            {
                Products products = new Products
                {
                    IdProduct = Convert.ToInt32(txtId.Text),
                    NameProduct = txtName.Text,
                    PriceProduct = int.Parse(txtPrice.Text),
                    QuantyProduct = int.Parse(txtQuanty.Text),
                    Description = txtDescrip.Text,

                };
                await App.DbLiteH.UpdateProductAsync(products);
                txtName.Text = "";
                txtPrice.Text = "";
                txtQuanty.Text = "";
                txtDescrip.Text = "";
                await DisplayAlert("Actualizacion", "Actualizado Exitosamente", "OK");
            }
            else
            {
                await DisplayAlert("Actualizacion", "Un dato VACIO", "OK");
            }
        }

        public bool ValidateInformation()
        {
            bool answer;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                answer = false;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                answer = false;

            } else if (string.IsNullOrEmpty(txtQuanty.Text))
            {
                answer = false;

            } else if (string.IsNullOrEmpty(txtDescrip.Text))
            {
                answer = false;
            }
            else
            {
                answer = true;
            }

            return answer;
        }
        public bool ValidateInformationSearch()
        {
            bool answer;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                answer = false;
            }
            else
            {
                answer = true;
            }

            return answer;
        }


    }
}
