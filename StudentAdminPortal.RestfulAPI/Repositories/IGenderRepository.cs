using StudentAdminPortal.RestfulAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace StudentAdminPortal.RestfulAPI.Repositories;

public interface IGenderRepository
{
    Task<IEnumerable<Gender>> RetrieveAllAsync();
}
