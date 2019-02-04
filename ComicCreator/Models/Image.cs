using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicCreator.Models
{
    public abstract class Image
    {
        [ScaffoldColumn(false)]
        public byte[] ImageContent { get; set; } 

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string ImageMimeType { get; set; }

        [StringLength(100, ErrorMessage = "The name cannont be longer than 100 characters")]
        [Display(Name = "File Name")]
        [ScaffoldColumn(false)]
        public string ImageFileName { get; set; }
    }
}
