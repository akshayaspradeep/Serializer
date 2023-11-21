using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample_Serializer.Domain;
using Sample_Serializer.Services;

  namespace Sample_Serializer.Controllers
  {
     [ApiController]
     [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
   
        private readonly IJsonSerializer _serializer;

         public BookController(IJsonSerializer serializer)
         {
             _serializer = serializer;
         }

          [HttpGet]
      
         public IActionResult DataEntry()
         {
            
             var book = new List<Book>()        
            {
              new Book()
             {
                BookId = 1,
                 Name = "Pokemon",
                DateofPublish = "20/10/1999",
                 Author = "Akhil",
                Price = 100
             },
             new Book()
             {
                 BookId = 2,
               Name = "Harry Potter",
                 DateofPublish = "20/05/1995",
                 Author = "Andrews",
                 Price = 500
             }
         };

             // Serialize using custom serializer
            var json = _serializer.Serialize(book);

             // Deserialize using custom serializer
             var deserializedItems = _serializer.Deserialize<List<Book>>(json);
                
                 
             return Ok(deserializedItems);
         }
         
    }
 }