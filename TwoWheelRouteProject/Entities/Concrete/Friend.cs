using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Friend:IEntity
    {
        public int FriendId { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
    }
}
