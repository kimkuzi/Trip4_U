using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_project.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        [HttpPost]
        [ActionName("ContinentInsert")]
        public int InsertAContinent([FromBody] Continent continent) //עובד
        {
            ContinentDB db = new ContinentDB();
            db.Insert( continent );
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("CountryInsert")]
        public int InsertACountry([FromBody] Country country)//עובד
        {
            CountryDB db = new CountryDB();
            db.Insert(country);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("CityInsert")]
        public int InsertACity([FromBody] City city)//עובד
        {
            CityDB db = new CityDB();
            db.Insert(city);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("RateInsert")]
        public int InsertARate([FromBody] Rate rate)//עובד
        {
            RateDB db = new RateDB();
            db.Insert(rate);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("PersonInsert")]
        public int InsertAPerson([FromBody] Person person)//עובד
        {
            PersonDB db = new PersonDB();
            db.Insert(person);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("TypeInsert")]
        public int InsertAType([FromBody] AttractionType atrType)//עובד
        {
            AttractionTypeDB db = new AttractionTypeDB();
            db.Insert(atrType);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("AttractionInsert")]
        public int InsertAAttraction([FromBody] Attraction atr)//עובד
        {
            AttractionDB db = new AttractionDB();
            db.Insert(atr);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("FavInsert")]
        public int InsertAFav([FromBody] Fav fav)//עובד
        {
            FavDB db = new FavDB();
            db.Insert(fav);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("ReviewInsert")]
        public int InsertAReview([FromBody] Review rev)//עובד
        {
            ReviewDB db = new ReviewDB();
            db.Insert(rev);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("WotwInsert")]
        public int InsertAWotw([FromBody] Wotw wotw)//עובד
        {
            WotwDB db = new WotwDB();
            db.Insert(wotw);
            int x = db.SaveChanges();
            return x;
        }
    }
}
