using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VCardEater
{
    public class VCardMaker
    {
        static void Main(string[] args)
        {
              string Ender;
            do
            {
                PersonClass Contact = new PersonClass();
                while (Contact.First_Name == string.Empty)
               
                {
                    Console.WriteLine("What is the Client's First Name?");
                    Contact.First_Name = Console.ReadLine().Trim();
                } 
                
                while (Contact.Last_Name == string.Empty)
                {
                    Console.WriteLine("What is the Client's Last Name?");
                    Contact.Last_Name = Console.ReadLine().Trim();
                }
            
            Console.WriteLine("If they have a middle name, enter it. Otherwise, just press [Enter]");
            Contact.Middle_Name = Console.ReadLine().Trim();


            Contact.Full_Name = new PersonClass().Full_Name_Maker(Contact);

            string AddressSelector= "x" ;
            while (AddressSelector != string.Empty)
            {
                Console.WriteLine("Is this address for the client's [H]ome, [W]ork, or [O]ther?");
                Console.WriteLine(@"(To end editing addresses, just press [Enter])");
                AddressSelector = Console.ReadKey().ToString().ToLower();

                if (AddressSelector == "h") Contact.Address.AddressType = "HOME";
                else if (AddressSelector == "w") Contact.Address.AddressType = "WORK";
                else if (AddressSelector == string.Empty) continue;
                else
                {
                    Console.WriteLine("What type of address is this?");
                    Contact.Address.AddressType = Console.ReadLine().ToUpper();
                }
                Console.WriteLine("What is the client's street address?");
                Contact.Address.AddressFirstLine = Console.ReadLine().ToUpper().Trim();
                Console.WriteLine("If the address has a second line, enter it. Otherwise, just press [Enter]");
                Contact.Address.AddressSecondLine = Console.ReadLine().ToUpper().Trim();
                Console.WriteLine("What is the client's city?");
                Contact.Address.City = Console.ReadLine().ToUpper().Trim();
                while (Contact.Address.State.Length !=2)
                {
                Console.WriteLine("What is the client's state abbreviation?");
                Contact.Address.State = Console.ReadLine();	
                }


            }

            new VCardMaker().SpitToFile(Contact);
            Console.WriteLine("Type exit to end. Press enter to create another VCard.");
            Ender = Console.ReadLine().Trim().ToLower();
            } while (Ender != "exit");
        }

        public void SpitToFile(PersonClass person)
        {
           
            string FileName= string.Format("{2}{0}_{1}.vcf", person.Last_Name, person.First_Name, @"c:\temp\");
            using (var fw = new StreamWriter(FileName))
            {
                // write to the file
                fw.WriteLine("BEGIN:VCARD");
                fw.WriteLine("VERSION:3.0");
                fw.WriteLine(String.Format("N:{0};{1}", person.Last_Name, person.First_Name));
                fw.WriteLine("FN:" + person.Full_Name);
                fw.WriteLine(String.Format("REV:{0}", System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")));
                fw.WriteLine("END:VCARD");
                // close the stream
                fw.Close();
            }
        }

        public class PersonClass
        {
            /// <summary>
            /// Initializes a new instance of the PersonClass class.
            /// </summary>
            public PersonClass()
            {
                First_Name = string.Empty;
                Last_Name = string.Empty;
                Middle_Name = string.Empty;
                Organization = string.Empty;
                Title = string.Empty;
            }
            public  string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Middle_Name { get; set; }
            public string Full_Name { get; set; }
            public string Organization { get; set; }
            public string Title { get; set; }
            public List<Address> Addresses { get; set; }

            public IEnumerable<Phone> PhoneNumbers { get; set; }
            

            public string Full_Name_Maker(PersonClass person)
            {
                var first = person.First_Name;
                var middle = person.Middle_Name;
                var last = person.Last_Name;
                string full;

                if (middle == string.Empty)
                {
                    full = String.Format("{0} {1}", first, last);
                }
                else full = String.Format("{0} {1} {2}", first, middle, last);
                return full;

            }
       
        }
        public class Address
        {
            public Address()
            {
                ZipCode = string.Empty;
                State = string.Empty;
                City = string.Empty;
                AddressFirstLine = string.Empty;
                AddressSecondLine = string.Empty;
                AddressType = string.Empty;
            }
            public string ZipCode { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string AddressFirstLine { get; set; }
            public string AddressSecondLine { get; set; }
            public string AddressType { get; set; }
        }
        public class Phone
        {
            public Phone()
            {
                PhoneType = string.Empty;
                PhoneNumber = string.Empty;
            }
            public string PhoneType { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
