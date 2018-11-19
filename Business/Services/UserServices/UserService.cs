using System;
using System.Linq;
using System.Linq.Expressions;
using Repository.Context;
using Repository.IUnitOfWork;
using Repository.Models;
using Repository.Repositories;

namespace Business.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private EFContext dbContext;
        private readonly IRepository<User> userRepository;
        private IUnitOfWork uow;
        public UserServices()
        {
            dbContext = new EFContext();
            uow = new EFUnitOfWork(dbContext);
            userRepository = new EFRepository<User>(dbContext);
        }
        public int add(User entity)
        {
            userRepository.Add(entity);
            return uow.SaveChanges();
        }
    }
}


