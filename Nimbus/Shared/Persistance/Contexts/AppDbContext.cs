using Microsoft.EntityFrameworkCore;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Shared.Extensions;

namespace Nimbus.Shared.Persistance.Contexts;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Constructor que inicializa una nueva instancia de la clase AppDbContext.
    /// </summary>
    /// <param name="options">Opciones para configurar el contexto de la base de datos.</param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Obtiene o establece el conjunto de datos de alquileres.
    /// </summary>
    public DbSet<Category> Categories { get; set; }
    
    /// <summary>
    /// Obtiene o establece el conjunto de datos de arrendatarios.
    /// </summary>
    public DbSet<Proveedores> proveedores { get; set; }
    
    
    
    public DbSet<Product> Products { get; set; }
    
    /// <summary>
    /// Configuración del modelo de base de datos al crear el contexto.
    /// </summary>
    /// <param name="builder">Constructor de modelos para configurar entidades y relaciones.</param>
    //public DbSet<User> Usuarios { get; set; }
    
    /// <summary>
    /// Configuración del modelo de base de datos al crear el contexto.
    /// </summary>
    /// <param name="builder">Constructor de modelos para configurar entidades y relaciones.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        

        
        
        //Configurar la tabla Products

        builder.Entity<Product>().ToTable("Product");
        builder.Entity<Product>().HasKey(p => p.Id); 
        builder.Entity<Product>().Property(p => p.SoftwareName).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Product>().Property(p => p.UrlImagePreview).IsRequired();
        builder.Entity<Product>().Property(p => p.DateCreate).HasDefaultValue(DateTime.Now);

        
        //Configurar la tabla Provider
        builder.Entity<Proveedores>().ToTable("Provider");
        builder.Entity<Proveedores>().HasKey(p => p.ProveedorId); 
        builder.Entity<Proveedores>().Property(p => p.Name).IsRequired().HasMaxLength(90);
        builder.Entity<Proveedores>().Property(p => p.urlLogo).IsRequired();
        builder.Entity<Proveedores>().Property(p => p.DateCreate).HasDefaultValue(DateTime.Now);

        
        //Configurar la tabla Category
        builder.Entity<Category>().ToTable("Category");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(c => c.Title).IsRequired().HasMaxLength(90);
        builder.Entity<Category>().Property(c => c.Description).IsRequired().HasMaxLength(200); 
        builder.Entity<Category>().Property(c => c.DateCreate).HasDefaultValue(DateTime.Now);

        
        // Utiliza la convención de nomenclatura SnakeCase para el modelo de datos.    
    builder.UseSnakeCaseNamingConvention();
    }
}