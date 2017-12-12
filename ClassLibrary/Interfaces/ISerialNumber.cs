using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public interface ISerialNumber
    {
         void GenerateSerialNumbers();
         IEnumerable<string> ReadSerialNumbers();
        bool ValidateSerialNumber(string usersSerialNumber);
    }
}
