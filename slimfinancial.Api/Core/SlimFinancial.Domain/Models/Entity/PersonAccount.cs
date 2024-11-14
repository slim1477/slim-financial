using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimFinancial.Domain.Models;

    /// <summary>
    /// Represents the joint owners-Account many-to-many relationship
    /// </summary>
    public class PersonAccount
    {
        public int PersonNumber { get; set; } 
        public Person Person { get; set; } = default!;
        public int AccountNumber { get; set; }
        public Account Account { get; set; } = default!;
    }

