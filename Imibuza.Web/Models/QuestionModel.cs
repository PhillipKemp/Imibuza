namespace Imibuza.Web.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string FirstWrongAnswer { get; set; }
        public string SecondWrongAnswer { get; set; }
        public string ThirdWrongAnswer { get; set; }
    }
}