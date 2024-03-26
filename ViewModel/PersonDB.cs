using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonDB : BaseDB
    {

        private static PersonList list = new PersonList();

        public PersonDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Person p = entity as Person;
            p.Username = reader["username"].ToString();
            p.Pass = reader["pass"].ToString();
            p.IsAdmin = bool.Parse(reader["isAdmin"].ToString());
            base.CreateModel(entity);
            return p;
        }
        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM personTbl";
            PersonList pList = new PersonList(base.Select());
            return pList; 
        }


        public static Person SelectById(int id)
        {
            if (list.Count == 0)
            {
                PersonDB db = new PersonDB();
                list = db.SelectAll();
            }
            Person person = list.Find(item => item.Id == id);
            return person;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Person != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Person != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Person != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person person = entity as Person;
            if (person != null)
            {
                string sqlStr = $"INSERT INTO personTbl (username,pass,isAdmin) Values (@pUsername,@pPass,@pIsAdmin)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pUsername", person.Username));
                command.Parameters.Add(new OleDbParameter("@pPass", person.Pass));
                command.Parameters.Add(new OleDbParameter("@pIsAdmin", person.IsAdmin));


            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person person = entity as Person;
            string sqlStr = $"DELETE FROM personTbl where id=@pId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@pId", person.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person person = entity as Person;

            string sqlStr = $"UPDATE personTbl SET username=@pUsername, pass=@pPass, isAdmin=@pIsAdmin where id=@pId ";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@pUsername", person.Username));
            command.Parameters.Add(new OleDbParameter("@pPass", person.Pass));
            command.Parameters.Add(new OleDbParameter("@pIsAdmin", person.IsAdmin));
            command.Parameters.Add(new OleDbParameter("@pId", person.Id));

        }

        protected override BaseEntity NewEntity()
        {
            return new Person();
        }
    }
}
