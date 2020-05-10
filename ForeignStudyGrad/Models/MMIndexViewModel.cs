using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels;

namespace ForeignStudyGrad.Models
{
    public class MMIndexViewModel
    {
        public List<CourseModel> Courses;
    }

    public class CourseModel
    {
        public string name { get; set; }
        public Guid id { get; set; }
        public bool ifSubscribed { get; set; }
    }
}
