﻿using EmployeeTracker.Domain.Models;

namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class UpdateDepartment : IDataRequest
    {
        public UpdateDepartment(Department department)
        {
            Department = department;
        }

        public Department Department { get; set; }

        public object? GenerateParameters() => new { Department.Code, Department.Name };

        public string GenerateSql() => $"UPDATE {Tables.Department} SET Name = COALESCE(@Name, Name) WHERE Code = @Code";
    }
}
