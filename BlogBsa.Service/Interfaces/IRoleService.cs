using BlogBsa.Domain.Entity;
using BlogBsa.Domain.ViewModels.Roles;

namespace BlogBsa.Service.Interfaces
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}
