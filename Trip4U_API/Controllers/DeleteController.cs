using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trip4U_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("{id}")]
        [ActionName("DeleteAContinent")]
        public int DeleteAContinent(int id)//עובד
        {
            Continent continent = ContinentDB.SelectById(id);
            ContinentDB db = new ContinentDB();
            db.Delete(continent);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteACountry")]
        public int DeleteACountry(int id)//עובד
        {
            Country country = CountryDB.SelectById(id);
            CountryDB db = new CountryDB();
            db.Delete(country);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteACity")]
        public int DeleteACity(int id)//עובד
        {
            City city = CityDB.SelectById(id);
            CityDB db = new CityDB();
            db.Delete(city);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteARate")]
        public int DeleteARate(int id)//עובד
        {
            Rate rate = RateDB.SelectById(id);
            RateDB db = new RateDB();
            db.Delete(rate);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteAPerson")]
        public int DeleteAPerson(int id)//עובד
        {
            Person person = PersonDB.SelectById(id);
            PersonDB db = new PersonDB();
            db.Delete(person);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteAAtrType")]
        public int DeleteAAtrType(int id)//עובד
        {
            AttractionType atrType = AttractionTypeDB.SelectById(id);
            AttractionTypeDB db = new AttractionTypeDB();
            db.Delete(atrType);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteAAttraction")]
        public int DeleteAAttraction(int id)//עובד
        {
            Attraction atr = AttractionDB.SelectById(id);
            AttractionDB db = new AttractionDB();
            db.Delete(atr);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteAFav")]
        public int DeleteAFav(int id)//עובד
        {
            Fav fav = FavDB.SelectById(id);
            FavDB db = new FavDB();
            db.Delete(fav);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteAReview")]
        public int DeleteAReview(int id)//עובד
        {
            Review review = ReviewDB.SelectById(id);
            ReviewDB db = new ReviewDB();
            db.Delete(review);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteAWotw")]
        public int DeleteAWotw(int id)//עובד
        {
            Wotw wotw = WotwDB.SelectById(id);
            WotwDB db = new WotwDB();
            db.Delete(wotw);
            int x = db.SaveChanges();
            return x;
        }
    }
}
