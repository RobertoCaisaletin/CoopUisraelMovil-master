using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CoopUisraelSQlite
{
    public partial class Info : ContentPage
    {
        public Info()
        {
            InitializeComponent();
        }

        void btn_SimularCredito_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Simular());
        }
    }
}
