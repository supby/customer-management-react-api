using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementReactWebAPI.Models.Entity
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
