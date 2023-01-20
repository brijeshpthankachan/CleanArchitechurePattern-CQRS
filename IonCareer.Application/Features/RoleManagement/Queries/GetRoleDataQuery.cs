using IonCareer.Application.Contracts.Persistence;
using IonCareer.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Application.Features.RoleManagement.Queries
{

    public class GetRoleDataQuery : IRequest<List<RoleDto>>
    {
    }

    public class GetRolesQueryHandler : IRequestHandler<GetRoleDataQuery, List<RoleDto>>
    {
        private readonly IIonCareerDbContext _ionCareerDbContext;

        public GetRolesQueryHandler(IIonCareerDbContext ionCareerDbContext)
        {
            _ionCareerDbContext = ionCareerDbContext;
        }

        public async Task<List<RoleDto>> Handle(GetRoleDataQuery request, CancellationToken cancellationToken)
        {
            var roles = await _ionCareerDbContext.Roles.
                Select(roles => new RoleDto()
                {
                    Id = roles.Id,
                    RoleName = roles.RoleName
                })
                .ToListAsync(cancellationToken);

            return roles;
        }
    }

}
