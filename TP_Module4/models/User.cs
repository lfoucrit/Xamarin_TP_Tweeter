using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TP_Module4.models
{
    public class User
    {
        public int identifiant{ get; set; }
        public string name { get; set; }
        public string pseudo { get; set; }
        public ImageSource avatar { get; set; }
    }
}
