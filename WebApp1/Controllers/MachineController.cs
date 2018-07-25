using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;
using WebApp1.Processors;

namespace WebApp1.Controllers
{
    public class MachineController : Controller
    {
        string sortBy = "Name";

        // GET: Machine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MachineList()
        {
            List< Machine > machines = MachineProcessor.getMachineAll( sortBy );
            Threshold thresholds = ThresholdProcessor.getThresholds();
            

            ViewBag.Machines = machines;
            ViewBag.Thresholds = thresholds;
            Response.AddHeader( "Refresh", "60" ); // Refresh whole web page every 60 seconds
            return View();
        }

        [HttpPost]
        public ActionResult MachineList( FormCollection form )
        {
            sortBy = form["SortBy"].ToString();

            List<Machine> machines = MachineProcessor.getMachineAll( sortBy );
            Threshold thresholds = ThresholdProcessor.getThresholds();
            

            ViewBag.Machines = machines;
            ViewBag.Thresholds = thresholds;
            Response.AddHeader("Refresh", "60"); // Refresh whole web page every 60 seconds
            return View();
        }

        public ActionResult MachineDetails()
        {
            return View();
        }


        
    }
}