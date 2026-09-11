using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContacctsConsolApp_PresentationLayer
{
    internal class Program
    {
        static bool ContactIsExist(int ID)
        {
            return(clsContact.IsContactExist(ID));
        }

        static void ContactFind(int ID)
        {
            // 1- create clsContact opject to store the comming data it
            // 2- if object not null
            //      - print it
            //    else
            //      - pritn not found

            clsContact contact = clsContact.Find(ID);

            if (contact != null)
            {
                Console.WriteLine(contact.Firstname + " " + contact.Lastname);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.Phone);
                Console.WriteLine(contact.Address);
                Console.WriteLine(contact.DateOfBirth);
                Console.WriteLine(contact.CountryID);
                Console.WriteLine(contact.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact With ID [" + ID + "] is Not Found!");
            }
        }

        static void ContactAddNew()
        {
            clsContact contact = new clsContact();

            contact.Firstname = "salem";
            contact.Lastname = "Mohammed";
            contact.CountryID = 1;
            contact.ImagePath = "";
            contact.Phone = "22887463";
            contact.Email = "dawood.m@g.com";
            contact.Address = "address 123 22 9";
            contact.DateOfBirth = DateTime.Now;

            if (contact.Save())
            {
                Console.WriteLine($"the new contact which id is: {contact.ID} is added");
            }
        }
        static void ContactUpdate(int ID)
        {
            clsContact contact1 = clsContact.Find(ID);

            if (contact1 != null)
            {
                contact1.Firstname = "mahmood";
                contact1.Lastname = "salem";
                contact1.CountryID = 1;
                contact1.ImagePath = "";
                contact1.Phone = "22887463";
                contact1.Email = "mahmood.m@g.com";
                contact1.Address = "address 123 22 9";
                contact1.DateOfBirth = DateTime.Now;

                if (contact1.Save())
                {
                    Console.WriteLine("contact is updated successfully");
                }
            }
            else
            {
                Console.WriteLine("contact is not updated");

            }
        }

        static void ContactDelete(int ID)
        {
            if (ContactIsExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                    Console.WriteLine("contct Deleted successfully");
                else
                    Console.WriteLine("Contact Can't be deleted");
            }
            else
            {
                Console.WriteLine("Contact Can't be found");
            }
        }

        static void ContactShowList()
        {
            DataTable DT = clsContact.GetAllContacts();

            foreach (DataRow row in DT.Rows)
            {
                Console.WriteLine(row["Firstname"] + "  " + row["Lastname"]);
            }
        }

        // =============================================
        // Country Methods
        static void CountryIsExist(string Name)
        {
            if (clsCountry.IsCountryExist(Name))
            {
                Console.WriteLine(Name + " Is Exist.");
            }
            else
            {
                Console.WriteLine(Name + " Is Not Exist.");
            }
        }

        static void CountryFind(string Name)
        {
            // 1- create clsContact opject to store the comming data it
            // 2- if object not null
            //      - print it
            //    else
            //      - pritn not found

            clsCountry country  = clsCountry.Find(Name);

            if (country != null)
            {
                Console.WriteLine(country.Name);
                Console.WriteLine(country.Code);
                Console.WriteLine(country.PhoneCode);
            }
            else
            {
                Console.WriteLine("Contact With ID [" + Name + "] is Not Found!");
            }
        }

        // =============================================
        // Entry Point

        static void Main(string[] args)
        {
            //ContactFind(2);
            //ContactAddNew();
            //ContactUpdate(1);
            //ContactDelete(1);
            //ContactShowList();
            // ContactIsExist(2);
            //ContactIsExist(100);
            CountryFind("Canada");



            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
