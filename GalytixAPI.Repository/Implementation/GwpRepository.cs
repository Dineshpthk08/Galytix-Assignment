using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using System.Data;
using GalytixAPI.Repository.Interface;
using GalytixAPI.Entities;
using ExcelDataReader;
using GalytixAPI.DataAccess;
using Microsoft.Extensions.Configuration;

namespace GalytixAPI.Repository.Implementation
{
    public class GwpRepository : BaseRepository, IGwpRepository
    {
        public GwpRepository(GwpDbContext gwpDbContext, IConfiguration configuration) : base(gwpDbContext, configuration)
        {
        }

        public List<Gwp> GetGwp()
        {
            return this.gwpDbContext.Gwps.ToList();
        }
    }
}
