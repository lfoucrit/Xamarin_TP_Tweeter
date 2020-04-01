using System;
using System.Collections.Generic;
using System.Text;
using TP_Module4.models;

namespace TP_Module4
{
    public interface ITwitterService
    {
        bool authenticate(string user, string password);
        List<Tweet> getTweet();
    }
}
