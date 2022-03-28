using System.Collections.Generic;
using System.Threading.Tasks;

using StudentAdminPortal.RestfulAPI.Models;

namespace StudentAdminPortal.RestfulAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> RetrieveAllAsync();
    }
}
