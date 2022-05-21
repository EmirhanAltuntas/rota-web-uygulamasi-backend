using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Route:IEntity
    {
        public int RouteId { get; set; }
        public int PostId { get; set; }
        public int PlaceId { get; set; }
    }
}
