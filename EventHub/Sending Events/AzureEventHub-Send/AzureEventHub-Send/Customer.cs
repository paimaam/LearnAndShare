using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AzureEventHub_Send
{
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    
}
