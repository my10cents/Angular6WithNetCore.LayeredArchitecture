using Acme.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Business.Data.BusinessContracts
{
    public interface ICourseBusiness
    {
        void Add(Course entity);
    }
}
