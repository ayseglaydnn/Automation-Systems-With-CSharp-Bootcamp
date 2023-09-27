using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shopping
{
    public double Amount { get; set; }
    public DateTime Date { get; set; }

    public Shopping(double amount)
    {
        Amount = amount;
        Date = DateTime.Now;
    }
}
