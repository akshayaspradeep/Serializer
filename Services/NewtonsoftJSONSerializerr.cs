using System.Net;
using Newtonsoft.Json;
using Sample_Serializer.Domain;

namespace Sample_Serializer.Services
{
    public class NewtonsoftJSONSerializer : IJsonSerializer
  {
        
    public string Serialize<T>(T obj)
    {
      string serializedObject = JsonConvert.SerializeObject(obj);
      return serializedObject;
    }

  public T  Deserialize<T>(string d)
    {
      try
      {
         T ? deserializedObject = JsonConvert.DeserializeObject<T>(d);  
         return deserializedObject ?? throw new Exception("Deserialization resulted in a null object");
    
      }
      catch (JsonException e)
      {
        throw new Exception(e.Message);
      }

    }

        
    }
}