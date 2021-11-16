using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    class Question
    {
        string name;
        string leftAnswer;
        string rightAnswer;
        int leftPath;
        int rightPath;

        public Question(string question, string leftAnswer, string rightAnswer, int leftPath, int rightPath)
        {
            this.Name = question;
            this.LeftAnswer = leftAnswer;
            this.RightAnswer = rightAnswer;
            this.LeftPath = leftPath;
            this.RightPath = rightPath;
        }

        public string Name { get => name; set => name = value; }
        public string LeftAnswer { get => leftAnswer; set => leftAnswer = value; }
        public string RightAnswer { get => rightAnswer; set => rightAnswer = value; }
        public int LeftPath { get => leftPath; set => leftPath = value; }
        public int RightPath { get => rightPath; set => rightPath = value; }

        public override string ToString()
        {
            return Name+" "+LeftAnswer+" "+RightAnswer+" "+LeftPath+" "+RightPath;
        }
    }
}
