using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AtrTypeList:List<AttractionType>    
    {
        public AtrTypeList() { }
        public AtrTypeList(IEnumerable<AttractionType> list) : base(list) { }
        public AtrTypeList(IEnumerable<BaseEntity> list) : base(list.Cast<AttractionType>().ToList()) { }
    }
}
