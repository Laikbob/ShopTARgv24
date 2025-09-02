using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv24.Core.Domain
{
    public class Spaceship
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Typename { get; set; }

        public DateTime? BultiDate { get; set; }

        public int? Crew { get; set; }

        public int? EnginePower { get; set; }

        public int? Passenger { get; set; }

        public int? InnerVolume { get; set; }

        public DateTime? CreatedAT { get; set; }


    }
}
