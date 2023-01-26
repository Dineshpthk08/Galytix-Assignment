using GalytixAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GalytixAPI.Repository.Interface
{
    public interface IGwpRepository
    {
        List<Gwp> GetGwp();
    }
}
