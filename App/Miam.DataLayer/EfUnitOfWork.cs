// Exemple du design pattern Unit Of Work
// N'est pas utilisé dans cette application


using Miam.Domain;
using Miam.Domain.Entities;

namespace Miam.DataLayer
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private MiamDbContext _dbContext;
        private EfEntityRepository<Writer> _writer = null;
        private EfEntityRepository<Restaurant> _restaurant = null;
        private EfEntityRepository<Review> _review = null;
        private EfEntityRepository<Tag> _tag = null;
        private EfEntityRepository<ApplicationUser> _user = null;

        public EfUnitOfWork()
        {
            _dbContext = new MiamDbContext();
        }

        public IEntityRepository<Writer> WriterRepository
        {
            get
            {
                if (_writer == null)
                {
                    //_writer = new EfEntityRepository<Writer>(_dbContext);
                }
                return _writer;
            }
        }

        public IEntityRepository<Review> ReviewRepository
        {
            get
            {
                if (_review == null)
                {
                   // _review = new EfEntityRepository<Review>(_dbContext);
                }
                return _review;
            }
        }

        public IEntityRepository<Restaurant> RestaurantRepository
        {
            get
            {
                if (_restaurant == null)
                {
                   // _restaurant = new EfEntityRepository<Restaurant>(_dbContext);
                }
                return _restaurant;
            }
        }

        public IEntityRepository<Tag> TagRepository
        {
            get
            {
                if (_tag == null)
                {
                   // _tag = new EfEntityRepository<Tag>(_dbContext);
                }
                return _tag;
            }
        }

        public IEntityRepository<ApplicationUser> UserRepository
        {
            get
            {
                if (_user == null)
                {
                    //_user = new EfEntityRepository<ApplicationUser>(_dbContext);
                }
                return _user;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
