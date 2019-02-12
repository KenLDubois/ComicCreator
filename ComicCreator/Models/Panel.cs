using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicCreator.Models
{
    public class Panel
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        [ScaffoldColumn(false)]
        public byte[] PanelImageContent { get; set; }

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string PanelImageMimeType { get; set; }

        [StringLength(100, ErrorMessage = "The name cannont be longer than 100 characters")]
        [Display(Name = "File Name")]
        [ScaffoldColumn(false)]
        public string PanelImageFileName { get; set; }

        public int IssueId { get; set; }
        public virtual Issue Issue { get; set; }

        public ICollection<PanelText> PanelTexts { get; set; }

    }
}
