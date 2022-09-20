using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserAge { get; set; }
        public string? UserPhone { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserNumberLogin { get; set; }
    }
}
