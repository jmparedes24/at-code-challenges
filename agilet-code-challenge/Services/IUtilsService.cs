using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agilet_code_challenge.Models;

namespace agilet_code_challenge.Services
{
    public interface IUtilsService
    {
        ServiceResponse<string[]> OrganizedArray(string[] names, string[] order);
    }
}