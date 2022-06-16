﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    

    public class Customer:IEntity
    {
        
        public string CompanyName { get; set; }

        [Key]
        public int UserId { get; set; }

    }
}
