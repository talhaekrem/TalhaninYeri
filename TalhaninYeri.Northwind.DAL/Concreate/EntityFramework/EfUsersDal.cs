using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Core.DAL.EntityFramework;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.DAL.Concreate.EntityFramework
{
    public class EfUsersDal : EfEntityRepositoryBase<AspNetUsers, NorthwindContext>, IUsersDal
    {
    }
}
