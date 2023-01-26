using GalytixAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalytixAPI.Business.Interfaces
{
    public interface IGwpManager
    {
        IList<GwpResponse> GetGwpAvg(GwpRequest request);
    }
}
