using BeerHub.Enums;
using System;

namespace BeerHub.Models
{
    public class FakeAuthRequest
    {
        public Guid? UserId { get; set; }
        public EUserType Type { get; set; }
    }
}
