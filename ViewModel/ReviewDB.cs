using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class ReviewDB:BaseDB
    {
        private static ReviewList list = new ReviewList();

        public ReviewDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Review r = entity as Review;
            r.Attraction = AttractionDB.SelectById(int.Parse(reader["attraction"].ToString()));
            r.ReviewDesc = reader["reviewDesc"].ToString();
            r.ReviewDate = DateOnly.FromDateTime(DateTime.Parse(reader["reviewDate"].ToString()));
            r.User = PersonDB.SelectById(int.Parse(reader["username"].ToString()));
            base.CreateModel(entity);
            return r;
        }
        public ReviewList SelectAll()
        {
            command.CommandText = $"SELECT * FROM reviewTbl";
            ReviewList rList = new ReviewList(base.Select());
            return rList;
        }


        public static Review SelectById(int id)
        {
            if (list.Count == 0)
            {
                ReviewDB db = new ReviewDB();
                list = db.SelectAll();
            }
            Review review = list.Find(item => item.Id == id);
            return review;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Review != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Review != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Review != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Review review = entity as Review;
            if (review != null)
            {
                string sqlStr = $"INSERT INTO reviewTbl (attraction,reviewDesc,reviewDate," +
                    $"username) Values (@rAttraction,@rReviewDesc,@rReviewDate,@rReviewUser)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@rAttraction", review.Attraction.Id));
                command.Parameters.Add(new OleDbParameter("@rReviewDesc", review.ReviewDesc));
                command.Parameters.Add(new OleDbParameter("@rReviewDate", DateTime.Parse(review.ReviewDate.ToString()).Date));
                command.Parameters.Add(new OleDbParameter("@rReviewUser", review.User.Id));

            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Review review = entity as Review;
            string sqlStr = $"DELETE FROM reviewTbl where id=@rId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@rId", review.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Review review = entity as Review;

            string sqlStr = $"UPDATE reviewTbl SET attraction=@rAid, reviewDesc=@rDesc, reviewDate=@rDate, username=@rUser where id=@rId ";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@rAid", review.Attraction.Id));
            command.Parameters.Add(new OleDbParameter("@rDesc", review.ReviewDesc));
            command.Parameters.Add(new OleDbParameter("@rDate", DateTime.Parse(review.ReviewDate.ToString()).Date));
            command.Parameters.Add(new OleDbParameter("@rUser", review.User.Id));
            command.Parameters.Add(new OleDbParameter("@rId", review.Id));


        }

        protected override BaseEntity NewEntity()
        {
            return new Review();
        }
    }
}
