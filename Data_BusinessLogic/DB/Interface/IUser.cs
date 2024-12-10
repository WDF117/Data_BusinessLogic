﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB.Interface
{
    public interface IUser
    {
        Guid Id { get; }
        string Login { get; set; }
        string Password { get; set; }
        long Phone { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string LastName { get; set; }
        Guid UserTypeId { get; set; }
        bool ValidatePassword(string password);
    }
}
