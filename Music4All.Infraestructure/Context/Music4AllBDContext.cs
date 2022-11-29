
using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure.Context;

public class Music4AllBDContext : DbContext //Base de datos
{
    public Music4AllBDContext()
    {

    }

    public Music4AllBDContext(DbContextOptions<Music4AllBDContext> options) : base(options)
    {
    }
    
    public DbSet<Music> Musics { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Musician> Musicians { get; set; }
    
    public DbSet<Guardian> Guardians { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
            optionsBuilder.UseMySql("server=localhost;user=root;password=12345678;database=music4all;", serverVersion);
        }
    }
    
//control de tablas 
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


       builder.Entity<Event>().ToTable("Events");
       builder.Entity<Event>().HasKey(p => p.Id);
       builder.Entity<Event>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Event>().Property(c => c.Title).IsRequired().HasMaxLength(50);
       builder.Entity<Event>().Property(c => c.Description).IsRequired().HasMaxLength(150);
       builder.Entity<Music>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
       builder.Entity<Event>().Property(c => c.url).IsRequired();
       builder.Entity<Event>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
       
       builder.Entity<Music>().ToTable("Musics");
       builder.Entity<Music>().HasKey(p => p.Id);
       builder.Entity<Music>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Music>().Property(c => c.Title).IsRequired().HasMaxLength(50);
       builder.Entity<Music>().Property(c => c.Description).IsRequired().HasMaxLength(150);
       builder.Entity<Music>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
       builder.Entity<Event>().Property(c => c.url).IsRequired();
       
       builder.Entity<Contractor>().ToTable("Contractors");
       builder.Entity<Contractor>().HasKey(p => p.Id);
       builder.Entity<Contractor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Contractor>().Property(c => c.Name).IsRequired().HasMaxLength(50);
       builder.Entity<Contractor>().Property(c => c.Description).IsRequired().HasMaxLength(150);
       builder.Entity<Contractor>().Property(c => c.Age).IsRequired();
       builder.Entity<Contractor>().Property(c => c.Correo).IsRequired();
       
       builder.Entity<Musician>().ToTable("Musicians");
       builder.Entity<Musician>().HasKey(p => p.Id);
       builder.Entity<Contractor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Musician>().Property(c => c.Name).IsRequired().HasMaxLength(50);
       builder.Entity<Musician>().Property(c => c.Description).IsRequired().HasMaxLength(150);
       builder.Entity<Musician>().Property(c => c.Age).IsRequired();
       builder.Entity<Musician>().Property(c => c.Correo).IsRequired();
       
       builder.Entity<Guardian>().ToTable("Guardians");
       builder.Entity<Guardian>().HasKey(p => p.Id);
       builder.Entity<Guardian>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Guardian>().Property(c => c.email).IsRequired();
       builder.Entity<Guardian>().Property(c => c.firstname).HasMaxLength(50);
       builder.Entity<Guardian>().Property(c => c.lastname).HasMaxLength(50);
       builder.Entity<Guardian>().Property(c => c.address);
       builder.Entity<Guardian>().Property(c => c.gender).HasMaxLength(50);
       builder.Entity<Guardian>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
   
    }
}