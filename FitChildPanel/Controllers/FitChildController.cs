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

    public class FitChildController : ApiController
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        //FitChild
        public IEnumerable<Egzersizler> GetEgzersizler() => db.TBLEGZERSIZ.Select(k => new Egzersizler
        {

            ID = k.ID,
            EgzersizAdi = k.EgzersizAdi,
            EgzersizResim = k.EgzersizResim,
            EgzersizFayda = k.EgzersizFayda,
            EgzersizSeviye = k.EgzersizSeviye,
            EgzersizYapilisi = k.EgzersizYapilisi,
        }).ToList();

        
    }
}
