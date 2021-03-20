using FitChildPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitChildPanel.Controllers
{
    public class EgzersizController : Controller
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        // GET: Egzersiz
        public ActionResult Index()
        {
            var egzersizler = db.TBLEGZERSIZ.ToList();
            return View(egzersizler);
        }
    }
}