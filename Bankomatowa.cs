﻿namespace CardsCenter;
using Serilog;

public class Bankomatowa:Karta
{
    public Bankomatowa(string nrkarty) : base(nrKarty)
    {
        nrKarty = nrkarty;
    }

    public override string GetNrKarty()
    {
        return nrKarty;
    }

    public override void WyplacZKarty(double kwota)
    {
        if (kwota <= Saldo)
        {
            Console.WriteLine("Kwota "+kwota+" zostala wyplacona.");
            Saldo -= kwota;
            konto.UpdateSaldo(Saldo);
            Log.Information("Z karty bankomatowej "+Karta.nrKarty+" zostala wyplacona kwota "+kwota);
        }
        else if (kwota > Saldo)
        {
            Console.WriteLine("Nie możesz wypłacić tej kwoty, nie posiadasz takiech srodkow na koncie!");
        }
        else
        {
            Console.WriteLine("Niepoprawna kwota!");
        }
    }

    public override void WplacNaKarte(double kwota)
    {
        if (kwota > 0)
        {
            Saldo += kwota;
            Console.WriteLine("Kwota " + kwota + " zostala wplacona, saldo karty wynosi " + Saldo);
            Log.Information("Na karte bankomatowa "+Karta.nrKarty+" zostala wplacona kwota "+Saldo);
        }
        else
        {
            Console.WriteLine("Niepoprawna kwota!");
        }
    }
}
