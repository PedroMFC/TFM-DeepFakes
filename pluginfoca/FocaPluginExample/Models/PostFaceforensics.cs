using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocaPluginExample.Models
{
    class PostFaceforensics
    {
        public string video_path { get; set; }

        public string model_path { get; set; }

        public int start_frame { get; set; }

        public int end_frame { get; set; }
    }
}
