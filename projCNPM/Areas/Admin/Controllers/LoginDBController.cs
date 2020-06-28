using Model.EF;
using PagedList;
using projCNPM.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace projCNPM.Areas.Admin.Controllers
{
    public class LoginDBController : AsyncController
    {
        private OnlineSMSystemDB db = new  OnlineSMSystemDB();
        public List<ClientServer> list = new List<ClientServer>();
        [HttpGet]
        // GET: Admin/LoginDB
        public async Task<ActionResult> Index()
        {

            var ip = IP();

            Session[Common.CommonConstant.SCAN_IP] = list;
            var conten = await ip;
            //           var dbNames = db.Database.SqlQuery<string>(
            //"SELECT name FROM ScanIp").ToList();
            var listname = new List<string>();
            foreach (var item in (List<ClientServer>)Session[Common.CommonConstant.SCAN_IP])
            {
                listname.Add(item.NamePC);

            }
            ViewBag.TenSV = new SelectList(listname);
            return View();
        }
        [HttpPost]
        public ActionResult Index(ClientServer a)
        {
            //            var dbNames = db.Database.SqlQuery<string>(
            //"SELECT name FROM ScanIp").ToList();
            string ipp = null;
            string name = null;
            var listname = new List<string>();
            foreach (var item in (List<ClientServer>)Session[Common.CommonConstant.SCAN_IP])
            {
                listname.Add(item.NamePC);
                if (a.TenSV == item.NamePC)
                {
                    ipp = item.Ip;
                    name = item.NamePC;
                }
            }
            ViewBag.TenSV = new SelectList(listname);
            System.Configuration.Configuration config = null;
            if (System.Web.HttpContext.Current != null)
            {
                config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            }
            else
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }

            // Get the application configuration file.
            //System.Configuration.Configuration config =ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //string Database = "OnlineCafeDB";
            //string Database = "OnlineCafeDB";
            string datab = "dbOnlineSMSystem";


            string coonetionstring = string.Format("Data Source ={0}; Initial Catalog = {1}; User ID = {2}; Password ={3};MultipleActiveResultSets=True;App=EntityFramework", name, datab, a.UserId, a.Pass);


            SQLHelper helper = new SQLHelper(coonetionstring);
            if (helper.InConnection)
            {
                ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
                section.ConnectionStrings["OnlineSMSystemDB"].ConnectionString = System.Web.HttpUtility.HtmlDecode(string.Format("Data Source={0};initial catalog={1};user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework;", name, datab, a.UserId, a.Pass));

                section.ConnectionStrings["OnlineSMSystemDB"].ProviderName = "System.Data.SqlClient";
                config.Save();
                ModelState.AddModelError("", "Thành công");
                //db.Database.ExecuteSqlCommand("sp_clean");
                return RedirectToAction("Index", "Login");
            }
            else 
            {
                 coonetionstring = string.Format("Data Source ={0}; Initial Catalog = {1}; User ID = {2}; Password ={3};MultipleActiveResultSets=True;App=EntityFramework", ipp, datab, a.UserId, a.Pass);
                helper = new SQLHelper(coonetionstring);
                if (helper.InConnection)
                {
                    ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
                    section.ConnectionStrings["OnlineSMSystemDB"].ConnectionString = System.Web.HttpUtility.HtmlDecode(string.Format("Data Source={0};initial catalog={1};user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework;", ipp, datab, a.UserId, a.Pass));

                    section.ConnectionStrings["OnlineSMSystemDB"].ProviderName = "System.Data.SqlClient";
                    config.Save();
                    ModelState.AddModelError("", "Thành công");
                    //db.Database.ExecuteSqlCommand("sp_clean");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                    return View("Index");
                }
            }



        }


        public object lockObj = new object();
        public const bool resolveNames = true;


        public async Task<int> IP()
        {
          string ipaddress= GetLocalIPv4(NetworkInterfaceType.Ethernet);

            if (string.IsNullOrEmpty(ipaddress))
            {
                ipaddress = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            }
            string[] iplist = ipaddress.Split('.');
            string ipBase = "";
            for (int i=0;i<iplist.Length-1;i++)
            {
                ipBase += iplist[i] + ".";

            }
           
            for (int i = 1; i < 255; i++)
            {

                string ip = ipBase + i.ToString();

                Ping p = new Ping();
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);

                p.SendAsync(ip, 10, ip);
            }
            await Task.Delay(3000);
            return 1;
        }
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }


        private void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (resolveNames)
                {
                    ClientServer sc = new ClientServer();
                    string name;
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                        name = hostEntry.HostName;
                    }
                    catch (SocketException ex)
                    {
                        name = "?";
                    }
                    if (name != "?")
                    {

                        sc.Ip = ip;
                        sc.NamePC = name;
                        //db.ScanIps.Add(sc);
                        //db.SaveChanges();
                        list.Add(sc);
                    }


                }

            }

        }
    }
}