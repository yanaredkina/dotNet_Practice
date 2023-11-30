using System;
namespace Task11
{
    [Serializable]
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public Employee(): this (string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Employee(string firstname, string lastname, string middlename, string phone, string address)
        {
            FirstName = firstname.Trim().ToLower();
            LastName = lastname.Trim().ToLower();
            MiddleName = middlename.Trim().ToLower();
            Phone = phone.Trim().ToLower();
            Address = address.Trim().ToLower();
        }


        public override string ToString()
        {
            return $"Name: {LastName} {FirstName} {MiddleName}, Phone: {Phone}, Addres: {Address}";
        }
    }
}
