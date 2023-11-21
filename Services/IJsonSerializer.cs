using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_Serializer.Domain;

namespace Sample_Serializer.Services
{
    public interface IJsonSerializer
    {
        
       string Serialize<T>(T obj);
       T Deserialize<T>(string t);
        
    }
}