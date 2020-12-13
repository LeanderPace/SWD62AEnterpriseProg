﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.domain.Models
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Key]
        public string Email { get; set; }
    }
}
