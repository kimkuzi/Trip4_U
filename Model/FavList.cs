using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FavList:List<Fav>
    {
        public FavList() { }
        public FavList(IEnumerable<Fav> list) : base(list) { }
        public FavList(IEnumerable<BaseEntity> list) : base(list.Cast<Fav>().ToList()) { }
    }
}
