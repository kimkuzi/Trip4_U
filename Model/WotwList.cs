using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WotwList:List<Wotw>
    {
        public WotwList() { }
        public WotwList(IEnumerable<Wotw> list) : base(list) { }
        public WotwList(IEnumerable<BaseEntity> list) : base(list.Cast<Wotw>().ToList()) { }
    }
}
