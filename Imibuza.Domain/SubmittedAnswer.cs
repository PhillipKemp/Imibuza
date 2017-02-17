using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imibuza.Domain
{
    public class SubmittedAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public bool Correct { get; set; }
        public DateTime CreatedOn = DateTime.Now;
    }
}
