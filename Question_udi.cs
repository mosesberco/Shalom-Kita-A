using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Question_udi
    {
        private int num1, num2, correctAnswer;
        private string op;
        public Question_udi(int num1, int num2, string op)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.op = op;
            if (op == "+")
                correctAnswer = num1 + num2;
            else if (op == "-")
            {
                this.num1 = Math.Max(num1, num2);
                this.num2 = Math.Min(num1, num2);
                this.correctAnswer = this.num1 - this.num2;
            }
            else
                throw new ArgumentException("empty operator");
        }
        public static Question_udi[] generateQuestions(int count)
        {
            Random random = new Random();
            List<Question_udi> questions = new List<Question_udi>();
            string[] ops = { "+", "-" };
            while (questions.Count < count)            //Questions generator
            {
                int num1 = random.Next(1, 11);
                int num2 = random.Next(1, 11);
                string op = ops[random.Next(ops.Length)];

                Question_udi newQuestion = new Question_udi(num1, num2, op);

                if (!questions.Any(q => q.IsSimilar(newQuestion)))
                {
                    questions.Add(newQuestion);
                }
            }
            return questions.ToArray();
        }
        public bool IsSimilar(Question_udi other)
        {
            return this.op == other.op &&
                   ((this.num1 == other.num1 && this.num2 == other.num2) ||
                    (this.num1 == other.num2 && this.num2 == other.num1 && this.op == "+"));
        }

        public int getNum1() { return this.num1; }
        public int getNum2() { return this.num2; }
        public int getCorrectAnswer() { return this.correctAnswer; }
        public string toString() { return $"{this.num1}" + op + $"{this.num2} = ?"; }
    }
}

