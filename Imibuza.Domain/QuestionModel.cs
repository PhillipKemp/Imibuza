using System;
using Imibuza.Domain.Enums;

namespace Imibuza.Domain
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string FirstWrongAnswer { get; set; }
        public string SecondWrongAnswer { get; set; }
        public string ThirdWrongAnswer { get; set; }
        public string SelectedCategory { get; set; }

        public Question ToDomain()
        {
            return new Question
            {
                TheQuestion = Question,
                CorrectAnswer = CorrectAnswer,
                FirstWrongAnswer = FirstWrongAnswer,
                SecondWrongAnswer = SecondWrongAnswer,
                ThirdWrongAnswer = ThirdWrongAnswer,
                Category = !string.IsNullOrEmpty(SelectedCategory) ? (CategoriesEnum)Enum.Parse(typeof(CategoriesEnum), SelectedCategory) : CategoriesEnum.Other
            };
        }

       
    }
}