using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wotw:Attraction
    {
        private DateOnly discoverDate;

        public DateOnly DiscoverDate { get => discoverDate; set => discoverDate = value; }
    }
}
