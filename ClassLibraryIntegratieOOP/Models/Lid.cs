using System;
using System.Collections.Generic;

namespace ClassLibraryIntegratieOOP.Models
{
    public class Lid : Bezoeker
    {
        private string _gebruikersnaam; 
        public string Gebruikersnaam 
        { 
            get 
            { 
               return _gebruikersnaam; 
            } 
            private set 
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ')
                    {
                        throw new Exception("Gebruikersnaam bevat spatie!");
                    }
                }
                _gebruikersnaam = value;
            } 
        }
        internal string Wachtwoord { get; private set; }
        public DateTime GeboorteDatum { get; private set; }
        public List<Item> UitleenHistoriek { get; internal set; }
        public List<Item> ItemsUitgeleend { get; internal set; }
        public List<Item> Reservatie { get; internal set; }
        public Lid(string voornaam, string familienaam, DateTime geboorteDatum, string gebruikersnaam, string wachtwoord) : base(voornaam, familienaam)
        {
            UitleenHistoriek = new List<Item>();
            ItemsUitgeleend = new List<Item>();
            Reservatie = new List<Item>();
            GeboorteDatum = geboorteDatum;
            Wachtwoord = wachtwoord;
            Gebruikersnaam = gebruikersnaam;
        }
        public void Uitlenen(Item item)
        {
            ItemsUitgeleend.Add(item);
            UitleenHistoriek.Add(item);
            item.LeenUit();//zet bool op true
            if (Reservatie.Contains(item))
            {
                Reservatie.Remove(item);
                item.SetReservatie(false);
            }
            CollectieBibliotheek.SaveCollectionsToFile();
            CollectieBibliotheek.SaveUserData();
        }
        public void Terugbrengen(Item item)
        {
            ItemsUitgeleend.Remove(item);
            item.BrengTerug();
            CollectieBibliotheek.SaveCollectionsToFile();
            CollectieBibliotheek.SaveUserData();
        }
        public void Reserveren(Item item)
        {
            Reservatie.Add(item);
            CollectieBibliotheek.SaveCollectionsToFile();
            CollectieBibliotheek.SaveUserData();
        }
        public override void ZoekItem()
        {
            base.ZoekItem();

        }
        public override void ToonOverzicht()
        {
            base.ToonOverzicht();
        }
        public void ToonItemsUitgeleend()
        {
            Console.WriteLine($"Uitgeleende items voor gebruiker {Gebruikersnaam}");
            if (ItemsUitgeleend.Count == 0)
            {
                Console.WriteLine("Geen items");
            }
            else
            {
                foreach (var item in ItemsUitgeleend)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void ToonUitleenHistoriek()
        {
            Console.WriteLine($"Uitleenhistoriek voor gebruiker {Gebruikersnaam}");
            if (UitleenHistoriek.Count == 0)
            {
                Console.WriteLine("Geen items");
            }
            else
            {
                foreach (var item in UitleenHistoriek)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void ToonGereserveerdeItems()
        {
            Console.WriteLine($"Gereserveerde items voor gebruiker {Gebruikersnaam}");
            if (Reservatie.Count == 0)
            {
                Console.WriteLine("Geen items");
            }
            else
            {
                foreach (var item in Reservatie)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public bool IsGereserveerd(Item item)
        {
            if (Reservatie.Contains(item))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Gebruikersnaam:{Gebruikersnaam}\nNaam:{Voornaam} {Familienaam}\nGeboortedatum:{GeboorteDatum.Day}/{GeboorteDatum.Month}/{GeboorteDatum.Year}";
        }
        
    }
}
