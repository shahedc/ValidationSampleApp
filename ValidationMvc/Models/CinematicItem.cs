using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationMvc.Models
{
    public class CinematicItem
    {
        public int Id { get; set; }

        [Range(1,100)]
        public int Score { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Synopsis { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Available Date")]
        public DateTime AvailableDate { get; set; }

        [Required]
        [DisplayName("Movie/Show/etc")]
        public CIType CIType { get; set; }

    }
}
