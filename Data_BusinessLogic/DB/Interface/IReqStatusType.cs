﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB.Interface
{
    public interface IReqStatusType
    {
        Guid Id { get; }
        string Name { get; set; }
    }
}
