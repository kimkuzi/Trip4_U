using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Country : BaseEntity
    {
        private Continent continent;
        private string countryName;

        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }
        public Continent Continent
        {
            get { return continent; }
            set { continent = value; }
        }
      
    }
}
