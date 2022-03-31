using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.RestfulAPI.Context;
using StudentAdminPortal.RestfulAPI.Models;

namespace StudentAdminPortal.RestfulAPI.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminPortalContext _studentAdminPortalContext;

        public SqlStudentRepository(StudentAdminPortalContext studentAdminPortalContext) 
            => _studentAdminPortalContext = studentAdminPortalContext;

        public async Task<IEnumerable<Student>> RetrieveAllAsync()
            => await _studentAdminPortalContext
                     .Students
                     .Include(nameof(Student.Gender))
                     .Include(nameof(Student.Addresses))
                     .Where(s => s.Addresses.Any())
                     .OrderBy(s => s.Gender.Name)
                     .ThenBy(s => s.FirstName)
                     .ThenBy(s => s.LastName)
                     .ThenBy(s => s.Email)
                     .AsNoTrackingWithIdentityResolution()
                     .AsSplitQuery()
                     .ToListAsync();

        public async Task<Student?> RetrieveByIdAsync(Guid studentId)
             => await _studentAdminPortalContext
                      .Students
                      .AsNoTracking()
                      .Include(nameof(Student.Gender))
                      .Include(nameof(Student.Addresses))
                      .SingleOrDefaultAsync(s => s.Id == studentId);
    }
}