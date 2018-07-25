using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models
{
    public class Drive
    {
        public string driveName { get; set; }
        public long driveTotal { get; set; }
        public long driveFree { get; set; }
        public float drivePercent { get; set; }
        public string[] getBytes( long totalBytes, long freeBytes )
        {
            string[] answer = new string[ 2 ];
            if(totalBytes == 0 || freeBytes == 0)
            {
                return answer;
            }
            
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

            long bytes = Math.Abs( totalBytes );
            int place = Convert.ToInt32( Math.Floor( Math.Log( bytes, 1024 ) ) );
            double num = Math.Round( bytes / Math.Pow( 1024, place ), 1 );
            answer[ 0 ] = ( Math.Sign( totalBytes ) * num ).ToString() + suf[ place ];

            bytes = Math.Abs( freeBytes );
            place = Convert.ToInt32( Math.Floor( Math.Log( bytes, 1024 ) ) );
            num = Math.Round( bytes / Math.Pow( 1024, place ), 1 );
            answer[ 1 ] = ( Math.Sign( freeBytes ) * num ).ToString() + suf[ place ];

            return answer;
        }
    }
}