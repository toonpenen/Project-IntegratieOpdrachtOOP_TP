using System;

namespace ClassLibraryIntegratieOOP.Models
{
    public class Medewerker:Lid
    {
        public Medewerker(string voornaam, string familienaam, DateTime geboorteDatum, string gebruikersnaam, string wachtwoord) : base(voornaam, familienaam, geboorteDatum, gebruikersnaam, wachtwoord)
        {
        }
        public static void PromoveerLidNaarMedewerker(Lid lid)
        { 
            CollectieBibliotheek.Leden.Add(new Medewerker(lid.Voornaam,lid.Familienaam,lid.GeboorteDatum,lid.Gebruikersnaam,lid.Wachtwoord));
            CollectieBibliotheek.Leden.Remove(lid);
            CollectieBibliotheek.SaveUsersToFile();
        }
        public static void VoerItemAf(Item item)
        {
            CollectieBibliotheek.AfgevoerdeItems.Add(item);
            CollectieBibliotheek.ItemsInCollectie.Remove(item);
            item.VoerAf();
            CollectieBibliotheek.SaveCollectionsToFile();
        }
        public static void VoegItemToe(Item item)
        {
            CollectieBibliotheek.ItemsInCollectie.Add(item);
            CollectieBibliotheek.SaveCollectionsToFile();
        }
        static public void GeefOverzichtLeden()
        {
            for (int i = 0; i < CollectieBibliotheek.Leden.Count; i++)
            {
                Console.WriteLine($"{CollectieBibliotheek.Leden[i]}\n");
            }
        }
        static public void GeefOverzichtMedewerkers()
        {
            foreach (var item in CollectieBibliotheek.Leden)
            {
                if (item is Medewerker)
                {
                    Console.WriteLine(item + "\n");
                }    
            }
        }
        public override void ZoekItem()
        {
            base.ZoekItem();
        }
        public override void ToonOverzicht()
        {
            string input;
            Console.WriteLine("Kies welk overzicht je wilt zien:");
            Console.WriteLine("[1]Alle items in de collectie");
            Console.WriteLine("[2]Afgevoerde items");
            Console.WriteLine("[3]Beschikbare items");
            Console.WriteLine("[4]Niet beschikbare items");
            Console.WriteLine("[5]Alle leden");
            Console.WriteLine("[6]Alle medewerkers");
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
                case "5":
                    Console.Clear();
                    Console.WriteLine("Overzicht leden:\n");
                    GeefOverzichtLeden();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Overzicht medewerkers:\n");
                    GeefOverzichtMedewerkers();
                    break;
                default:
                    throw new Exception("Ingevoerde menu index is niet geldig!");
            }
        }

        public override string ToString()
        {
            return "MEDEWERKER "+base.ToString();
        }
    }
}
