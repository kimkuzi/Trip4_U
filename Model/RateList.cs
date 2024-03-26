using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RateList:List<Rate>
    {
        public RateList() { }
        public RateList(IEnumerable<Rate> list) : base(list) { }
        public RateList(IEnumerable<BaseEntity> list) : base(list.Cast<Rate>().ToList()) { }
    }
}
