using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    [Serializable]
    class Person: ISerializable
    {
        public string name;
        public int age;
        public Job job;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public Job Job { get { return job; } set { job = value; } }

        public Person(string name, int age, Job job)
        {
            Name = name;
            Age = age;
            Job = job;
        }

        public Person()
        {
        }

         // Implement this method to serialize data. The method is called 
        // on serialization.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("props", Name, typeof(string));
            info.AddValue("props1", Job, typeof(Job));

        }

        // The special constructor is used to deserialize values.
        public Person(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Name = (string)info.GetValue("props", typeof(string));
            job = (Job)info.GetValue("props1", typeof(Job));
        }
    }
}
