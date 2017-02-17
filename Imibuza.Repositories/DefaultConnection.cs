using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imibuza.Domain;

namespace Imibuza.Repositories
{
    public class DefaultConnection : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<SubmittedAnswer> UserAnswers { get; set; }
    }
}
