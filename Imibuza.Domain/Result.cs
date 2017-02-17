using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imibuza.Domain
{
    public class Result
    {
        public string Category { get; set; }
        public string Value
        {
            get { return "score: " + Correct + "/" + Total + " (" + ((Correct / Total) * 100) + "%)"; }
        }
        public int Correct { get; set; }
        public int Total { get; set; }

        public decimal Percentage
        {
            get { return (Correct / Total) * 100; }
        }


    }
}
