namespace EmployeeTracker.Data.DataRequestObjects.EmployeeRequests
{
    internal class InsertEmployee : IDataRequest
    {
        public InsertEmployee(Guid guid, string firstName, string lastName, DateTime dateOfBirth, string encryptedSSN)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            EncryptedSSN = encryptedSSN;
        }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EncryptedSSN { get; set; }

        public object? GenerateParameters() => new {Guid, FirstName, LastName, DateOfBirth, EncryptedSSN};

        public string GenerateSql() => Insert.IntoTable(Tables.Employee, "Guid", "FirstName", "LastName", "DateOfBirth", "EncryptedSSN");
    }
}
