using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelAPI.Models {
    public class Data {

        public int offset { get; set; }

        public int limit { get; set; }

        public int total { get; set; }

        public int count { get; set; }

        public List<Character> results { get; set; }
    }
}
