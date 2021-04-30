using System;
using System.Linq;

namespace ClassLibraryIntegratieOOP.Models
{
    public class Bezoeker
    {
        public string Voornaam { get; protected set; }
        public string Familienaam { get; protected set; }
        public Bezoeker(string voornaam, string familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
        }
        public void RegistreerAlsLid()
        {
            bool dateParse = true;
            bool isValidGebruikersnaam = true;
            bool isValidWachtwoord = true;
            string gebruikersnaam = "";
            string wachtwoord = "";
            string verifyWachtwoord = "";
            DateTime tempDateTime;
            do
            {
                if (!dateParse)
                {
                    Console.WriteLine("Ingevoerde datum niet geldig");
                }
                Console.WriteLine("Wat is uw geboortedatum?(dd/mm/yyyy)");
                dateParse = DateTime.TryParse(Console.ReadLine(), out tempDateTime);
                
            } while (!dateParse);
            do
            {
                Console.Clear();
                Console.WriteLine("Kies een gebruikersnaam. Spaties zijn niet toegestaan.");
                Console.Write("Gebrukersnaam:");
                gebruikersnaam = Console.ReadLine();
                foreach (var item in CollectieBibliotheek.Leden)
                {
                    if (item.Gebruikersnaam == gebruikersnaam || String.IsNullOrWhiteSpace(gebruikersnaam))
                    {
                        isValidGebruikersnaam = false;
                    }
                }
                for (int i = 0; i < gebruikersnaam.Length; i++)
                {
                    if (gebruikersnaam[i] == ' ')
                    {
                        isValidGebruikersnaam = false;
                    }
                }
            } while (!isValidGebruikersnaam);
            do
            {
                if (!isValidWachtwoord)
                {
                    Console.WriteLine("Het wachtwoord komt niet overeen\nmet het geverifieerde wachtwoord!");
                }
                Console.WriteLine("Kies een wachtwoord. Druk enter om lid te worden zonder wachtwoord");
                Console.Write("Wachtwoord:");
                wachtwoord = Console.ReadLine();
                
                if (wachtwoord != ""&&wachtwoord != " ")
                {
                    Console.Clear();
                    Console.WriteLine("Verifieer je wachtwoord:");
                    Console.Write("Wachtwoord:");
                    verifyWachtwoord = Console.ReadLine();
                    if (verifyWachtwoord != wachtwoord)
                    {
                        isValidWachtwoord = false;
                    }
                }
            } while (!isValidWachtwoord);
            CollectieBibliotheek.Leden.Add(new Lid(Voornaam, Familienaam, tempDateTime, gebruikersnaam, wachtwoord));
            CollectieBibliotheek.SaveUsersToFile();
            CollectieBibliotheek.CreateNewUserDataFolder(gebruikersnaam); 
            Console.WriteLine($"Proficiat {Voornaam} {Familienaam}, u bent nu lid van de bibliotheek!");
            Console.WriteLine($"Uw gebruikersnaam: {gebruikersnaam}\nUw geboortedatum: {tempDateTime.Day}/{tempDateTime.Month}/{tempDateTime.Year} ");
            Console.WriteLine("Druk enter in te loggen als lid!");
            Console.ReadLine();
            Console.Clear();
            Menu.LidMenu(gebruikersnaam);
        }
        public virtual void ZoekItem()
        {
            Console.Clear();
            string input = "";
            bool itemGevonden = false;
            Console.WriteLine("Wilt u zoeken op titel of ID?");
            input = Console.ReadLine();
            if (input.ToLower() == "titel")
            {
                Console.WriteLine("Geeft de titel:");
                input = Console.ReadLine();
                foreach (var item in CollectieBibliotheek.ItemsInCollectie)
                {
                    if (item.Titel.ToLower() == input.ToLower())
                    {
                        Console.WriteLine("Item gevonden:");
                        Console.WriteLine(item);
                        itemGevonden = true;
                    }
                }
                if (!itemGevonden)
                {
                    Console.WriteLine($"Geen items met titel '{input}' gevonden");
                }
            }
            else if (input.ToLower() == "id")
            {
                Console.WriteLine("Geeft ID:");
                input = Console.ReadLine();
                foreach (var item in CollectieBibliotheek.ItemsInCollectie)
                {
                    if (item.ItemId.ToString().ToLower() == input.ToLower())
                    {
                        Console.WriteLine("Item gevonden:");
                        Console.WriteLine(item);
                        itemGevonden = true;
                    }
                }
                if (!itemGevonden)
                {
                    Console.WriteLine($"Geen item met ID '{input}' gevonden");
                }
            } 
        }
        public virtual void ToonOverzicht()
        {
            string input;
            Console.WriteLine("Kies welk overzicht je wilt zien:");
            Console.WriteLine("[1]Alle items in de collectie");
            Console.WriteLine("[2]Afgevoerde items");
            Console.WriteLine("[3]Beschikbare items");
            Console.WriteLine("[4]Niet beschikbare items");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Overzicht volledige collectie:\n");
                    ToonOverzichtCollectie();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Overzicht afgevoerde items:\n");
                    ToonOverzichtAfgevoerd();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Overzicht beschikbare items:\n");
                    ToonOverzichtBeschikBaar();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Overzicht niet beschikbare items:\n");
                    ToonOverzichtNietBeschikbaar();
                    break;
                default:
                    break;
            }
        }
        public virtual void ToonOverzichtCollectie()
        {
            if (CollectieBibliotheek.ItemsInCollectie.Count() == 0)
            {
                Console.WriteLine("Geen items");
                Console.WriteLine();
            }
            else
            {
                foreach (Item item in CollectieBibliotheek.ItemsInCollectie)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
        }
        public virtual void ToonOverzichtAfgevoerd()
        {
            if (CollectieBibliotheek.AfgevoerdeItems.Count() == 0)
            {
                Console.WriteLine("Geen items");
                Console.WriteLine();
            }
            else
            {
                foreach (Item item in CollectieBibliotheek.AfgevoerdeItems)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
        }
        public virtual void ToonOverzichtBeschikBaar()
        {
            bool noItems = true;
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie)
            {
                if (!item.Uitgeleend)
                {
                    noItems = false;
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            if (noItems)
            {
                Console.WriteLine("Geen items");
                Console.WriteLine();
            }
        }
        public virtual void ToonOverzichtNietBeschikbaar()
        {
            bool noItems = true;
            foreach (Item item in CollectieBibliotheek.ItemsInCollectie)
            {
                if (item.Uitgeleend)
                {
                    noItems = false;
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            if (noItems)
            {
                Console.WriteLine("Geen items");
                Console.WriteLine();
            }
        }
    }
}
