using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer 
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime RecordingDate { get; set; }
        [NonSerialized] static int SerialNum = 0;
        [NonSerialized] public int PersonSerialNum;

        public Person(int personSerialNum)
        {
            SerialNum++;
            this.RecordingDate = DateTime.Now;
            this.PersonSerialNum = personSerialNum;
        }

        public void Serialize()
        {
            using (FileStream file = File.Create("Person" + this.PersonSerialNum+ ".dat"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(file, this);
                } catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static Person Deserialize(int personNum)
        {
            Person person = null;
            try
            {
                using (FileStream file = File.Open(@"Person" + personNum + ".dat", FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    return person = (Person)binaryFormatter.Deserialize(file);
                }
            } catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }           
            return person;                                          
        }

        public void OnDeserialization(object sender)
        {
            
        }


    }
}
