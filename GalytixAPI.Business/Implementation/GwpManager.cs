using GalytixAPI.Business.Interfaces;
using GalytixAPI.Entities;
using GalytixAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalytixAPI.Business.Implementation
{
    public class GwpManager : IGwpManager
    {
        IGwpRepository _gwpRepository;
        public GwpManager(IGwpRepository gwpRepository)
        {
            _gwpRepository = gwpRepository;
        }

        public IList<GwpResponse> GetGwpAvg(GwpRequest gwpRequest)
        {
            IList<GwpResponse> responses = new List<GwpResponse>();
            var gwps = _gwpRepository.GetGwp();

            List<Gwp> gwpByCountry = gwps.Where(gwp => gwp.Country.ToLower() == gwpRequest.CountryCode.ToLower()).ToList();

            if (gwpByCountry.Count > 0)
            {
                foreach (var lob in gwpRequest.lineOfBusiness)
                {
                    var result = new GwpResponse();
                    List<Gwp> gwpByCountryAndLob = gwpByCountry.Where(gwp => gwp.LineOfBusiness.ToLower() == lob.ToLower()).ToList();
                    if (gwpByCountryAndLob.Count > 0)
                    {
                        result.LineOfBusiness = gwpByCountryAndLob.FirstOrDefault()?.LineOfBusiness;
                        result.Avg = gwpByCountryAndLob.Sum(x => x.AvgGwp);
                    }
                    else
                    {
                        result.LineOfBusiness = lob;
                        result.Avg = 0;
                    }
                    responses.Add(result);
                }
            }

            return responses;
        }
    }
}
