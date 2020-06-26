using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projCNPM.Areas.Admin.Models
{
    public class ClientServer
    {
        public string TenSV { get; set; }

        public string matkhau { get; set; }
        public string Datasource { get; set; }
        public string iniCata { get; set; }
        public string UserId { get; set; }

        public string Pass { get; set; }
        public string Ip { get; set; }
        public string NamePC { get; set; }
    }
}