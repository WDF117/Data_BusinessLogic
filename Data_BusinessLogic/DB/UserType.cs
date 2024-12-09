﻿using Data_BusinessLogic.DB.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB
{
    public class UserType : BindableBase, IUserType
    {
        public Guid Id { get; private set; }

        private string role;
        [Required]
        [MaxLength(25)]
        [JsonPropertyName("role")]
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
    }
}
