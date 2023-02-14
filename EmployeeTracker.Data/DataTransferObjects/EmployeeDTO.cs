namespace EmployeeTracker.Data.DataTransferObjects
{
    public class EmployeeDTO
    {
        #region Constructors 

        public EmployeeDTO(int id, Guid guid, string firstName, string lastName, DateTime dateOfBirth, string encryptedSSN)
        {
            Id = id;
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            EncryptedSSN = encryptedSSN;
        }

        public EmployeeDTO(int id, Guid guid, string firstName, string lastName, DateTime dateOfBirth, string encryptedSSN, DateTime createdAtDateTimeUTC)
            :this(id, guid, firstName, lastName, dateOfBirth, encryptedSSN)
        {
            CreatedAtDateTimeUTC = createdAtDateTimeUTC;
        }

        #endregion

        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EncryptedSSN { get; set; }
    }
}
