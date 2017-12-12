using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ClassLibrary
{
    public class SubmissionFormFileConnection
    {
        private List<SubmissionForm> _submissionForms;

        public SubmissionFormFileConnection()
        {
            _submissionForms = new List<SubmissionForm>();
            
        }

        private string SubmissionFormFile = "SubmissionFormFile.dat";

        //Add a submission to the submission file
        public void AddSubmission(SubmissionForm submission)
        {
            _submissionForms.Add(submission);
            using (Stream stream = File.Open(SubmissionFormFile, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, _submissionForms);
            }
        }

        //Reads all the submissions from the file and returns the list
        public IEnumerable<SubmissionForm> ReadSerialNumbers()
        {
            using (Stream stream = File.Open(SubmissionFormFile, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                var listOfSubmissions = (List<SubmissionForm>)binaryFormatter.Deserialize(stream);
                return listOfSubmissions;
            }
        }

        //checks if the serialNumber is used in a submissionform
        public bool IsSerialNumberUsed(string serialNumber)
        {
            return ReadSerialNumbers().All(submission => !serialNumber.Equals(submission.SerialNumber));
        }
    }
}