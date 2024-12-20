﻿using NTT.CafeManagement.Domain.Enum;

namespace NTT.CafeManagement.Infrastructure.Dtos;

public class EmployeeListItemDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public int DaysWorked { get; set; }
    public string Cafe { get; set; }
}