using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class DictionaryViewModel
    {
        public List<Pair> Pairs { get; set; }
    }

    public class Pair
    { 
        public string Original { get; set; }
        public string Translation { get; set; }
    }
}
