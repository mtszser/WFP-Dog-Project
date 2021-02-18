using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt
{
    class Jurors
    {
        private int id;
        private string name;
        private List<Score> scores;

        public Jurors(int id, string name, List<Score> scores)
        {
            this.id = id;
            this.name = name;
            this.scores = scores;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Score> Scores { get; set; }

    }
}
