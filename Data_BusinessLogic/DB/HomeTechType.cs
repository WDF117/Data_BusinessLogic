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
    public class HomeTechType : BindableBase, IHomeTechType
    {

        public Guid Id { get; private set; }

        private string name;
        [Required]
        [MaxLength(75)]
        [JsonPropertyName("name")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
