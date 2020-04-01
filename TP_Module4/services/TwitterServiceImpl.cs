using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Module4.models;

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

        public List<Tweet> getTweet()
        {
            List<Tweet> tweets = new List<Tweet>
            {
                new Tweet{ dateCreation ="Mercredi 01/04/2020 11:25", identifiant="1", nameUser="Simon", pseudoUser="slimon", text="Un tweet pour commencer"},
                new Tweet{ dateCreation ="Mardi 31/03/2020 22:01", identifiant="2", nameUser="Damien", pseudoUser="dponchet", text="Un tweet"},
                new Tweet{ dateCreation ="Mardi 31/03/2020 22:29", identifiant="3", nameUser="Damien", pseudoUser="dponchet", text="Un autre tweet"},
                new Tweet{ dateCreation ="Mardi 31/03/2020 23:45", identifiant="4", nameUser="Damien", pseudoUser="dponchet", text="Et encore un autre tweet"},
                new Tweet{ dateCreation ="Mardi 01/04/2020 10:33", identifiant="5", nameUser="Cédric", pseudoUser="cedirmillauriaux", text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod convallis dolor. Quisque ultricies porttitor nunc venenatis facilisis. "}
            };
            return tweets;
        }
    }
}
