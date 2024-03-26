using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fav:BaseEntity
    {
        private Person user;
        private Attraction attraction;
        private DateOnly dateAdded;

        public Person User { get => user; set => user = value; }
        public Attraction Attraction { get => attraction; set => attraction = value; }
        public DateOnly DateAdded { get => dateAdded; set => dateAdded = value; }
    }
}
