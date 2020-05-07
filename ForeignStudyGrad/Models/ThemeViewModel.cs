using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class ThemeViewModel
    {
        //public List<LectureModel> lectures { get; set; }
        //public List<TestModel> tests { get; set; }
        public string Themename { get; set; }
        public string Goal { get; set; }
        public string Link { get; set; }
        public List<TranslationPairs> DictionaryList { get; set; }
    }

    public class TranslationPairs
    { 
        public string Word { get; set; }
        public string Translation { get; set; }
    }

    //public class LectureModel
    //{ 
    //    public Guid lectureid { get; set; }
    //    public string lecturename { get; set; }
    //    public string lecturefile { get; set; }
    //}

    //public class TestModel
    //{ 
    //    public Guid testid { get; set; }
    //    public string testname { get; set; }
    //}
}
