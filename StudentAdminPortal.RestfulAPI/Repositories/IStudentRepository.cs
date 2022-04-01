using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using StudentAdminPortal.RestfulAPI.Models;

namespace StudentAdminPortal.RestfulAPI.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> RetrieveAllAsync();
    Task<Student?> RetrieveByIdAsync(Guid studentId);
    Task UpdateAsync(Student studentToUpdate);
    Task RemoveAsync(Guid studentId);
    Task<Student> InsertAsync(Student studentToInsert);
}
