using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bene_hack_api.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public int password { get; set; }
    }
}