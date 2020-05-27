using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prayer_Timings_Schedule_For_Masjid.Models;

namespace Prayer_Timings_Schedule_For_Masjid.Controllers
{
    public class HomeController : Controller
    {
        readonly DataClassesDataContext dc = new DataClassesDataContext();
        
        public ActionResult Index()
        {
            return View(dc.Masjids.Select(a=>a.Area).Distinct().ToList());
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddMasjid()
        {
            ViewBag.Message = "Make Changes Here";

            return View();
        }

        public ActionResult Add()
        {

            string name = Request["name"];
            string address = Request["address"];
            string area = Request["area"];
            string fajar = Request["fajar"] +" : "+ Request["fajar1"]+ " " + Request["fajar2"];
            var zohar = Request["zohar"] + " : " + Request["zohar1"] + " " + Request["zohar2"];
            var asar = Request["asar"] + " : " + Request["asar1"] + " " + Request["asar2"];
            var magrib = Request["magrib"] + " : " + Request["magrib1"] + " " + Request["magrib2"];
            var esha = Request["esha"] + " : " + Request["esha1"] + " " + Request["esha2"];
            Masjid m = new Masjid();
            m.Address = address;
            m.Name = name;
            m.Area = area;
            m.Fajar = fajar;
            m.Zohar = zohar;
            m.Asar = asar;
            m.Magrib = magrib;
            m.Esha = esha;
            dc.Masjids.InsertOnSubmit(m);
            dc.SubmitChanges();

            return RedirectToAction("index");
        }

        public ActionResult ShowData()
        {

            return View(dc.Masjids.Where(a => a.Area == Request["cat"]).ToList());

        }
        public ActionResult Edit(int id)
        { 
            return View(dc.Masjids.First(a=>a.Id==id));

        }

        public ActionResult EditDone(int id)
        {
            var d=dc.Masjids.First(l => l.Id == id);
            d.Name = Request["name"];
            d.Address = Request["address"];
            d.Area = Request["area"];
            var f=Request["fajar"] + " : " + Request["fajar1"] + " " + Request["fajar2"];
            if (Request["fajar"] == "00" && Request["fajar1"] == "00")
            {
                // do nothing!
            }
            else
            {
                d.Fajar = f;
            }
            var z=Request["zohar"] + " : " + Request["zohar1"] + " " + Request["zohar2"];
            if (Request["zohar"] == "00" && Request["zohar1"] == "00")
            {
                // do nothing!
            }
            else
            {
                d.Zohar = z;
            }
            var a=Request["asar"] + " : " + Request["asar1"] + " " + Request["asar2"];
            if (Request["asar"] == "00" && Request["asar1"] == "00" )
            {
                // do nothing!
            }
            else
            {
                d.Asar = a;
            }
            var m = Request["magrib"] + " : " + Request["magrib1"] + " " + Request["magrib2"];
            if (Request["magrib"] == "00" && Request["magrib1"] == "00" )
            {
                // do nothing!
            }
            else
            {
                d.Magrib = m;
            }
            var e=Request["esha"] + " : " + Request["esha1"] + " " + Request["esha2"];
            if (Request["esha"] == "00" && Request["esha1"] == "00" )
            {
                // do nothing!
            }
            else
            {
                d.Esha = e;
            }
            
            dc.SubmitChanges();
            return RedirectToAction("index");

        }



    }
}