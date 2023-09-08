namespace MyOwnBank.Contracts.ClientClasses;

public class CreateClientRequest
{
    public string Name {get;set;}
    public int Age{get;set;}
    public string Login {get;set;}
    public string Password{get;set;}
    

    public void DoNothing()
    {
        System.Console.WriteLine("hhhhhh");
    }
}
