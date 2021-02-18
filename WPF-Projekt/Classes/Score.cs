using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt
{
    class Score
    {
        private double outfit;
        private double speed;
        private double focus;

        public Score(double outfit, double speed, double focus)
        {
            this.outfit = outfit;
            this.speed = speed;
            this.focus = focus;
        }
        public double Outfit { get; set; }
        public double Speed { get; set; }
        public double Focus { get; set; }
    }
}
