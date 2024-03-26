using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class AttractionDB:BaseDB
    {
        private static AttractionList list = new AttractionList();

        public AttractionDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Attraction a = entity as Attraction;
            a.AttractionName = reader["attractionName"].ToString();
            a.Desc= reader["descr"].ToString();
            a.City = CityDB.SelectById(int.Parse(reader["city"].ToString()));
            a.Adress = reader["adress"].ToString();
            a.MinAge = int.Parse(reader["minAge"].ToString());
            a.Rate = RateDB.SelectById(int.Parse(reader["rate"].ToString()));
           string imagePath = "C:\\Users\\Kim\\OneDrive\\שולחן העבודה\\kim\\School\\רותי\\פרויקט מעודכן חודש מרץ\\Trip4_U\\ViewModel\\AtrPics\\" + reader["pic"].ToString();
            string base64String = ImageToBase64Converter.ImageToBase64(imagePath);
            a.Pic = base64String;
            a.AtrType = AttractionTypeDB.SelectById(int.Parse(reader["type"].ToString()));
            a.Summer = bool.Parse(reader["summer"].ToString());
            a.Winter = bool.Parse(reader["winter"].ToString());
            a.Spring = bool.Parse(reader["spring"].ToString());
            a.Fall = bool.Parse(reader["fall"].ToString());
            base.CreateModel(entity);
            return a;
        }
        public class ImageToBase64Converter
        {
            public static string ImageToBase64(string imagePath)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error converting image to base64 "+ex.Message);
                    return null;
                }
            }
        }
        public string SelectAtrPicById(int id)
        {
            AttractionList aList = SelectAll();
            Attraction atr = aList.Find(x=> x.Id == id);
            string pic = atr.Pic;
            return pic;
        }
        public AttractionList SelectAll()
        {
            command.CommandText = $"SELECT * FROM attractionTbl";
            AttractionList aList = new AttractionList(base.Select());
            return aList;
        }


        public static Attraction SelectById(int id)
        {
            if (list.Count == 0)
            {
                AttractionDB db = new AttractionDB();
                list = db.SelectAll();
            }
            Attraction attraction = list.Find(item => item.Id == id);
            return attraction;
        }
        public override void Insert(BaseEntity entity)
        {
            if (entity as Attraction != null)

            {
                inserted.Add(new ChangeEntity(CreateInsertSQL, entity));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            if (entity as Attraction != null)

            {
                deleted.Add(new ChangeEntity(CreateDeletedSQL, entity));
            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as Attraction != null)

            {
                updated.Add(new ChangeEntity(CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Attraction attraction = entity as Attraction;
            if (attraction != null)
            {
                string sqlStr = $"INSERT INTO attractionTbl (attractionName,descr,city," +
                    $"adress,minAge,rate,pic,type,summer,winter,spring,fall) Values (@aAttraction,@aDescr," +
                    $"@aCity,@aAdress,@aMinAge,@aRate,@aPic,@aType,@aSummer,@aWinter,@aSpring,@aFall)";
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@aAttraction", attraction.AttractionName));
                command.Parameters.Add(new OleDbParameter("@aDescr",attraction.Desc));
                command.Parameters.Add(new OleDbParameter("@aCity", attraction.City.Id));
                command.Parameters.Add(new OleDbParameter("@aAdress", attraction.Adress));
                command.Parameters.Add(new OleDbParameter("@aMinAge", attraction.MinAge));
                command.Parameters.Add(new OleDbParameter("@aRate", attraction.Rate.Id));
                command.Parameters.Add(new OleDbParameter("@aPic", attraction.Pic));
                command.Parameters.Add(new OleDbParameter("@aType", attraction.AtrType.Id));
                command.Parameters.Add(new OleDbParameter("@aSummer", attraction.Summer));
                command.Parameters.Add(new OleDbParameter("@aWinter", attraction.Winter));
                command.Parameters.Add(new OleDbParameter("@aSpring", attraction.Spring));
                command.Parameters.Add(new OleDbParameter("@aFall", attraction.Fall));



            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Attraction atr = entity as Attraction;
            string sqlStr = $"DELETE FROM attractionTbl where id=@aId";
            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@aId", atr.Id));

        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Attraction atr = entity as Attraction;

            string sqlStr = $"UPDATE attractionTbl SET attractionName=@aName, descr=@aDescr, city=@aCity, adress=@aAdress,minAge=@aMinAge," +
                $" rate=@aRate, pic=@aPic, type=@aType, summer=@aSummer, winter=@aWinter, spring=@aSpring, fall=@aFall" +
                $" WHERE ID=@aId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("aName", atr.AttractionName));
            command.Parameters.Add(new OleDbParameter("aDescr", atr.Desc));
            command.Parameters.Add(new OleDbParameter("aCity", atr.City.Id));
            command.Parameters.Add(new OleDbParameter("aAdress", atr.Adress));
            command.Parameters.Add(new OleDbParameter("aMinAge", atr.MinAge));
            command.Parameters.Add(new OleDbParameter("aRate", atr.Rate.Id));
            command.Parameters.Add(new OleDbParameter("aPic", atr.Pic));
            command.Parameters.Add(new OleDbParameter("aType", atr.AtrType.Id));
            command.Parameters.Add(new OleDbParameter("aSummer", atr.Summer));
            command.Parameters.Add(new OleDbParameter("aWinter", atr.Winter));
            command.Parameters.Add(new OleDbParameter("aSpring", atr.Spring));
            command.Parameters.Add(new OleDbParameter("aFall", atr.Fall));

            command.Parameters.Add(new OleDbParameter("aId", atr.Id));
        }
        
        protected override BaseEntity NewEntity()
        {
            return new Attraction();
        }

    }
}
