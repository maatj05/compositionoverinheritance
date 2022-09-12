// See https://aka.ms/new-console-template for more information
using EfCore;
using Microsoft.Extensions.DependencyInjection;

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
string DbPath = System.IO.Path.Join(path, "blogging.db");

//var serviceProvider = new ServiceCollection()
//         .AddLogging()
//         .AddDbContext<EfCore.Context>().AddSqlite($"Data Source={DbPath}")
//         .BuildServiceProvider();

var ctx = new EfCore.Context();


ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();

ctx.Boats.Add(new EfCore.Boat { Name = "Name 1" });
ctx.Tours.Add(new EfCore.Tour { Name = "Tour 1" });
ctx.SaveChanges();

var list = new List<IHasName>();
list = ctx.Boats.ToList<IHasName>();
list.AddRange( ctx.Tours.ToList<IHasName>());
list.ForEach(x => { Console.WriteLine(x.Name);  x.Name = x.Name + " - copy";  });


ctx.SaveChanges();

var list2 = new List<IHasName>();
list2 = ctx.Boats.ToList<IHasName>();
list2.AddRange( ctx.Tours.ToList<IHasName>());
list2.ForEach(x => { Console.WriteLine(x.Name);  x.Name = x.Name + " - copy";  });