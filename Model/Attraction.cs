using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Attraction : BaseEntity
    {
        private string attractionName;
        private string desc;
        private City city;
        private string adress;
        private int minAge;
        private Rate rate;
        private string pic;
        private AttractionType atrType;
        private bool summer;
        private bool winter;
        private bool spring;
        private bool fall;

        public string AttractionName { get => attractionName; set => attractionName = value; }
        public string Desc { get => desc; set => desc = value; }
        public City City { get => city; set => city = value; }
        public string Adress { get => adress; set => adress = value; }
        public int MinAge { get => minAge; set => minAge = value; }
        public Rate Rate { get => rate; set => rate = value; }
        public string Pic { get => pic; set => pic = value; }
        public AttractionType AtrType { get => atrType; set => atrType = value; }
        public bool Summer { get => summer; set => summer = value; }
        public bool Winter { get => winter; set => winter = value; }
        public bool Spring { get => spring; set => spring = value; }
        public bool Fall { get => fall; set => fall = value; }
      

        public override string ToString()
        {
           return $"id:{Id}, name:{attractionName}, description:{desc}, city:{city.CityName}, adress:{adress}, min age:{minAge}, rate:{rate.Stars}, pic:{pic} , summer : {summer}, winter:{winter}, spring={spring}, fall={fall}";
        }
    }
}
