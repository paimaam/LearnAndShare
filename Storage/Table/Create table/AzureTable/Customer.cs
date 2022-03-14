using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTable
{
    public class Customer : TableEntity // Add .net object to storage table
    {
        public Customer() // need to ensure you have to have empty constructor in place
        {
        }

        public string customername { get; set; }
        public Customer(string _customername, string _city, string _customerid)
        {
            PartitionKey = _city;
            RowKey = _customerid;
            customername = _customername;
        }
    }
}
