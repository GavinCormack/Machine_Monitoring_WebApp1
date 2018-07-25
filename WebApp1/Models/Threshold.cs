using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models
{
    public class Threshold
    {
        public long[] upTimeLimit;
        public long[] cpuLimit;
        public long[] ramLimit;
        public long[] freeLimit; // Drive Space Free
        public long[] percentLimit; // Drive % Free

        public string getBytes(long bytesLimit)
        {
            string answer = "0";
            if (bytesLimit == 0)
            {
                return answer;
            }

            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

            long bytes = Math.Abs(bytesLimit);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            answer = (Math.Sign(bytesLimit) * num).ToString() + suf[place];

            return answer;
        }

    }
}