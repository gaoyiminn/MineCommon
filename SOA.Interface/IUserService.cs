﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.Interface
{
    public interface IUserService
    {
        object Query(int id);
    }
}
