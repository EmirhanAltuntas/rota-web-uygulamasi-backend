using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Community:IEntity
    {
        public int CommunityId { get; set; }
        public string CommunityName { get; set; }
        public string Description { get; set; }
        public DateTime FoundDate { get; set; }
    }
}
