using System;
using System.Collections.Generic;
using System.Text;

namespace GalytixAPI.Entities
{
    public class Gwp
    {
        public Guid Id { get; set; }
        public string? Country { get; set; }

        public string? VariableId { get; set; }

        public string? VariableName { get; set; }

        public string? LineOfBusiness { get; set; }

        public decimal AvgGwp { get; set; }
    }
}
