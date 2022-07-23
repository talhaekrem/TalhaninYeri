using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class UserManager : IUserService
    {
        private IUsersDal _userDal;
        public UserManager(IUsersDal usersDal)
        {
            _userDal = usersDal;
        }
        public List<AspNetUsers> GetAll()
        {
            return _userDal.GetList();
        }
    }
}
