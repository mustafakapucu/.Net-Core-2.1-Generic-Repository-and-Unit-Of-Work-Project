using System;
using System.Linq;
using System.Linq.Expressions;
using Repository.Models;

namespace Business.Services.UserServices
{
    public interface IUserServices
    {
       int add(User entity);
    }
}


