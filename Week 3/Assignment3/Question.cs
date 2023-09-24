using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Question
    {
        public string Riddle { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Answers { get; set; }

        public Question(string riddle, string correctAnswer, string wrongAnswer1, string wrongAnswer2)
        {
            Riddle = riddle;
            CorrectAnswer = correctAnswer;
            Answers = new List<string>
            {
                wrongAnswer1,
                correctAnswer,
                wrongAnswer2
            };
        }

        public override string ToString()
        {
            return $"{Riddle}/{CorrectAnswer}/{Answers[0]}/{Answers[2]}";
        }

        public string DisplayQuestion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Riddle}{Environment.NewLine}{Environment.NewLine}Choices:");
            foreach (string a in Answers)
            {
                sb.Append($"{Environment.NewLine}{a}");
            }
            return sb.ToString();
        }

        public bool CheckAnswer(string playerInput)
        {
            bool isCorrect = playerInput.ToUpper().Trim() == CorrectAnswer.ToUpper().Trim();

            return isCorrect;
        }
    }
}
