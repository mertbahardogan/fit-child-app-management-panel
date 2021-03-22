using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitChildPanel.Models.Classes
{
    public class Oneriler
    {
        public int ID { get; set; }
        public string OneriAdi { get; set; }
        public string OneriResim { get; set; }
        public string OneriFayda { get; set; }
        public string OneriTavsiye { get; set; }
        public string OneriCalisanBolge { get; set; }
        public Nullable<System.DateTime> OneriEklenmeTarih { get; set; }
    }
}