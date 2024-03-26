using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class ContinentDB : BaseDB
    {
        static private ContinentList list = new ContinentList();

        public ContinentDB():base()
        {
            
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Continent c = entity as Continent;
            c.ContinentName = reader["continentName"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public ContinentList SelectAll()
        {
            command.CommandText = $"SELECT * FROM continentTbl";
            ContinentList cList = new ContinentList(base.Select());
            return cList;

        }


        public static Continent SelectById(int id)
        {
            if (list.Count == 0)
            {
                ContinentDB db = new ContinentDB();
                list = db.SelectAll();
            }
            Continent continent = list.Find(item => item.Id == id);
            return continent;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Continent != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Continent != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Continent != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Continent continent = entity as Continent;
            if (continent != null) 
            {
                string sqlStr = $"INSERT INTO continentTbl (continentName) Values (@cName)";
                command.CommandText = sqlStr ;
                command.Parameters.Add(new OleDbParameter("@cName", continent.ContinentName));

            }
        }
         protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)  
         {
            Continent continent = entity as Continent;
            string sqlStr = $"DELETE FROM continentTbl where id=@cId";
            command.CommandText = sqlStr ;
            command.Parameters.Add(new OleDbParameter("@cId", continent.Id));

         }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Continent continent = entity as Continent;
            string sqlStr = $"UPDATE continentTbl SET continentName=@cName "+
                $"WHERE ID=@cId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cName", continent.ContinentName));
            command.Parameters.Add(new OleDbParameter("@cId", continent.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return  new Continent();
        }
    }
}
