using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModel;

namespace Trip_4U_ApiService
{
    public class ApiService : IApiService
    {
        HttpClient client;
        string uri;
        public ApiService()
        {
            client = new HttpClient();//חיבור לשרת
            uri = "http://localhost:5257/api/";
        }
        #region Continent
        public async Task<ContinentList> GetAllContinents()
        {
            ContinentList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<ContinentList>(uri + "Select/ContinentSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAContinent(Continent continent)
        {
            var x = await client.PostAsJsonAsync<Continent>(uri + "Insert/ContinentInsert", continent); 
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAContinent(Continent continent)
        { 
            var x = await client.PutAsJsonAsync<Continent>(uri + "Update/ContinentUpdate", continent);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAContinent(Continent continent)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAContinent/" + continent.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Country
        public async Task<CountryList> GetAllCountries()
        {
            CountryList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<CountryList>(uri + "Select/CountrySelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }
        public async Task<int> InsertACountry(Country country)
        {
            var x = await client.PostAsJsonAsync<Country>(uri + "Insert/CountryInsert", country);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateACountry(Country country)
        {
            var x = await client.PutAsJsonAsync<Country>(uri + "Update/CountryUpdate", country);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteACountry(Country country)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteACountry/" + country.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region City
        public async Task<CityList> GetAllCities()
        {
            CityList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<CityList>(uri + "Select/CitySelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }
        public async Task<int> InsertACity(City city)
        {
            var x = await client.PostAsJsonAsync<City>(uri + "Insert/CityInsert", city);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateACity(City city)
        {
            var x = await client.PutAsJsonAsync<City>(uri + "Update/CityUpdate", city);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteACity(City city)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteACity/" + city.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Rate
        public async Task<RateList> GetAllRates()
        {
            RateList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<RateList>(uri + "Select/RateSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }
        public async Task<int> InsertARate(Rate rate)
        {
            var x = await client.PostAsJsonAsync<Rate>(uri + "Insert/RateInsert", rate);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateARate(Rate rate)
        {
            var x = await client.PutAsJsonAsync<Rate>(uri + "Update/RateUpdate", rate);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteARate(Rate rate)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteARate/" + rate.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Person
        public async Task<PersonList> GetAllPersons()
        {
            PersonList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<PersonList>(uri + "Select/PersonSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAPerson(Person person)
        {
            var x = await client.PostAsJsonAsync<Person>(uri + "Insert/PersonInsert", person);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAPerson(Person person)
        {
            var x = await client.PutAsJsonAsync<Person>(uri + "Update/PersonUpdate", person);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAPerson(Person person)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAPerson/" + person.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Attraction Type
        public async Task<AtrTypeList> GetAllTypes()
        {
            AtrTypeList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<AtrTypeList>(uri + "Select/TypeSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAType(AttractionType atrType)
        {
            var x = await client.PostAsJsonAsync<AttractionType>(uri + "Insert/TypeInsert", atrType);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAType(AttractionType atrType)
        {
            var x = await client.PutAsJsonAsync<AttractionType>(uri + "Update/AtrTypeUpdate", atrType);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAType(AttractionType atrType)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAAtrType/" + atrType.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Attraction
        public async Task<AttractionList> GetAllAttrctions()
        {
            AttractionList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<AttractionList>(uri + "Select/AttractionSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAAtr(Attraction atr)
        {
            var x = await client.PostAsJsonAsync<Attraction>(uri + "Insert/AttractionInsert", atr);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAAtr(Attraction atr)
        {
            var x = await client.PutAsJsonAsync<Attraction>(uri + "Update/AttractionUpdate", atr);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAAttraction(Attraction atr)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAAttraction/" + atr.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Fav
        public async Task<FavList> GetAllFavs()
        {
            FavList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<FavList>(uri + "Select/FavSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAFav(Fav fav)
        {
            var x = await client.PostAsJsonAsync<Fav>(uri + "Insert/FavInsert", fav);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAFav(Fav fav)
        {
            var x = await client.PutAsJsonAsync<Fav>(uri + "Update/FavUpdate", fav);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAFav(Fav fav)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAFav/" + fav.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Review
        public async Task<ReviewList> GetAllReviews()
        {
            ReviewList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<ReviewList>(uri + "Select/ReviewSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAReview(Review review)
        {
            var x = await client.PostAsJsonAsync<Review>(uri + "Insert/ReviewInsert", review);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAReview(Review review)
        {
            var x = await client.PutAsJsonAsync<Review>(uri + "Update/ReviewUpdate", review);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAReview(Review review)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAReview/" + review.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        #endregion

        #region Wotw
        public async Task<WotwList> GetAllWotws()
        {
            WotwList lst = null;
            try
            {
                lst = await client.GetFromJsonAsync<WotwList>(uri + "Select/WotwSelector");//המרה מג'ייסון לרשימת עצמים
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lst;
        }

        public async Task<int> InsertAWotw(Wotw wotw)
        {
            var x = await client.PostAsJsonAsync<Wotw>(uri + "Insert/WotwInsert", wotw);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> UpdateAWotw(Wotw wotw)
        {
            var x = await client.PutAsJsonAsync<Wotw>(uri + "Update/WotwUpdate", wotw);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
        public async Task<int> DeleteAWotw(Wotw wotw)
        {
            var x = await client.DeleteAsync(uri + "Delete/DeleteAWotw/" + wotw.Id);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public Task<int> DeleteAAtr(Attraction atr)
        {
            throw new NotImplementedException();
        }

 
        #endregion
        public async Task<HttpResponseMessage> Register (string username,string pass)
        {
            var x = await client.PostAsJsonAsync<object>(uri + "Insert/Register", new {Username=username,Pass=pass});
            return x;
        }
        public async Task<HttpResponseMessage> LogIn(string username, string pass)
        {
            var x = await client.PostAsJsonAsync<object>(uri + "Insert/LogIn", new { Username = username, Pass = pass });
            return x;
        }
        public async Task<string> GetAtrPicByte64(int id)
        {
            string st = null;
            string URI = uri + "Select/AtrPicsSelector64Byte/" + id;
            HttpResponseMessage response = await client.GetAsync(URI);
            if(response.IsSuccessStatusCode) 
            {
                string json  =await response.Content.ReadAsStringAsync();
                json = '"' + json + '"';
                try
                {
                    st = JsonSerializer.Deserialize<string>(json);
                }
                catch(Exception ex) { }
            }
            return st;
        }
    }

}

