using Exercise.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Api.Models
{
    public class ConfirmTransactionModel
    {
        public string Id { get; set; }

        public DbTransactionStatus Status { get; set; }
    }
}
