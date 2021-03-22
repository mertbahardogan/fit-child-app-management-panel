using FitChildPanel.Models.Classes;
using FitChildPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitChildPanel.Controllers
{
    public class StoryController : ApiController
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        public IEnumerable<Oneriler> GetOneriler() => db.TBLONERI.Select(k => new Oneriler
        {

            ID = k.ID,
            OneriAdi = k.OneriAdi,
            OneriResim = k.OneriResim,
            OneriFayda = k.OneriFayda,
            OneriTavsiye = k.OneriTavsiye,
            OneriCalisanBolge = k.OneriCalisanBolge,
            OneriEklenmeTarih = k.OneriEklenmeTarih,
        }).ToList();
    }
}
