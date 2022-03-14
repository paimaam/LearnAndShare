using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AzureServiceQueue
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Name  { get; set; }
        public string Designation { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
