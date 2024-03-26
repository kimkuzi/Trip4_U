using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_project.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        [ActionName("ContinentUpdate")]
        public int UpdateAContinent([FromBody] Continent continent)//עובד
        {
            ContinentDB db = new ContinentDB();
            db.Update(continent);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("CountryUpdate")]
        public int UpdateACountry([FromBody] Country country)//עובד
        {
            CountryDB db = new CountryDB();
            db.Update(country);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("CityUpdate")]
        public int UpdateACity([FromBody] City city)//עובד
        {
            CityDB db = new CityDB();
            db.Update(city);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("RateUpdate")]
        public int UpdateARate([FromBody] Rate rate)//עובד
        {
            RateDB db = new RateDB();
            db.Update(rate);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("PersonUpdate")]
        public int UpdateAPerson([FromBody] Person person)//עובד
        {
            PersonDB db = new PersonDB();
            db.Update(person);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("AtrTypeUpdate")]
        public int UpdateAType([FromBody] AttractionType atrType)//עובד
        {
            AttractionTypeDB db = new AttractionTypeDB();
            db.Update(atrType);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("FavUpdate")]
        public int UpdateAFav([FromBody] Fav fav)//עובד
        {
            FavDB db = new FavDB();
            db.Update(fav);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("ReviewUpdate")]
        public int UpdateAReview([FromBody] Review review)//עובד
        {
            ReviewDB db = new ReviewDB();
            db.Update(review);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        [ActionName("WotwUpdate")]
        public int UpdateAWotw([FromBody] Wotw wotw)//עובד
        {
            WotwDB db = new WotwDB();
            db.Update(wotw);
            int x = db.SaveChanges();
            return x;
        }
    }
}
