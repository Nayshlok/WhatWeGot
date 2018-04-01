using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatWeGot.Model
{
    public class FinanceItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
