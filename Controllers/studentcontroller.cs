using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Sample_Serializer.Domain;
using Sample_Serializer.Validator;

namespace Sample_Serializer.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class studentcontroller : ControllerBase
    {
    private static List<student> _students = new List<student>();
    private readonly StudentValidator _validator;

    public studentcontroller(StudentValidator validator)
        {
        _validator = validator;
    }
        [HttpPost]
    public IActionResult AddStudent(student student)
    {
       
        StudentValidator validator = new StudentValidator();
        ValidationResult result = _validator.Validate(student);

        if (!result.IsValid)
        {
            
            return BadRequest(result.Errors);
        }

       
           _students.Add(student);
        return Ok("Student is added successfully.");
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
          return Ok(_students);
    }
   }
