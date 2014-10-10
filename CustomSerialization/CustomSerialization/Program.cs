using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    class Program
    {
        public static void SerializeItem(string fileName, IFormatter formatter)
        {
            // Create an instance of the type and serialize it.
            Person person = new Person();
            Job job = new Job();
            person.Name = "Ben";
            person.Age = 39;
            job.Name = "Tester";
            job.Code = 12345;
            person.Job = job;

            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, person);
            s.Close();
        }


        public static void DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            Person p = (Person)formatter.Deserialize(s);
            Console.WriteLine("Name " + p.Name+ " " +"Job "+p.Job.Name+" "+p.Job.Code);
        } 

        static void Main(string[] args)
        {
            // This is the name of the file holding the data. You can use any file extension you like.
            string fileName = "dataStuff.myData";

            // Use a BinaryFormatter or SoapFormatter.
            IFormatter formatter = new BinaryFormatter();
            //IFormatter formatter = new SoapFormatter();

            SerializeItem(fileName, formatter); // Serialize an instance of the class.
            DeserializeItem(fileName, formatter); // Deserialize the instance.
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
