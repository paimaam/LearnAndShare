using System;
using System.Collections.Generic;
using System.Text;

namespace AzureCosmosDB
{
    class Customer
    {
        public Guid id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
    }
}
