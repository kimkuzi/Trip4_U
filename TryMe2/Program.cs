using Model;
using ViewModel;
using Trip_4U_ApiService;

Trip_4U_ApiService.ApiService kim;
kim = new ApiService();
ContinentList lst = await kim.GetAllContinents();
foreach (var x in lst)
{
    Console.WriteLine(x.ContinentName);
}



//WotwDB db = new WotwDB();
//WotwList lst = db.SelectAll();
//Wotw w1 = lst.Last();
//db.Delete(w1);
//db.SaveChanges();
//lst=db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine(AttractionDB.SelectById(x.Id).ToString());
//    Console.WriteLine("date - "+x.DiscoverDate);
//}
//ReviewDB db = new ReviewDB();
//ReviewList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine($"atr= {x.Attraction.AttractionName}, review desc={x.ReviewDesc}, review date={x.ReviewDate}, username ={x.User.Username}");
//}
//Review r1 = lst.Last();

//db.Delete(r1);
//db.SaveChanges();
//lst= db.SelectAll();
//Console.WriteLine("after delete");
//foreach (var x in lst)
//{
//    Console.WriteLine($"atr= {x.Attraction.AttractionName}, review desc={x.ReviewDesc}, review date={x.ReviewDate}, username ={x.User.Username}");
//}
//FavDB db= new FavDB();
//FavList lst= db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine($"id:{x.Id}, user={x.User.Username}, attraction={x.Attraction.AttractionName}, date: {x.DateAdded}");
//}
//Fav f1 = lst.Last();
//db.Delete(f1);
//db.SaveChanges();
//lst = db.SelectAll();
//Console.WriteLine("after delete");
//foreach (var x in lst)
//{
//    Console.WriteLine($"id:{x.Id}, user={x.User.Username}, attraction={x.Attraction.AttractionName}, date: {x.DateAdded}");
//}
//AttractionDB db = new AttractionDB();   
//AttractionList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine(x.ToString());
//}
//Attraction a1= lst.Last();
//db.Delete(a1);
//db.SaveChanges();
//Console.WriteLine("after delete");
//lst=  db.SelectAll();   
//foreach (var x in lst)
//{
//    Console.WriteLine(x.ToString());
//}
//RateDB db = new RateDB();
//RateList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: "+x.Id+ ", stars:"+x.Stars);
//}
//Rate r1 = lst.Last();
//r1.Stars = 80;
//db.Update(r1);
//db.SaveChanges();
//lst = db.SelectAll();
//Console.WriteLine(  "after update");
//foreach (var x in lst)
//{
//    Console.WriteLine("id: " + x.Id + ", stars:" + x.Stars);
//}
//CityDB db = new CityDB();
//CityList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: "+x.Id+", country= "+x.Country.CountryName+", city= "+x.CityName);
//}

//db.Delete(lst.Last());
//db.SaveChanges();
//lst= db.SelectAll();
//Console.WriteLine("after delete");
//foreach (var x in lst)
//{
//    Console.WriteLine("id: " + x.Id + ", country= " + x.Country.CountryName + ", city= " + x.CityName);
//}
//CountryDB db = new CountryDB();
//CountryList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: " + x.Id + " ,continent: " + x.Continent.ContinentName + " country: " + x.CountryName);
//}
//Country c1 = lst.Last();
//c1.Continent = ContinentDB.SelectById(1);
//c1.CountryName = "Romania";
//db.Update(c1);
//db.SaveChanges();
//lst= db.SelectAll();    
//foreach (var x in lst)
//{
//    Console.WriteLine("id: "+x.Id+" ,continent: "+x.Continent.ContinentName+" country: "+x.CountryName);
//}
//ContinentDB db= new ContinentDB();  
//ContinentList lst=db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: "+x.Id+ ", continent: "+x.ContinentName);
//}
//db.Delete(lst.Last());
//db.SaveChanges();
//Console.WriteLine("after delete");
//lst= db.SelectAll();    
//foreach (var x in lst)
//{
//    Console.WriteLine("id: " + x.Id + ", continent: " + x.ContinentName);
//}
//PersonDB db = new PersonDB();
//PersonList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: "+x.Id+", username: "+x.Username+", pass: "+x.Pass+", is admin? "+x.IsAdmin);
//}
//db.Delete(lst.Last());
//db.SaveChanges();
//Console.WriteLine("after delete");
//lst=db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: " + x.Id + ", username: " + x.Username + ", pass: " + x.Pass + ", is admin? " + x.IsAdmin);
//}

