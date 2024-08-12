using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// @author Omanimi
/// @version Päivämäärä
/// <summary>
/// 
/// </summary>
public class Program
{
    /// <summary>
    ///
    /// </summary>
    public static void Main()
    {
        BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

        ba.Credit(5.77);
        ba.Debit(11.22);
        Console.WriteLine("Current balance is ${0}", ba.Balance);
    }

}
