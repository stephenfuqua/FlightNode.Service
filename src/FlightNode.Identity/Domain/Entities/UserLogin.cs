﻿using FlightNode.Common.BaseClasses;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlightNode.Identity.Domain.Entities
{
    public class UserLogin : IdentityUserLogin<int>, IEntity
    {
        public int Id {  get { return base.UserId; } }
    }
}
