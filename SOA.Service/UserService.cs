﻿using SOA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.Service
{
    public class UserService : IUserService
    {
        public object Query(int id)
        {
            return new
            {
                Id = id,
                Name = "龙",
                Remark = "幸运儿！！！！"
            };
        }
    }
}
