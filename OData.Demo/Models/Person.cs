namespace OData.Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }

    public class BankAccount
    {
        public int AccountId { get; set; }
        public string BankName { get; set; }
    }
}
