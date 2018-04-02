using System;
using System.ComponentModel.DataAnnotations;

namespace WhatWeGot.Model
{
    public class FinanceItem
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
