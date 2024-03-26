using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Review: BaseEntity
    {
        private Attraction attraction;
        private string reviewDesc;
        private DateOnly reviewDate;
        private Person user;

        public Attraction Attraction { get => attraction; set => attraction = value; }
        public string ReviewDesc { get => reviewDesc; set => reviewDesc = value; }
        public DateOnly ReviewDate { get => reviewDate; set => reviewDate = value; }
        public Person User { get => user; set => user = value; }
    }
}
