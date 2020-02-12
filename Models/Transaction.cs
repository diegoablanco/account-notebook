using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingApi.Models
{
    public class Transaction
    {
        public Transaction()
        {
            EffectiveDate = DateTime.Now;
        }
        public long Id { get; set; }
        [EnumDataType(typeof(TransactionType))] 
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}