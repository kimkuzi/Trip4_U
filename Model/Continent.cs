using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Continent:BaseEntity
    {
        private string continentName;
        
        public string ContinentName
        {
            get { return continentName; }   
            set { continentName = value; }
        }
    }
}
