using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_Module4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Footer : ContentView
    {
        public Footer()
        {
            InitializeComponent();
        }

        private async void logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}