using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class CourseViewModel
    {
        public List<ThemeModel> themes { get; set; }
        public string courseName { get; set; }

    }

    public class ThemeModel
    { 
        public string themeName { get; set; }
        public Guid themeId { get; set; }
    }
}