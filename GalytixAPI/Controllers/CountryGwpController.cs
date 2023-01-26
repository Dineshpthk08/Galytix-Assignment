using GalytixAPI.Business.Interfaces;
using GalytixAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalytixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly ILogger<CountryGwpController> _logger;

        private IGwpManager _gwpManager;

        public CountryGwpController(
            ILogger<CountryGwpController> logger,
            IGwpManager _gwpManager)
        {
            _logger = logger;
            this._gwpManager = _gwpManager;
        }

        [HttpPost(Name = "GwpAvg")]
        public IEnumerable<GwpResponse> GwpAvg(GwpRequest request)
        {
            try
            {
                return _gwpManager.GetGwpAvg(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return Enumerable.Empty<GwpResponse>();
        }
    }
}
