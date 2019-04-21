﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GradesPrototype.Data
{
    // Types of user
    public enum Role { Teacher, Student };

    // WPF Databinding requires properties

    public class Grade
    {
        public int StudentID { get; set; }

        // TODO: Exercise 2: Task 2a: Add validation to the AssessmentDate property
        private string _assessmentDate;
        public string AssessmentDate
        {
            get
            {
                return _assessmentDate;
            }

            set
            {
                DateTime assessmentDate;

                // Verify that the user has provided a valid dat
                if (DateTime.TryParse(value, out assessmentDate))
                {
                    // Check that the date is no later than the current dat
                    if (assessmentDate > DateTime.Now)
                    {
                        // Thro an ArgumentOutOfRangException if the date is after the current dat
                        throw new ArgumentOutOfRangeException("AssessmentDat", "Assessment date must be on or before the current date");
                    }

                    // If the date is valid, then save it in the appropriate format
                    _assessmentDate = assessmentDate.ToString("d");
                }
                else
                {
                    // If the date is not in a valid format then throw an ArgumentException
                    throw new ArgumentException("AssessmentDate", "Assessment dat is not recognized");
                }
            }
        }
        
        // TODO: Exercise 2: Task 2b: Add validation to the SubjectName property
        public string SubjectName { get; set; }

        // TODO: Exercise 2: Task 2c: Add validation to the Assessment property
        public string Assessment { get; set; }

        public string Comments { get; set; }
                
        // Constructor to initialize the properties of a new Grade
        public Grade(int studentID, string assessmentDate, string subject, string assessment, string comments)
        {
            StudentID = studentID;
            AssessmentDate = assessmentDate;
            SubjectName = subject;
            Assessment = assessment;
            Comments = comments;
        }

        // Default constructor
        public Grade()
        {
            StudentID = 0;
            AssessmentDate = DateTime.Now.ToString("d");
            SubjectName = "Math";
            Assessment = "A";
            Comments = String.Empty;
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password { 
            set 
            { 
                _password = value; 
            } 
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }
        
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize the properties of a new Student
        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }

        // Default constructor 
        public Student()
        {
            StudentID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            TeacherID = 0;
        }
    }

    public class Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password
        {
            set
            {
                _password = value;
            }
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        // Constructor to initialize the properties of a new Teacher
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        // Default constructor
        public Teacher()
        {
            TeacherID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Class = String.Empty;
        }
    }
}
