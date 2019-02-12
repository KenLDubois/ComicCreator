using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicCreator.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public int? IssueNumber { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [StringLength(100, ErrorMessage = "The name cannont be longer than 100 characters")]
        [Display(Name = "Title Name")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public byte[] CoverImageContent { get; set; }

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string CoverImageMimeType { get; set; }

        [StringLength(100, ErrorMessage = "The name cannont be longer than 100 characters")]
        [Display(Name = "File Name")]
        [ScaffoldColumn(false)]
        public string CoverImageFileName { get; set; }

        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

        public ICollection<Panel> Panels { get; set; }
    }
}
