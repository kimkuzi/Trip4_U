using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ViewModel
{
    public class AttractionTypeDB : BaseDB
    {
        static private AtrTypeList list = new AtrTypeList();

        public AttractionTypeDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            AttractionType t = entity as AttractionType;
            t.AtrType = reader["atrType"].ToString();
            base.CreateModel(entity);
            return t;
        }
        public AtrTypeList SelectAll()
        {
            command.CommandText = $"SELECT * FROM typeTbl";
            AtrTypeList tList = new AtrTypeList(base.Select());
            return tList;

        }


        public static AttractionType SelectById(int id)
        {
            if (list.Count == 0)
            {
                AttractionTypeDB db = new AttractionTypeDB();
                list = db.SelectAll();
            }
            AttractionType atrType = list.Find(item => item.Id == id);
            return atrType;
        }

        public override void Insert(BaseEntity entity)
        {
            if (entity as AttractionType != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as AttractionType != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as AttractionType != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AttractionType atrType = entity as AttractionType;
            if (atrType != null)
            {
                string sqlStr = $"INSERT INTO typeTbl (atrType) Values (@aType)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@aType", atrType.AtrType));

            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AttractionType atrType = entity as AttractionType;
            string sqlStr = $"DELETE FROM typeTbl where id=@tId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@tId", atrType.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            AttractionType atrType = entity as AttractionType;
            string sqlStr = $"UPDATE typeTbl SET atrType=@atrType WHERE ID=@aId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@atrType", atrType.AtrType));

            command.Parameters.Add(new OleDbParameter("@aId", atrType.Id));
        }


        protected override BaseEntity NewEntity()
        {
            return new AttractionType();
        }
    }
}