//AttractionTypeDB db= new AttractionTypeDB();    
//AtrTypeList lst = db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine("id: "+x.Id+ ", type: "+x.AtrType);
//}
//db.Delete(lst.Last()) ;
//db.SaveChanges();
//lst = db.SelectAll();
//Console.WriteLine("after delete");
//foreach (var x in lst)
//{
//    Console.WriteLine("id: " + x.Id + ", type: " + x.AtrType);
//}
//AttractionDB db= new AttractionDB();    
//AttractionList atrList=db.SelectAll();
//foreach (var item in atrList)
//{
//    Console.WriteLine(item.Id);
//}
//ReviewDB db = new ReviewDB();
//ReviewList lst = db.SelectAll();
//Review r1 = new Review();
//r1.Attraction = AttractionDB.SelectById(1);
//r1.ReviewDesc = "very good";
//r1.ReviewDate = new DateTime(2006, 08 , 14);
//r1.User = PersonDB.SelectById(1);
//db.Insert(r1);
//db.SaveChanges();
// lst = db.SelectAll();
//foreach (var item in lst)
//{
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.Attraction.AttractionName);
//    Console.WriteLine(item.ReviewDesc);
//    Console.WriteLine(item.ReviewDate);
//    Console.WriteLine(item.User.Username);

//}

//Console.WriteLine(  "after delete ");
//Console.WriteLine(lst.Count);

//RateDB db = new RateDB();
//RateList lst=db.SelectAll();
//foreach (var x in lst)
//{
//    Console.WriteLine(x.Stars);
//}
//Rate r1 = lst.Last();
//r1.Stars = 80;
//db.SaveChanges();
//lst = db.SelectAll();
//Console.WriteLine("after update");
//foreach (var x in lst)
//{
//    Console.WriteLine(x.Stars);
//}

//db.Delete(lst.Last());
//db.SaveChanges();
//foreach (var item in lst)
//{
//    Console.WriteLine(item.AttractionName);
//    Console.WriteLine(item.Desc);
//    Console.WriteLine(item.City.CityName + "  " + item.City.Country.CountryName + "  " + item.City.Country.Continent.ContinentName);
//    Console.WriteLine(item.Adress);
//    Console.WriteLine(item.MinAge);
//    Console.WriteLine(item.Rate.Stars);
//    Console.WriteLine(item.Pic);
//    Console.WriteLine(item.AtrType.AtrType);
//    Console.WriteLine(item.Summer.ToString());
//    Console.WriteLine(item.Winter.ToString());
//    Console.WriteLine(item.Spring.ToString());
//    Console.WriteLine(item.Fall.ToString());

//}
//Rate r2= new Rate();    
//r2.Stars = 2;
//db.Insert(r2);
//db.SaveChanges();

//Rate r3 = new Rate();
//r3.Stars = 3;
//db.Insert(r3);
//db.SaveChanges();

//Rate r4 = new Rate();
//r4.Stars = 4;
//db.Insert(r4);
//db.SaveChanges();

//Rate r5 = new Rate();
//r5.Stars = 5;
//db.Insert(r5);
////db./*SaveChanges*/();
////lst = db.SelectAll();


//db.Delete(lst.Last());
//db.SaveChanges();
//Console.WriteLine("after delete");
//lst = db.SelectAll();
//foreach (var item in lst)
//{
//    Console.Write("id: " + item.Id);
//    Console.Write("     stars:" + item.Stars);
//    Console.WriteLine();


//}
//foreach (var item in lst)
//{
//    Console.WriteLine(item.Username);
//    Console.WriteLine(item.Pass);
//    Console.WriteLine(item.IsAdmin.ToString());
//}

//Person p = lst.Last();
//p.Username = "kimmi";
//p.Pass = "oooooo";
//p.IsAdmin= true;    
//db.Update(p);
//db.SaveChanges();
//Console.WriteLine("after update");
//foreach (var item in lst)
//{
//    Console.WriteLine(item.Username);
//    Console.WriteLine(item.Pass);
//    Console.WriteLine(item.IsAdmin.ToString());
//}