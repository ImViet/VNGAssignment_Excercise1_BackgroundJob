﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNGAssignment.DataAccessor.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }   
        public string Status { get; set; }
        public DateTime LastUpdatePwd { get; set; }
    }
}
