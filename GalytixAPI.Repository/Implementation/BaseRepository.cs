using GalytixAPI.DataAccess;
using GalytixAPI.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace GalytixAPI.Repository.Implementation
{
    public class BaseRepository : IDisposable
    {
        public GwpDbContext gwpDbContext;

        public IConfiguration configuration;

        public BaseRepository(GwpDbContext gwpDbContext, IConfiguration configuration)
        {
            this.gwpDbContext = gwpDbContext;
            this.configuration = configuration;

            if (this.gwpDbContext.Gwps.Count() == 0)
            {
                this.InitializeInMemoryData();
            }
        }

        private void InitializeInMemoryData()
        {
            try
            {
                var filePath = this.configuration.GetSection("AppSettings").GetSection("FilePath").Value;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        Gwp gwp = new Gwp();

                        gwp.Country = rows[0];
                        gwp.VariableId = rows[1];
                        gwp.VariableName = rows[2];
                        gwp.LineOfBusiness = rows[3];

                        decimal sumGwp = 0;
                        int countYears = 0;
                        for (int i = 4; i < headers.Length; i++)
                        {
                            decimal sum = 0;
                            if (decimal.TryParse(rows[i], out sum))
                            {
                                if (sum > 0)
                                {
                                    sumGwp += sum;
                                    countYears++;
                                }
                            }
                        }

                        if (countYears > 0)
                        {
                            gwp.AvgGwp = sumGwp / countYears;
                        }
                        else
                        {
                            gwp.AvgGwp = sumGwp;
                        }

                        this.gwpDbContext.Add(gwp);
                        this.gwpDbContext.SaveChanges();
                    }

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();  
        }
    }
}