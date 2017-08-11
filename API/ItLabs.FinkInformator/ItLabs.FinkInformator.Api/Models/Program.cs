using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Api.Models
{
   public class Program
    {
        [Required]
        public int ProgramId { get; set; }

        [Required]
        [MaxLength(5)]
        public string ProgramName { get; set; }

        public IEnumerable<ProgramsCourses> ProgramsCourses { get; set; }
    }
}