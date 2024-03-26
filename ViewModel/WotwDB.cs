using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class WotwDB:AttractionDB
    {
        private static WotwList list = new WotwList();

        public WotwDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Wotw w = entity as Wotw;
            w.DiscoverDate = DateOnly.FromDateTime(DateTime.Parse(reader["discoverDate"].ToString()));
            //DateOnly.FromDateTime - בגלל שבאקסס השדה מוגדר תאריך/שעה, ואנחנו רוצים רק את השעה
            //dateonly-> תאריך בלבד
            base.CreateModel(entity);
            return w;
        }
        public WotwList SelectAll()
        {
            command.CommandText = "SELECT wotwTbl.id, wotwTbl.discoverDate,  attractionTbl.attractionName, attractionTbl.descr, attractionTbl.city, attractionTbl.adress, attractionTbl.minAge, attractionTbl.rate, attractionTbl.pic, attractionTbl.type, attractionTbl.summer, attractionTbl.winter, attractionTbl.spring, attractionTbl.fall, wotwTbl.id AS id FROM  (wotwTbl INNER JOIN attractionTbl ON attractionTbl.id = wotwTbl.id)";
            WotwList wList = new WotwList(base.Select());
            return wList;
        }


        public static Wotw SelectById(int id)
        {
            if (list.Count == 0)
            {
                WotwDB db = new WotwDB();
                list = db.SelectAll();
            }
            Wotw wotw = list.Find(item => item.Id == id);
            return wotw;
        }
        public  void InsertCombined(BaseEntity entity)
        {

            if (entity as Wotw != null)

            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity)); //ירושה - יוצרים קודם בATTRACTION 
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public  void DeleteCombined(BaseEntity entity)
        {
            if (entity as Wotw != null)

            {
                
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity)); //ירושה -
            }
        }
        public  void UpdateCombined(BaseEntity entity)
        {
            if (entity as Wotw != null)

            {
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Wotw != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Wotw != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Wotw != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Wotw w = entity as Wotw;
            if (w != null)
            {
                string sqlStr = $"INSERT INTO wotwTbl (id,discoverDate) Values (@wId,@wdDate)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@wId",w.Id));
                command.Parameters.Add(new OleDbParameter("@wdDate",DateTime.Parse(w.DiscoverDate.ToString()).Date));
               

            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Wotw wotw = entity as Wotw;
            string sqlStr = $"DELETE FROM wotwTbl where id=@wId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@wId", wotw.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Wotw w = entity as Wotw;

            string sqlStr = $"UPDATE wotwTbl SET discoverDate=@wDdate where id=@wId ";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@wDdate", DateTime.Parse(w.DiscoverDate.ToString()).Date));
            command.Parameters.Add(new OleDbParameter("@wId", w.Id));

        }

        protected override BaseEntity NewEntity()
        {
            return new Wotw();
        }
    }
}
