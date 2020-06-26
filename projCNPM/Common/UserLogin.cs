using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projCNPM.Common
{
    public class UserLogin
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string GroupID { set; get; }
        public bool Issupplier { get; set; }
    }
}