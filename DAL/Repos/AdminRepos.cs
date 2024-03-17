using DAL.Entity;
namespace DAL.Repos
{
    public class AdminRepos

    {
        public List<Admin> All() {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Admins.ToList();

        }


        public void Create(Admin admin)
        {
            MyDbContext dbContext = new MyDbContext();
            dbContext.Admins.Add(admin);
            dbContext.SaveChanges();

        }
        public Admin Read(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Admins.Find(id);
        }

    }
    

    }