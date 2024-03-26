using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AttractionList:List<Attraction>
    {
        public AttractionList() { }
        public AttractionList (IEnumerable<Attraction> list):base(list) { }
        public AttractionList(IEnumerable<BaseEntity> list):base(list.Cast<Attraction>().ToList()) { }
    }
}
