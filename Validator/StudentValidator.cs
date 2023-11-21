using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;
using Sample_Serializer.Domain;
namespace Sample_Serializer.Validator
{
    public class StudentValidator : AbstractValidator<student> 
    {
        public StudentValidator()
        {
            RuleFor(student => student.FirstName).NotEmpty();
            RuleFor(student => student.LastName).NotEmpty();
            RuleFor(student => student.Age).InclusiveBetween(10,20);
            RuleFor(student =>student.Gender).Must(gender => gender == "Male" || gender == "Female");
            RuleFor(student => student.PhoneNumber).NotEmpty().Matches(@"^\d{10}$");
            RuleFor(student => student.EmailAddress).EmailAddress();   
            
        }

        
    }
}