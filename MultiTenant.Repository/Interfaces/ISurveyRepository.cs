﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Repository.Interfaces
{
    public interface ISurveyRepository
    {
        IEnumerable<KeyValuePair<int, string>> GetSurveyItems();
    }
}
