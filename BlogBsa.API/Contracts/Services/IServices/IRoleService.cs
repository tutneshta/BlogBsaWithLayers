using BlogBsa.API.Data.Models.Request.Roles;
using BlogBsa.API.Data.Models.Response.Roles;

namespace BlogBsa.API.Contracts.Services.IServices
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}
