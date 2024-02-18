using System;

class Program
{
    static void Main(string[] args)
    {
    Fraction myFract = new Fraction();
    Fraction myFract2 = new Fraction(5);
    Fraction myFract3 = new Fraction(5,2);

    Console.WriteLine($"myFract: {myFract.GetFractionString()}, myFract2: {myFract2.GetFractionString()}, myFract3: {myFract3.GetFractionString()} ");
    Console.WriteLine($"myFract: {myFract.GetDecimalValue()}, myFract2: {myFract2.GetDecimalValue()}, myFract3: {myFract3.GetDecimalValue()} ");

    }
}