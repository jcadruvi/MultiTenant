﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Repository.Interfaces
{
    public interface IStoreRepository
    {
        Store Get(int id);
        IEnumerable<Store> GetStores();
    }
}
