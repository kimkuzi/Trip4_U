using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountryDB:BaseDB
    {
        private static CountryList list = new CountryList();

        public CountryDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Country c = entity as Country;
            c.Continent = ContinentDB.SelectById(int.Parse(reader["continent"].ToString()));
            c.CountryName= reader["country"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public CountryList SelectAll()
        {
            command.CommandText = $"SELECT * FROM countryTbl";
            CountryList cList = new CountryList(base.Select());
            return cList;
        }


        public static Country SelectById(int id)
        {
            if (list.Count == 0)
            {
                CountryDB db = new CountryDB();
                list = db.SelectAll();
            }
            Country country = list.Find(item => item.Id == id);
            return country;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Country != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Country != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Country != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Country country = entity as Country;
            if (country != null)
            {
                string sqlStr = $"INSERT INTO countryTbl (continent,country) Values (@cContinent,@cCountry)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cContinent", country.Continent.Id));
                command.Parameters.Add(new OleDbParameter("@cCountry", country.CountryName));
      
            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Country country = entity as Country;
            string sqlStr = $"DELETE FROM countryTbl where id=@cId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", country.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Country country = entity as Country;

            string sqlStr = $"UPDATE countryTbl SET continent=@cContinent, country=@cCountry WHERE ID =@cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("cContinent", country.Continent.Id));
            command.Parameters.Add(new OleDbParameter("cCountry", country.CountryName));
            command.Parameters.Add(new OleDbParameter("cId", country.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Country();
        }
    }
}
