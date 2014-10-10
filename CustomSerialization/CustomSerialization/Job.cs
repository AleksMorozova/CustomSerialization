using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    [Serializable]
    class Job : ISerializable
    {
        public string name;
        public int code;

        public string Name { get { return name; } set { name = value; } }
        public int Code { get { return code; } set { code = value; } }


        public Job(string name, int job)
        {
            Name = name;
            Code = code;
        }
        public Job()
        {
        }
         // Implement this method to serialize data. The method is called 
        // on serialization.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("props", Name, typeof(string));

        }

        // The special constructor is used to deserialize values.
        public Job(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Name = (string)info.GetValue("props", typeof(string));
        }
    }
}
