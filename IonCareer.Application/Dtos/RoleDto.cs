using System.ComponentModel.DataAnnotations;

namespace IonCareer.Application.Dtos;

public class RoleDto
{
    public long Id { get; set; }
    [Display(Name = "Role Name")] public string? RoleName { get; set; }
}