using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CountryList:List<Country>
    {
        public CountryList() { }
        public CountryList(IEnumerable<Country> list) : base(list) { }
        public CountryList(IEnumerable<BaseEntity> list) : base(list.Cast<Country>().ToList()) { }
    }
}
