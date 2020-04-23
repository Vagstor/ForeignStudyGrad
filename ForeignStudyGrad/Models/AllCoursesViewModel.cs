using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class AllCoursesViewModel
    {
        public List<CourseModel> courses { get; set; }
        public string searchString { get; set; }
    }
}
