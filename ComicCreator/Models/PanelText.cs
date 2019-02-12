using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicCreator.Models
{
    public class PanelText
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string TextContent { get; set; }
        public double? TailX { get; set; }
        public double? TailY { get; set; }
        public string TextClass { get; set; }

        public int PanelId { get; set; }
        public virtual Panel Panel { get; set; }
    }
}
