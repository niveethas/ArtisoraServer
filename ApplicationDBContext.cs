using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer
{

        public class ApplicationDBContext : DbContext
        {
            public ApplicationDBContext()
            {

            }
            public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
            {

            }
            public DbSet<mentee> Mentees { get; set; }
            public DbSet<mentor> Mentors { get; set; }
            public DbSet<login> Logins { get; set; }
            public DbSet<mentorship> Mentorships { get; set; }
            public DbSet<message> Messages { get; set; }
            public DbSet<image> Images { get; set; }

            public DbSet<showcase> Showcases { get; set; }


            static IConfiguration Configuration { get; set; }


            //public void ConfigureServices(IServiceCollection services)
            //{

            //    services.AddDbContext<ApplicationDBContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //}


            //this fucntion has been derived from https://stackoverflow.com/questions/38338475/no-database-provider-has-been-configured-for-this-dbcontext-on-signinmanager-p
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();
                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }



        }
    
}
