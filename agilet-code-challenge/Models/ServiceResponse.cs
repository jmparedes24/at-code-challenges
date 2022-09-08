using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agilet_code_challenge.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}