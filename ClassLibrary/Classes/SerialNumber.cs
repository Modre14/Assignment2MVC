using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ClassLibrary
{
    public class SerialNumber : ISerialNumber
    {
        private string SerialNumberFile = "SerialNumberFile.dat";


        //used to generate the serial numbers
        public void GenerateSerialNumbers()
        {
            var listOfKeys = new List<string>();

            for (var i = 0; i < 100; i++)
            {
                listOfKeys.Add("A" + i);
            }

            using (Stream stream = File.Open(SerialNumberFile, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, listOfKeys);

            }
            

        }

        //Reads all the Serialnumbers in the list
        public IEnumerable<string> ReadSerialNumbers()
        {
            using (Stream stream = File.Open(SerialNumberFile, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                var listOfKeys = (List<string>)binaryFormatter.Deserialize(stream);

                return listOfKeys;
            }
        }

        //Checks if the user serial number is in the list of keys 
        public bool ValidateSerialNumber(string usersSerialNumber)
        {
            var listOfKeys = ReadSerialNumbers();
            return listOfKeys.Contains(usersSerialNumber);
        }
    }
}
