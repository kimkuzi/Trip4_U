using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trip4U_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("ContinentSelector")]
        public ContinentList SelectAllContinents()//עובד
        {
            ContinentDB db = new ContinentDB();
            ContinentList continents = db.SelectAll();
            return continents;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("CountrySelector")]
        public CountryList SelectAllCountries()//עובד
        {
            CountryDB db = new CountryDB();
            CountryList countries = db.SelectAll();
            return countries;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("CitySelector")]
        public CityList SelectAllCities()//עובד
        {
            CityDB db = new CityDB();
            CityList cities = db.SelectAll();
            return cities;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("RateSelector")]
        public RateList SelectAllRates()//עובד
        {
            RateDB db = new RateDB();
            RateList rates = db.SelectAll();
            return rates;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("PersonSelector")]
        public PersonList SelectAllPersons()//עובד
        {
            PersonDB db = new PersonDB();
            PersonList persons = db.SelectAll();
            return persons;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("TypeSelector")]
        public AtrTypeList SelectAllAtrTypes()//עובד
        {
            AttractionTypeDB db = new AttractionTypeDB();
            AtrTypeList atrTypes = db.SelectAll();
            return atrTypes;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("AttractionSelector")]
        public AttractionList SelectAllAttractions() //עובד
        {
            AttractionDB db = new AttractionDB();
            AttractionList atrs = db.SelectAll();
            return atrs;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("FavSelector")]
        public FavList SelectAllFavs() //עובד
        {
            FavDB db = new FavDB();
            FavList favs = db.SelectAll();
            return favs;
        }

        [HttpGet] //ייחוס - מה אנחנו רוצים לעשות
        [ActionName("ReviewSelector")]
        public ReviewList SelectAllReviews() //עובד
        {
            ReviewDB db = new ReviewDB();
            ReviewList reviews = db.SelectAll();
            return reviews;
        }

        [HttpGet]
        [ActionName("WotwSelector")]
        public WotwList SelectAllWotw()//עובד
        {
            WotwDB db = new WotwDB();
            WotwList wotws = db.SelectAll();
            return wotws;
        }

        [HttpGet("{id}")]
        [ActionName("AtrPicsSelector64Byte")]
        public string AtrPicsSelector64Byte(int id)
        {
            AttractionDB db= new AttractionDB();
            string str=db.SelectAtrPicById(id);
            return str;
        }
    }
}
