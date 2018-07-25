using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebApp1.Models;

namespace WebApp1.Processors
{
    public class MachineProcessor
    {

        public static List< Machine >  getMachineAll( string sortBy)
        {
            // TODO Do all heavy Processing Here

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create( "http://localhost:43433/api/getMachineAll" );
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            
            HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader( httpWebResponse.GetResponseStream() );

            String result = streamReader.ReadToEnd();

            List<Machine> machines = JsonConvert.DeserializeObject < List<Machine>>( result );
            if( sortBy == "Name" )
            {
                machines = machines.OrderBy(m => m.machineName).ToList();
            }
            else if( sortBy == "CPU" )
            {
                machines = machines.OrderByDescending(m => m.machineStats[0].cpuPercent).ToList();
            }
            else if( sortBy == "RAM" )
            {
                machines = machines.OrderByDescending(m => m.machineStats[0].ramPercent).ToList();
            }
            else if( sortBy == "PercentFree" )
            {
                foreach( Machine machine in machines )
                {
                    machine.smallestDrivePercent = float.MaxValue;
                    foreach( Drive drive in machine.machineStats[0].machineDrives )
                    {
                        if (drive.drivePercent < machine.smallestDrivePercent)
                        {
                            machine.smallestDrivePercent = drive.drivePercent;
                        }
                    }
                }
                machines = machines.OrderBy(m => m.smallestDrivePercent).ToList();
            }
            else if( sortBy == "SpaceFree" )
            {
                foreach (Machine machine in machines)
                {
                    machine.smallestDriveSpace = long.MaxValue;
                    foreach (Drive drive in machine.machineStats[0].machineDrives)
                    {
                        if (drive.driveFree < machine.smallestDriveSpace)
                        {
                            machine.smallestDriveSpace = drive.driveFree;
                        }
                    }
                }
                machines = machines.OrderBy(m => m.smallestDriveSpace).ToList();
            }
            //machines = machines.OrderByDescending( m => m.machineName ).ToList();

            return machines;

        }

        

    }
}