using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RateDB : BaseDB
    {
        static private RateList list = new RateList();

        public RateDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Rate r = entity as Rate;
            r.Stars = int.Parse(reader["stars"].ToString());
            base.CreateModel(entity);
            return r;
        }
        public RateList SelectAll()
        {
            command.CommandText = $"SELECT * FROM rateTbl";
            RateList rList = new RateList(base.Select());
            return rList;

        }


        public static Rate SelectById(int id)
        {
            if (list.Count == 0)
            {
                RateDB db = new RateDB();
                list = db.SelectAll();
            }
            Rate stars = list.Find(item => item.Id == id);
            return stars;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Rate != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Rate != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Rate != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Rate rate = entity as Rate;
            if (rate != null)
            {
                string sqlStr = $"INSERT INTO rateTbl (stars) Values (@rStars)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@rStars", rate.Stars));

            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Rate rate = entity as Rate;
            string sqlStr = $"DELETE FROM rateTbl where id=@cId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@rId", rate.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Rate rate = entity as Rate;
            string sqlStr = $"UPDATE rateTbl SET stars=@rStars WHERE ID=@rId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@rStars", rate.Stars));
            command.Parameters.Add(new OleDbParameter("@rId", rate.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Rate();
        }
    }
}
