using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebApp1.Models;

namespace WebApp1.Processors
{
    public class ThresholdProcessor
    {

        public static Threshold getThresholds()
        {
            // TODO Do all heavy Processing Here
            
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create( "http://localhost:43433/api/getThresholds" );
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader( httpWebResponse.GetResponseStream() );

            String result = streamReader.ReadToEnd();

            Threshold thresholds = JsonConvert.DeserializeObject<Threshold>( result );
            return thresholds;
            
            /*
            Threshold thres = new Threshold();
            thres.cpuLimit = new long[2];
            thres.cpuLimit[0] = 80;
            thres.cpuLimit[1] = 90;
            thres.ramLimit = new long[2];
            thres.ramLimit[0] = 80;
            thres.ramLimit[1] = 90;
            thres.freeLimit = new long[2];
            thres.freeLimit[0] = 20;
            thres.freeLimit[1] = 10;
            thres.percentLimit = new long[2];
            thres.percentLimit[0] = 10;
            thres.percentLimit[1] = 5;
            thres.upTimeLimit = new long[2];
            thres.upTimeLimit[0] = 80;
            thres.upTimeLimit[1] = 100;

            return thres;
            */
        }

    }
}