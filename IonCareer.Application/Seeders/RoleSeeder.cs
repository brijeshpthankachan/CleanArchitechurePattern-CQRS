using IonCareer.Domain.Entities;
using IonCareer.Shared.Enums;

namespace IonCareer.Application.Seeders;

public static class RoleSeeder
{
    public static List<Role> GetRoles()
    {
        return new List<Role>
        {
            new()
            {
                Id = (int)RoleEnum.Roles.Director,
                RoleName = RoleEnum.Roles.Director.ToString()
            },
            new()
            {
                Id = (int)RoleEnum.Roles.VicePresident,
                RoleName = RoleEnum.Roles.VicePresident.ToString()
            },
            new()
            {
                Id = (int)RoleEnum.Roles.HrRecruiter,
                RoleName = RoleEnum.Roles.HrRecruiter.ToString()
            },

            new()
            {
                Id = (int)RoleEnum.Roles.Employee,
                RoleName = RoleEnum.Roles.Employee.ToString()
            }
        };
    }
}