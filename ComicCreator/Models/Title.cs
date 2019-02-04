using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicCreator.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public byte[] TitleImageContent { get; set; }

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string TitleImageMimeType { get; set; }

        [StringLength(100, ErrorMessage = "The name cannont be longer than 100 characters")]
        [Display(Name = "File Name")]
        [ScaffoldColumn(false)]
        public string TitleImageFileName { get; set; }
    }
}
