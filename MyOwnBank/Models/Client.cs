namespace MyOwnBank.Models;

public class Client
{
    public int Id { get; set;}
    public string Name { get; set;}
    public int Age {get;set;}
    public string Login {get;set;}
    public string Password {get;set;}
    public BankCard? BankCard{get;set;}
    
}