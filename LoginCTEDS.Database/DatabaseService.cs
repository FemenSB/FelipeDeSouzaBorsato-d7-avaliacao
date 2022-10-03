using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCTEDS.Database
{
    public class DatabaseService
    {
        private DbContextOptions<DatabaseContext> _options;

        public DatabaseService()
        {
            SetOptions();
        }

        private void SetOptions()
        {
            DbContextOptionsBuilder<DatabaseContext> ob = new();

            ob.UseSqlite($"Data Source=database.db");
            _options = ob.Options;
        }

        public void EnsureDatabaseIsCreated()
        {
            using (DatabaseContext context = new(_options))
            {
                if(context.Database.EnsureCreated())
                {
                    context.Users.Add(new UserModel() { userName = "admin@email.com", password = "admin123" });
                    context.SaveChanges();
                }
            }
        }

        public bool AreCrendentialsValid(string userName, string password)
        {
            using (DatabaseContext context = new(_options))
            {
                return context.Users.Any(user => user.userName == userName && user.password == password);
            }
        }
    }
}
