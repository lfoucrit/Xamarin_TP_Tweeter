using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TP_Module4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ITwitterService twitterService = new TwitterServiceImpl();

        public MainPage()
        {
            InitializeComponent();
            btnConnexion.Clicked += Connection_Clicked;
        }

        private void Connection_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Connection is clicked");

            Boolean hasError = false;
            StringBuilder messageErrors = new StringBuilder();
            this.messageError.Text = null;
            this.messageError.IsVisible = false;
            try
            {
                if (this.identifiant.Text == null || string.IsNullOrEmpty(this.identifiant.Text.ToString()))
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un identifiant. \n");
                }
                else if(this.identifiant.Text.Length < 3)
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un identifiant avec plus de 3 caractères. \n");
                }
                if (this.password.Text == null || string.IsNullOrEmpty(this.password.Text.ToString()))
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un mot de passe. \n");
                }
                else if (this.password.Text.Length < 6)
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un mot de passe avec plus de 6 caractères. \n");
                }
                Boolean isRemind = this.memoryInfos.IsToggled;
            } catch(Exception exception)
            {
                hasError = true;
                messageErrors.Append(exception.Message);
            }
            if (hasError)
            {
                this.messageError.Text = messageErrors.ToString();
                this.messageError.IsVisible = true;
            } else
            {
                if(this.twitterService.authenticate(this.identifiant.Text.ToString(), this.password.Text.ToString()))
                {
                    this.form_connection.IsVisible = false;
                    this.div_tweet.IsVisible = true;
                } else
                {
                    this.messageError.Text = "Identifiants incorrecte.";
                    this.messageError.IsVisible = true;
                }
            }
            
        }
    }
}
