namespace ConsoleApp1;

public class wallet
{
      public int id { get; set; }
      public string holldername { get; set; }
      public decimal balance { get; set; }
      public override string ToString()
      {
            return $"\nHolder name:  {holldername}  "
            + $"Balance is: {balance}";
      }
}
