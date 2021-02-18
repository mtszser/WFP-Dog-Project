using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt
{
    class Dogs
    {
        private int id;
        private string name;
        private string breed;
        private string owner;

        public Dogs(int id, string name, string breed, string owner)
        {
            this.id = id;
            this.name = name;
            this.breed = breed;
            this.owner = owner;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }

    }
}
