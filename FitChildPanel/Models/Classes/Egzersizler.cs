using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitChildPanel.Models.Classes
{
    public class Egzersizler
    {
        public int ID { get; set; }
        public string EgzersizAdi { get; set; }
        public string EgzersizResim { get; set; }
        public string EgzersizFayda { get; set; }
        public string EgzersizSeviye { get; set; }
        public string EgzersizYapilisi { get; set; }
    }
}