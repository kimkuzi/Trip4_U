using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;
using ViewModel;

namespace ViewModel
{
    public class FavDB : BaseDB
    {
        private static FavList list = new FavList();

        public FavDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Fav f = entity as Fav;
            f.User = PersonDB.SelectById(int.Parse(reader["username"].ToString()));
            f.Attraction =AttractionDB.SelectById(int.Parse(reader["attraction"].ToString()));
            f.DateAdded = DateOnly.FromDateTime(DateTime.Parse(reader["dateAdded"].ToString()));
            base.CreateModel(entity);
            return f;
        }
        public FavList SelectAll()
        {
            command.CommandText = $"SELECT * FROM favTbl";
            FavList fList = new FavList(base.Select());
            return fList;
        }


        public static Fav SelectById(int id)
        {
            if (list.Count == 0)
            {
                FavDB db = new FavDB();
                list = db.SelectAll();
            }
            Fav fav = list.Find(item => item.Id == id);
            return fav;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Fav != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Fav != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Fav != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Fav f = entity as Fav;
            if (f != null)
            {
                string sqlStr = $"INSERT INTO favTbl (username,attraction,dateAdded) Values (@fUser,@fAtr,@fDateAAdd)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@fUser", f.User.Id));
                command.Parameters.Add(new OleDbParameter("@fAtr", f.Attraction.Id));
                command.Parameters.Add(new OleDbParameter("@fDateAAdd", DateTime.Parse(f.DateAdded.ToString()).Date));


            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Fav f = entity as Fav;
            string sqlStr = $"DELETE FROM favTbl where id=@fId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@fId", f.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Fav f = entity as Fav;

            string sqlStr = $"UPDATE favTbl SET username=@fUser, attraction=@fAtr, dateAdded=@fDateAAdd WHERE ID =@fId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@fUser", f.User.Id));
            command.Parameters.Add(new OleDbParameter("@fAtr", f.Attraction.Id));
            command.Parameters.Add(new OleDbParameter("@fDateAAdd", DateTime.Parse(f.DateAdded.ToString()).Date));
            command.Parameters.Add(new OleDbParameter("@fId", f.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Fav();
        }
    }
}
