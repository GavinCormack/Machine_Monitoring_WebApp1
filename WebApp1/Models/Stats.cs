using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models
{
    public class Stats
    {
        public DateTime currentTime { get; set; }
        public float cpuPercent { get; set; }
        public float ramPercent { get; set; }
        public List<Drive> machineDrives { get; set; }
    }
}