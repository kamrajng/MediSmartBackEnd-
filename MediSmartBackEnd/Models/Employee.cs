namespace MediSmartBackEnd.Models
{
    public class Employee
    {
        public Guid Id
        { get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }
        public string Bio
        {
            get;
            set;
        }
        public string Edu
        {
            get;
            set;
        }

            public string Address
        {
            get;
            set;
        }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }


    }
}
