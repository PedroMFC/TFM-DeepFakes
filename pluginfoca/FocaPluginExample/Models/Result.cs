using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocaPluginExample.Models
{
    class Result
    {
        public Dictionary<string, string>[] result { get; set; }

        public float perFake { get; set; }

        public float perReal { get; set; }
    }
}
