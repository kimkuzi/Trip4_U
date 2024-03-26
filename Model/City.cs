using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City: BaseEntity
    {
        private Country country;
        private string cityName;
       
        public Country Country
        {
             get { return country; }
            set { country = value; }
        }
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }
    }
}
