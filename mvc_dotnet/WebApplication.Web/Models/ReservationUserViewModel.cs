﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.Models
{
    public class ReservationUserViewModel
    {
        public IList<Reservation> Reservations { get; set; }
        public User User { get; set; }
        public Reservation Reservation { get; set; }
    
    }
}