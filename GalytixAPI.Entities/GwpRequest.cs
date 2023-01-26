using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalytixAPI.Entities
{
    public class GwpRequest
    {
        public string CountryCode { get; set; }
        public List<string> lineOfBusiness { get; set; }
    }
}
