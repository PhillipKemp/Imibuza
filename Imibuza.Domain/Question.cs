using Imibuza.Domain.Enums;

namespace Imibuza.Domain
{
    public class Question
    {
        public int id { get; set; }
        public string TheQuestion { get; set; }
        public string CorrectAnswer { get; set; }
        public string FirstWrongAnswer { get; set; }
        public string SecondWrongAnswer { get; set; }
        public string ThirdWrongAnswer { get; set; }
        public CategoriesEnum Category { get; set; }
    }
}