using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    // erişim tokenını
    public class AccessToken
    {
        public int UserId { get; set; } 
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

}
