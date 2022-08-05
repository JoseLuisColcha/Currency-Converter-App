using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertPage : ContentPage
    {
        double value;
        string currency1;
        string currency2;
        double conversion;

        public ConvertPage()
        {
            List<string> currencyList = new List<string>();
            InitializeComponent();

            currencyList.Add("USD(Dolar estadounidense)");
            currencyList.Add("ARS(Peso argentino)");
            currencyList.Add("COP(Peso colombiano)");
            currencyList.Add("EUR(Euro)");
            currencyList.Add("MXN(Peso mexicano)");


            currencyPickerFrom.ItemsSource = currencyList;
            currencyPickerTo.ItemsSource = currencyList;

            
        }
        private void Validate()
        {
            if (!string.IsNullOrEmpty(txtValue.Text) && !string.IsNullOrEmpty(currency1) && !string.IsNullOrEmpty(currency2))
            {

                Calculate();
            }
            else
            {
                DisplayAlert("Mensaje de error", "Completa los campos solicitados!", "OK");
            }
        }

        private void currencyPickerFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            currency1 = Convert.ToString(currencyPickerFrom.SelectedItem);

        }
        private void currencyPickerTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            currency2 = Convert.ToString(currencyPickerTo.SelectedItem);
        }
        private void btnConverter_Clicked(object sender, EventArgs e)
        {
            Validate();
        }
        private void Calculate()
        {
            value = Convert.ToDouble(txtValue.Text);

            switch (currency1)
            {
                case "USD(Dolar estadounidense)":
                    switch (currency2)
                    {
                        case "ARS(Peso argentino)":
                            conversion = value * 132.64;
                            break;
                        case "COP(Peso colombiano)":
                            conversion = value * 4301.33;
                            break;
                        case "EUR(Euro)":
                            conversion = value * 0.98;
                            break;
                        case "MXN(Peso mexicano)":
                            conversion = value * 20.34;
                            break;
                        default:
                            conversion = value;
                            break;
                    };
                    break;

                case "ARS(Peso argentino)":
                    switch (currency2)
                    {
                        case "USD(Dolar estadounidense)":
                            conversion = value * 0.0075;
                            break;
                        case "COP(Peso colombiano)":
                            conversion = value * 32.43;
                            break;
                        case "EUR(Euro)":
                            conversion = value * 0.0074;
                            break;
                        case "MXN(Peso mexicano)":
                            conversion = value * 0.15;
                            break;
                        default:
                            conversion = value;
                            break;
                    };
                    break;
                case "COP(Peso colombiano)":
                    switch (currency2)
                    {
                        case "USD(Dolar estadounidense)":
                            conversion = value * 0.00023;
                            break;
                        case "ARS(Peso argentino)":
                            conversion = value * 0.031;
                            break;
                        case "EUR(Euro)":
                            conversion = value * 0.00023;
                            break;
                        case "MXN(Peso mexicano)":
                            conversion = value * 0.0047;
                            break;
                        default:
                            conversion = value;
                            break;
                    };
                    break;
                case "EUR(Euro)":
                    switch (currency2)
                    {
                        case "USD(Dolar estadounidense)":
                            conversion = value * 1.02;
                            break;
                        case "ARS(Peso argentino)":
                            conversion = value * 135.89;
                            break;
                        case "COP(Peso colombiano)":
                            conversion = value * 4407.06;
                            break;
                        case "MXN(Peso mexicano)":
                            conversion = value * 20.84;
                            break;
                        default:
                            conversion = value;
                            break;
                    };
                    break;
                case "MXN(Peso mexicano)":
                    switch (currency2)
                    {
                        case "USD(Dolar estadounidense)":
                            conversion = value * 0.049;
                            break;
                        case "ARS(Peso argentino)":
                            conversion = value * 6.52;
                            break;
                        case "COP(Peso colombiano)":
                            conversion = value * 211.48;
                            break;
                        case "EUR(Euro)":
                            conversion = value * 0.048;
                            break;
                        default:
                            conversion = value;
                            break;
                    };

                    break;

            }
            lblValue.Text = Convert.ToString(value);
            lblCurrency1.Text = currency1;
            lblRes.Text= Convert.ToString(conversion);  
            lblCurrency2.Text = currency2;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}