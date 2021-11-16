using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    public class Filter
    {
        List<bool> answers;

        public Filter(int size)
        {
            Answers = new List<bool>();
            for (int i = 0; i < size; i++)
            {
                Answers.Add(false);
            }
        }

        public List<bool> Answers { get => answers; set => answers = value; }
    }
}
