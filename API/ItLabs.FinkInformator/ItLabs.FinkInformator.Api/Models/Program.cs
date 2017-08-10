using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Api.Models
{
   public class Program
    {
        [Required]
        public int ProgramId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProgramName { get; set; }
       
    }
}