using Ohce;
using Ohce.Console.Adapters;
using Ohce.Langues;

var ohce = new DétectionPalindrome(
    new LangueSystèmeAdapter(), 
    PériodeJournéeSystèmeAdapter.PériodeActuelle);
Console.WriteLine(ohce.TraiterChaîne("radar"));