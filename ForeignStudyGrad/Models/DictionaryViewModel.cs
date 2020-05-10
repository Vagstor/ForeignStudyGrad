using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class DictionaryViewModel
    {
        public List<PairModel> Pairs { get; set; }
    }

    public class PairModel
    { 
        public string Original { get; set; }
        public string Translation { get; set; }
    }
}
