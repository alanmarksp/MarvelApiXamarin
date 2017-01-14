using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelAPI.Models {
    public class Result {

        public int code { get; set; }

        public string status { get; set; }

        public Data data { get; set; }
    }
}
