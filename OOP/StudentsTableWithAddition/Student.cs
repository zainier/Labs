using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsTable
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string firstName, string lastName, DateTime dateOfBirth): this(0, firstName, lastName, dateOfBirth)
        {
        }

        public Student(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
