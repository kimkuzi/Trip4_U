using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rate:BaseEntity
    {
        private int stars;
        public int Stars
         {
            get { return stars; } 
            set { stars = value; }
        }
    }
}
