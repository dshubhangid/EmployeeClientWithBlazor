using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeClientWithBlazor.Data
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MinLength(5)]
        [MaxLength(100)]
        public string firstName { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Last name is required")]
        public string lastName { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Organization name is required")]
        public string organization { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Position is required")]
        public string position { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }

        [MinLength(1)]
        [MaxLength(10)]
        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }

        [Range(1000, 99999999, ErrorMessage = "Salary can not be less than 10000")]
        [Required(ErrorMessage = "Salary is required")]
        public decimal salary { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Department is required")]
        public string department { get; set; }

        public Employee()
        {}

        public Employee(Employee employee)
        {
            this.firstName = employee.firstName;
            this.lastName = employee.lastName;
            this.organization = employee.organization;
            this.position = employee.position;
            this.address = employee.address;
            this.city = employee.city;
            this.gender = employee.gender;
            this.salary = employee.salary;
            this.department = employee.department;
        }
    }
}
