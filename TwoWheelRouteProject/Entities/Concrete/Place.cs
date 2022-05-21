using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Place:IEntity
    {
        public int PlaceId { get; set; }
        public int PostId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
