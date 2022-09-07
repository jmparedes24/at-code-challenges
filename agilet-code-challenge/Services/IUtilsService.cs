using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agilet_code_challenge.Services
{
    public interface IUtilsService
    {
        string[] OrganizedArray(string[] names, string[] order);
    }
}