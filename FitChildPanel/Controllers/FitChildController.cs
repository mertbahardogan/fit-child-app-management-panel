using FitChildPanel.Attributes;
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
        public IHttpActionResult GetEgzersizler()
        {

            List<Egzersizler> egzersizler = db.TBLEGZERSIZ.Select(k => new Egzersizler
            {
                ID = k.ID,
                EgzersizAdi = k.EgzersizAdi,
                EgzersizResim = k.EgzersizResim,
                EgzersizFayda = k.EgzersizFayda,
                EgzersizSeviye = k.EgzersizSeviye,
                EgzersizYapilisi = k.EgzersizYapilisi,
            }).ToList();

            if (egzersizler.Count == 0)
            {
                return NotFound();
            }

            return Ok(egzersizler);


        }
    }
}


//public IEnumerable<Egzersizler> GetEgzersizler()
//{
//    var egzersizler = db.TBLEGZERSIZ.Select(k => new Egzersizler
//    {
//        ID = k.ID,
//        EgzersizAdi = k.EgzersizAdi,
//        EgzersizResim = k.EgzersizResim,
//        EgzersizFayda = k.EgzersizFayda,
//        EgzersizSeviye = k.EgzersizSeviye,
//        EgzersizYapilisi = k.EgzersizYapilisi,
//    }).ToList();

//    return egzersizler;
//}



//public IHttpActionResult GetEgzersizler()
//{
//    try
//    {
//        List<Egzersizler> egzersizler = db.TBLEGZERSIZ.Select(k => new Egzersizler
//        {
//            ID = k.ID,
//            EgzersizAdi = k.EgzersizAdi,
//            EgzersizResim = k.EgzersizResim,
//            EgzersizFayda = k.EgzersizFayda,
//            EgzersizSeviye = k.EgzersizSeviye,
//            EgzersizYapilisi = k.EgzersizYapilisi,
//        }).ToList();

//        if (egzersizler.Count == 0)
//        {
//            return NotFound();
//        }

//        return Ok(egzersizler);
//    }
//    catch (Exception e)
//    {
//        HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
//        errorResponse.ReasonPhrase = e.Message;
//        throw new HttpResponseException(errorResponse);
//    }
//}