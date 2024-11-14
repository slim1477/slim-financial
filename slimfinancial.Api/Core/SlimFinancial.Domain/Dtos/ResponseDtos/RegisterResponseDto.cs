using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimFinancial.Domain.Dtos;

    /// <summary>
    /// Represents the response for a registeration session
    /// </summary>
    public class RegisterResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string SessionToken { get; set; } = string.Empty;
    }

