using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementReactWebAPI.Models.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
