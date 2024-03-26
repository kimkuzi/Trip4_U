using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContinentList:List<Continent>
    {
        public ContinentList() { }
        public ContinentList(IEnumerable<Continent> list) : base(list) { }
        public ContinentList(IEnumerable<BaseEntity> list) : base(list.Cast<Continent>().ToList()) { }
    }
}
