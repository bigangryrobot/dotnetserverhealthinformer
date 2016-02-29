using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHealthInformer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                using (HttpListener listener = new HttpListener())
                {
                    listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
                    listener.Prefixes.Add("http://localhost:1034/");
                    listener.Start();

                    HttpListenerContext ctx = listener.GetContext();
                    ctx.Response.StatusCode = 200;
                    string name = ctx.Request.QueryString["name"];

                    using (var streamWriter = new StreamWriter(ctx.Response.OutputStream))
                    using (var writer = new JsonTextWriter(streamWriter))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartArray();
                        {
                            // BEGIN serverInfo
                            writer.WriteStartObject();
                            writer.WritePropertyName("serverInfo");
                            writer.WriteStartArray();
                            writer.WriteStartObject();

                            try
                            {
                                writer.WritePropertyName("osVersion");
                                writer.WriteValue(Environment.OSVersion);

                                writer.WritePropertyName("osBitType");
                                if (Environment.Is64BitOperatingSystem)
                                {
                                    writer.WriteValue("64 Bit Operating System");
                                }
                                else
                                {
                                    writer.WriteValue("32 Bit Operating System");
                                }
                                writer.WritePropertyName("SystemDirectory");
                                writer.WriteValue(Environment.SystemDirectory);
                                writer.WritePropertyName("ProcessorCount");
                                writer.WriteValue(Environment.ProcessorCount);
                                writer.WritePropertyName("SystemPageSize");
                                writer.WriteValue(Environment.SystemPageSize);
                                writer.WritePropertyName("Version");
                                writer.WriteValue(Environment.Version);
                            }
                            catch
                            {
                            }

                            writer.WriteEndObject();
                            writer.WriteEndArray();
                            writer.WriteEndObject();
                            // END serverInfo

                            // BEGIN serviceInfo
                            writer.WriteStartObject();
                            writer.WritePropertyName("serviceInfo");
                            writer.WriteStartArray();
                            writer.WriteStartObject();
                            writer.WritePropertyName("zabbixService");
                            writer.WriteValue(DoesServiceExist("zabbix"));
                            writer.WritePropertyName("newrelicService");
                            writer.WriteValue(DoesServiceExist("newrelic"));
                            writer.WritePropertyName("splunkService");
                            writer.WriteValue(DoesServiceExist("splunk"));
                            writer.WritePropertyName("wasService");
                            writer.WriteValue(DoesServiceExist("WAS"));
                            writer.WritePropertyName("w3svcService");
                            writer.WriteValue(DoesServiceExist("W3SVC"));
                            writer.WriteEndObject();
                            writer.WriteEndArray();
                            writer.WriteEndObject();
                            // END serverinfo

                            // BEGIN connectioninfo
                            writer.WriteStartObject();
                            writer.WritePropertyName("connectiondata");
                            writer.WriteStartArray();

                            writer.WriteStartObject();
                            writer.WritePropertyName("name");
                            writer.WriteValue(name);
                            writer.WriteEndObject();

                            foreach (string header in ctx.Request.Headers.Keys)
                            {
                                writer.WriteStartObject();                            
                                writer.WritePropertyName(header);
                                writer.WriteValue(ctx.Request.Headers[header]);
                                writer.WriteEndObject();
                            }
                            writer.WriteEndArray();
                            writer.WriteEndObject();
                            // END connectioninfo

                            // BEGIN iisinfo
                            writer.WriteStartObject();
                            writer.WritePropertyName("iisconfiguration");
                            writer.WriteStartArray();

                            ServerManager mgr = new ServerManager();
                            foreach (Site s in mgr.Sites)
                            {
                                writer.WriteStartObject();
                                writer.WritePropertyName("site");
                                writer.WriteValue(s.Name);
                                writer.WritePropertyName("id");
                                writer.WriteValue(s.Id);
                                writer.WritePropertyName("logFormat");
                                writer.WriteValue(s.LogFile.LogFormat);
                                writer.WritePropertyName("directory");
                                writer.WriteValue(s.LogFile.Directory);
                                writer.WritePropertyName("state");
                                writer.WriteValue(s.State);
                                writer.WritePropertyName("applications");
                                writer.WriteStartArray();
                                foreach (Application app in s.Applications)
                                {
                                    writer.WriteStartObject();
                                    writer.WritePropertyName("vir");
                                    writer.WriteValue(app.Path);
                                    writer.WritePropertyName("virtual dirs");
                                    writer.WriteStartArray();
                                    foreach (VirtualDirectory virtDir in app.VirtualDirectories)
                                    {                                        
                                        writer.WriteValue(virtDir.Path);
                                    }
                                    writer.WriteEndArray();
                                    writer.WriteEndObject();
                                }
                                writer.WriteEndArray();
                                writer.WriteEndObject();
                            }
                            writer.WriteEndArray();
                            writer.WriteEndObject();
                            // END iisinfo


                        }                      
                        writer.WriteEndArray();
                    }
                    ctx.Response.Close();
                    listener.Stop();
                }
            }
            Console.ReadLine();
        }
        public static string DoesServiceExist(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            var service = services.FirstOrDefault(s => s.ServiceName == serviceName);
            if (service == null)
            {
                return "service not installed";
            }
            else {
                return service.Status.ToString();
            }
        }
    }
}
