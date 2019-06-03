using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Api.Models
{
    public class ConfirmTransactionModel
    {
        public string Id { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
