﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFUserMessageDal: GenericRepository<UserMessage>, IUserMessageDal
    {
        

        public List<UserMessage> GetUserMessageWithUser()
        {
            using (var c = new Context())
            {
                return c.UserMessages.Include(x => x.User).ToList();
            }
        }
    }
}
