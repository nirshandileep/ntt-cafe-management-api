﻿using NTT.CafeManagement.Domain.Enum;

namespace NTT.CafeManagement.Infrastructure.Dtos;

public class EmployeeDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public Guid? CafeId { get; set; }
    public string Cafe { get; set; }
}