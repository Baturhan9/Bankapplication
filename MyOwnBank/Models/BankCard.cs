using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnBank.Models;

public class BankCard
{
    public int Id { get; set;}
    public string MainNumbers {get;set;}
    public int CVVCard {get;set;}
    public DateTime ValidThru {get;set;} 
    [ForeignKey("client")]
    public int ClientId {get;set;}
    public float Balance {get;set;}

    public Client client {get;set;}
}