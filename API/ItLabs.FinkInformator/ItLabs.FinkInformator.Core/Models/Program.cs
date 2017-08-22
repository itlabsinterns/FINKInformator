using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Core.Models
{
    /// <summary>
    /// Program
    /// </summary>
   public class Program
    {
        /// <summary>
        /// ID of the program
        /// </summary>
        [Required]
        public int ProgramId { get; set; }

        /// <summary>
        /// Name of the program
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ProgramName { get; set; }

        public IEnumerable<ProgramsCourses> ProgramsCourses { get; set; }
    }
}