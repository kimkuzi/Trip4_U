using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace Trip_4U_ApiService
{
    public interface IApiService
    {
        #region Continent

        public Task<ContinentList> GetAllContinents();
        public Task<int> InsertAContinent(Continent continent);
        public Task<int> UpdateAContinent(Continent continent);
        public Task<int> DeleteAContinent(Continent continent);

        #endregion

        #region Country
        public Task<CountryList> GetAllCountries();
        public Task<int> InsertACountry(Country country);
        public Task<int> UpdateACountry(Country country);
        public Task<int> DeleteACountry(Country country);
        #endregion

        #region City
        public Task<CityList> GetAllCities();
        public Task<int> InsertACity(City city);
        public Task<int> UpdateACity(City city);
        public Task<int> DeleteACity(City city);
        #endregion

        #region Rate
        public Task<RateList> GetAllRates();
        public Task<int> InsertARate(Rate rate);
        public Task<int> UpdateARate(Rate rate);
        public Task<int> DeleteARate(Rate rate);
        #endregion

        #region Person
        public Task<PersonList> GetAllPersons();
        public Task<int> InsertAPerson(Person person);
        public Task<int> UpdateAPerson(Person person);
        public Task<int> DeleteAPerson(Person person);
        #endregion

        #region AtrType
        public Task<AtrTypeList> GetAllTypes();
        public Task<int> InsertAType(AttractionType atrType);
        public Task<int> UpdateAType(AttractionType atrType);
        public Task<int> DeleteAType(AttractionType atrType);
        #endregion

        #region Attraction
        public Task<AttractionList> GetAllAttrctions();
        public Task<int> InsertAAtr(Attraction atr);
        public Task<int> UpdateAAtr(Attraction atr);
        public Task<int> DeleteAAtr(Attraction atr);
        #endregion

        #region Favorite
        public Task<FavList> GetAllFavs();
        public Task<int> InsertAFav(Fav fav);
        public Task<int> UpdateAFav(Fav fav);
        public Task<int> DeleteAFav(Fav fav);
        #endregion

        #region Review
        public Task<ReviewList> GetAllReviews();
        public Task<int> InsertAReview(Review rev);
        public Task<int> UpdateAReview(Review rev);
        public Task<int> DeleteAReview(Review rev);
        #endregion

        #region Wotw
        public Task<WotwList> GetAllWotws();
        public Task<int> InsertAWotw(Wotw wotw);
        public Task<int> UpdateAWotw(Wotw wotw);
        public Task<int> DeleteAWotw(Wotw wotw);
        #endregion
        public Task<HttpResponseMessage> Register(string username,string pass);
        public Task<HttpResponseMessage> LogIn(string username, string pass);

        public Task<string> GetAtrPicByte64(int id);


    }
}
