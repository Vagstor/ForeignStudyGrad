using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class CoursViewModel
    {
        public List<ThemeModel> themes { get; set; }

    }

    public class ThemeModel
    { 
        public string themeName { get; set; }
        //public Guid currentCourse { get; set; }
    }
}