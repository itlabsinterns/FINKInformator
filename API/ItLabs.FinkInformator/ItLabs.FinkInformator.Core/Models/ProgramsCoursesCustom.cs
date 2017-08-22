using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.FinkInformator.Core.Models
{
    public class ProgramsCoursesCustom
    {
        public Course Course { get; set; }
        public bool IsMandatory { get; set; }
        public List<Course> Prerequisites { get; set; }
    }
}
