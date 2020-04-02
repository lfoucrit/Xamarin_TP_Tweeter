using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

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
            this.listeTweets.ItemsSource = twitterService.getTweets();
        }

        private void Connection_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Connection is clicked");
            this.messageError.Text = null;
            this.messageError.IsVisible = false;

            Boolean isRemind = this.memoryInfos.IsToggled;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                this.messageError.Text = "La connexion internet est indisponible";
                this.messageError.IsVisible = true;
                return;
            }

            string messageError = this.checkConnection();
            if (messageError != null) 
            {
                //Une erreur rencontrée sur formulaire
                this.messageError.Text = messageError;
                this.messageError.IsVisible = true;
            } 
            else
            {
                //Vérification des identifiants
                if(this.twitterService.authenticate(this.identifiant.Text.ToString(), this.password.Text.ToString()))
                {
                    this.form_connection.IsVisible = false;
                    this.div_tweet.IsVisible = true;
                } else
                {
                    this.messageError.Text = "Identifiants inconnus.";
                    this.messageError.IsVisible = true;
                }
            }
        }

        private string checkConnection()
        {
            Boolean hasError = false;
            StringBuilder messageErrors = new StringBuilder();
            try
            {
                if (this.identifiant.Text == null || string.IsNullOrEmpty(this.identifiant.Text.ToString()))
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un identifiant. \n");
                }
                else if (this.identifiant.Text.Length < 3)
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
            }
            catch (Exception exception)
            {
                hasError = true;
                messageErrors.Append(exception.Message);
            }
            if (hasError) {
                return messageErrors.ToString();
            } else
            {
                return null;
            }
        }

    }
}
