using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Module4.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_Module4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsTweet : ContentPage
    {
        Tweet tweet;
        public DetailsTweet(Tweet tweet)
        {
            InitializeComponent();
            this.tweet = tweet;
            if (tweet != null)
            {
                this.avatar.Source = tweet.user.avatar;
                this.nameUser.Text = tweet.user.name;
                this.pseudoUser.Text = tweet.user.pseudo;
                this.text.Text = tweet.text;
                this.dateCreation.Text = tweet.dateCreation;
            }
        }
    }
}