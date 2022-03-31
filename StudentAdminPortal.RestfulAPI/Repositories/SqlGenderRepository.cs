using StudentAdminPortal.RestfulAPI.Context;
using StudentAdminPortal.RestfulAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudentAdminPortal.RestfulAPI.Repositories
{
    public class SqlGenderRepository : IGenderRepository
    {
        private readonly StudentAdminPortalContext _studentAdminPortalContext;

        public SqlGenderRepository(StudentAdminPortalContext studentAdminPortalContext)
            => _studentAdminPortalContext = studentAdminPortalContext;
       
        public async Task<IEnumerable<Gender>> RetrieveAllAsync()
        => await _studentAdminPortalContext
                     .Genders
                     .OrderBy(g => g.Name)
                     .AsNoTracking()
                     .ToListAsync();
    }
}
