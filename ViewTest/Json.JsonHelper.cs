using System;
namespace ViewTest
{
    class JsonHelper : GX.JsonExtension.IJsonHelper
    {
        public T Deserialize<T>(string json)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(Type objectType, string json)
        {
            throw new NotImplementedException();
        }

        public string Serialize(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
