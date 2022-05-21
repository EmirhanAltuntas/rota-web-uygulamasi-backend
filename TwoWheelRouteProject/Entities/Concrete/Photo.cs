using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Photo:IEntity
    {
        public int PhotoId { get; set; }
        public int PostId { get; set; }
        public string PhotoPath { get; set; }
    }
}
