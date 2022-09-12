using Microsoft.EntityFrameworkCore;

namespace EfCore;

public class Context:DbContext
{

    public DbSet<Tour> Tours { get; set; }
    public DbSet<Boat> Boats { get; set; }
    public Context()
	{
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    public string DbPath { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");



}