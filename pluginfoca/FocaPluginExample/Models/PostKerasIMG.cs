using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocaPluginExample.Models
{
    class PostKerasIMG
    {
        public string image_path { get; set; }

        public string model_path { get; set; }

        public int image_size { get; set; }

        public int lime { get; set; }
    }
}
