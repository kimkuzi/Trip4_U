using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;


namespace ViewModel
{
    public class CityDB : BaseDB
    {
        private static CityList list = new CityList();

        public CityDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City c = entity as City;
            c.Country = CountryDB.SelectById(int.Parse(reader["country"].ToString()));
            c.CityName = reader["city"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public CityList SelectAll()
        {
            command.CommandText = $"SELECT * FROM cityTbl";
            CityList cList = new CityList(base.Select());
            return cList;
        }


        public static City SelectById(int id)
        {
            if (list.Count == 0)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }
            City city = list.Find(item => item.Id == id);
            return city;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as City != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as City != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as City != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;
            if (city != null)
            {
                string sqlStr = $"INSERT INTO cityTbl (country,city) Values (@cCountry,@cCity)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cCountry", city.Country.Id));
                command.Parameters.Add(new OleDbParameter("@cCity", city.CityName));

            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;
            string sqlStr = $"DELETE FROM cityTbl where id=@cId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", city.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = entity as City;

            string sqlStr = $"UPDATE cityTbl SET country=@cCountry, city=@cCity" +
                $" WHERE ID =@cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("cCountry", city.Country.Id));
            command.Parameters.Add(new OleDbParameter("cCity", city.CityName));
            command.Parameters.Add(new OleDbParameter("cId", city.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new City();
         }
    }
}
