using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Module4.models;
using Xamarin.Forms;

namespace TP_Module4
{
    public class TwitterServiceImpl : ITwitterService
    {
        private Dictionary<string, string> listUser = new Dictionary<string, string>();

        public TwitterServiceImpl()
        {
            listUser.Add("admin", "admin");
            listUser.Add("lfoucrit", "lfoucrit");
            listUser.Add("dponchet", "secret");
            listUser.Add("slimon", "secret");
            listUser.Add("user", "Pa$$w0rd");
        }

        public bool authenticate(string user, string password)
        {
            if (listUser.ContainsKey(user) && listUser.TryGetValue(user, out password))
            {
                return true;
            }
            return false;
        }

        public List<Tweet> getTweets()
        {
            User user1 = new User { identifiant = 1, name = "Simon", pseudo = "@slimon", avatar = ImageSource.FromUri(new Uri("https://picsum.photos/50/50/?random")) };
            User user2 = new User { identifiant = 2, name = "Damien", pseudo = "@dponchet", avatar = ImageSource.FromUri(new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/ladylexy/128.jpg")) };
            User user3 = new User { identifiant = 3, name = "Cédric", pseudo = "@cedricmillauriaux", avatar = ImageSource.FromUri(new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/adhamdannaway/128.jpg")) };

            ObservableCollection <Tweet> tweets = new ObservableCollection<Tweet>();
            tweets.Add(new Tweet { dateCreation = "Mercredi 01/04/2020 11:25", identifiant = "1", user= user1, text = "Un tweet pour commencer" });
            tweets.Add(new Tweet { dateCreation = "Mardi 31/03/2020 22:01", identifiant = "2", user =user2, text = "Un tweet" });
            tweets.Add(new Tweet { dateCreation = "Mardi 31/03/2020 22:29", identifiant = "3", user = user2, text = "Un autre tweet" });
            tweets.Add(new Tweet { dateCreation = "Mardi 31/03/2020 23:45", identifiant = "4", user = user2, text = "Et encore un autre tweet" });
            tweets.Add(new Tweet { dateCreation = "Mercredi 01/04/2020 10:33", identifiant = "5", user = user3, text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod convallis dolor. Quisque ultricies porttitor nunc venenatis facilisis. " });
            return tweets.ToList();
        }
    }
}
