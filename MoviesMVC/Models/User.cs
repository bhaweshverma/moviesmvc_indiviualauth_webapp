using System;
using System.Runtime.Serialization;

namespace MoviesMVC.Models
{
    
    public class User
    {
        public int UserId{ get; set; }

        public string UserName { get; set; }
        
        public string UserType { get; set; }
    }
}