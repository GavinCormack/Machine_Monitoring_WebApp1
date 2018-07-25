
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models
{
    public class Machine
    {
        [BsonId]
        [BsonRepresentation( BsonType.ObjectId )]
        public string _id { get; set; }
        public string machineName { get; set; }
        public string machineIp { get; set; }
        public string machineUpTime { get; set; }
        public List<Stats> machineStats { get; set; }

        public long smallestDriveSpace { get; set; }
        public float smallestDrivePercent { get; set; }

        public long getDays( string upTime )
        {
            string days = upTime.Substring( 0, upTime.IndexOf( ":" ) );
            return long.Parse( days );
        }
    }
}