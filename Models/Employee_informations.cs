using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Check_In.Models
{
    [FirestoreData]
    public class Employee_informations
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string gender { get; set; }
        [FirestoreProperty]
        public int Age { get; set; }
        [FirestoreProperty]
       
        public string Password { get; set; }
        [FirestoreProperty]
        public int Salary { get; set; }
        [FirestoreProperty]
        public string Position { get; set; }
    }
}
