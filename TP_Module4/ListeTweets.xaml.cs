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
    public partial class ListeTweets : ContentPage
    {
        private ITwitterService twitterService = new TwitterServiceImpl();

        public ListeTweets()
        {
            InitializeComponent();
            this.listeTweets.ItemsSource = twitterService.getTweets();
            this.nbTweets.Text = twitterService.getTweets().Count + " tweets";
        }

        private async void listeTweets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Tweet tweet = (Tweet)this.listeTweets.SelectedItem;
            await Navigation.PushAsync(new DetailsTweet(tweet));
        }

        private async void logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}