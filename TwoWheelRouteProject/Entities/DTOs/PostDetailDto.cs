using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PostDetailDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserImage> UserImages { get; set; }
        public List<Place> Places { get; set; }
        public List<Photo> Photos { get; set; }

    }
}
