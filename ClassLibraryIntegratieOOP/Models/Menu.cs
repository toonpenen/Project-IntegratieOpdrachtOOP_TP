using System;

namespace ClassLibraryIntegratieOOP.Models
{
    public static class Menu
    {
        public static void StartScherm()
        {
            int userIntInput = 1;
            bool intParse = true;   
            do
            {
                Console.Clear();
                Console.WriteLine("Welkom in de bibliotheek");
                if (!intParse || userIntInput > 3 || userIntInput < 1)
                {
                    Console.WriteLine("Ongeldige input");
                } 
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Inloggen als lid");
                Console.WriteLine("[2]Inloggen als medewerker");
                Console.WriteLine("[3]Doorgaan als bezoeker");
                Console.WriteLine("[4]Afsluiten");
                intParse = Int32.TryParse(Console.ReadLine(), out userIntInput);
            } while (!intParse || userIntInput > 4|| userIntInput < 1);
            switch (userIntInput)
            {
                case 1:
                    LidInlogMenu();
                    break;
                case 2:
                    MedewerkerInlogMenu();
                    break;
                case 3:
                    BezoekerInlogMenu();
                    break;
                case 4:
                    break;
                default:
                    throw new Exception("Ingeven index bestaat niet! (Menu startscherm)");
            }
        }
        private static void LidInlogMenu()
        {
            string gebruikersnaam;
            string wachtwoord;
            bool isValidGebruikersnaam = true;
            bool isValidWachtwoord = true;
            int accountIndex = -1;
            do
            {
                if (!isValidGebruikersnaam)
                {
                    Console.Clear();
                    Console.WriteLine("Ingevoerde gebruikersnaam is niet geldig!");
                }
                isValidGebruikersnaam = false;
                Console.WriteLine("Voer uw gebruikersnaam in");
                Console.Write("Gebruikersnaam:");
                gebruikersnaam = Console.ReadLine();
                for (int i = 0; i < CollectieBibliotheek.Leden.Count; i++)
                {
                    if (CollectieBibliotheek.Leden[i].Gebruikersnaam == gebruikersnaam && CollectieBibliotheek.Leden[i] is Medewerker == false)
                    {
                        isValidGebruikersnaam = true;
                        accountIndex = i;
                    }
                }
            } while (!isValidGebruikersnaam);
            if (!String.IsNullOrWhiteSpace(CollectieBibliotheek.Leden[accountIndex].Wachtwoord))
            {
                do
                {
                    if (!isValidWachtwoord)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingevoerde wachtwoord is niet correct.");
                    }
                    Console.WriteLine("Voer uw wachtwoord in");
                    Console.Write("Wachtwoord:");
                    wachtwoord = Console.ReadLine();
                    if (CollectieBibliotheek.Leden[accountIndex].Wachtwoord == wachtwoord)
                    {
                        isValidWachtwoord = true;
                    }
                    else
                    {
                        isValidWachtwoord = false;
                    }
                } while (!isValidWachtwoord);
            }
            LidMenu(gebruikersnaam);
        }
        private static void MedewerkerInlogMenu()
        {
            string gebruikersnaam;
            string wachtwoord;
            bool isValidGebruikersnaam = true;
            bool isValidWachtwoord = true;
            int accountIndex = -1;
            do
            {
                if (!isValidGebruikersnaam)
                {
                    Console.Clear();
                    Console.WriteLine("Ingevoerde gebruikersnaam is niet geldig!");
                }
                isValidGebruikersnaam = false;
                Console.WriteLine("Voer uw gebruikersnaam in");
                Console.Write("Gebruikersnaam:");
                gebruikersnaam = Console.ReadLine();
                for (int i = 0; i < CollectieBibliotheek.Leden.Count; i++)
                {
                    if (CollectieBibliotheek.Leden[i].Gebruikersnaam == gebruikersnaam && CollectieBibliotheek.Leden[i] is Medewerker == true)
                    {
                        isValidGebruikersnaam = true;
                        accountIndex = i;
                    }
                }
            } while (!isValidGebruikersnaam);
            if (!String.IsNullOrWhiteSpace(CollectieBibliotheek.Leden[accountIndex].Wachtwoord))
            {
                do
                {
                    if (!isValidWachtwoord)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingevoerde wachtwoord is niet correct.");
                    }
                    Console.WriteLine("Voer uw wachtwoord in");
                    Console.Write("Wachtwoord:");
                    wachtwoord = Console.ReadLine();
                    if (CollectieBibliotheek.Leden[accountIndex].Wachtwoord == wachtwoord)
                    {
                        isValidWachtwoord = true;
                    }
                    else
                    {
                        isValidWachtwoord = false;
                    }
                } while (!isValidWachtwoord);
            }
            MedewerkerMenu(gebruikersnaam);
        }
        private static void BezoekerInlogMenu()
        {
            bool isNaamValid = true;
            string voornaam = "";
            string familienaam = "";
            do
            {
                Console.Clear();
                if (!isNaamValid)
                {
                    Console.WriteLine("De ingegeven naam is niet geldig!");
                }
                Console.WriteLine("Wat is uw voornaam?");
                Console.Write("Voornaam:");
                voornaam = Console.ReadLine();
                Console.Write("Familienaam:");
                familienaam = Console.ReadLine();
                
                if (String.IsNullOrEmpty(voornaam) || String.IsNullOrEmpty(familienaam))
                {
                    isNaamValid = false;
                }
                else
                {
                    isNaamValid = true;
                }
            } while (!isNaamValid);
            BezoekerMenu(voornaam, familienaam);
            
        }
        private static void BezoekerMenu(string voornaam, string familienaam) 
        {
            int userIntInput = 1;
            bool intParse = true;
            Bezoeker bezoeker = new Bezoeker(voornaam, familienaam);
            do
            {
                if (!intParse || userIntInput > 3 || userIntInput < 1)
                {
                    Console.WriteLine("Ongeldige input");
                }
                Console.Clear();
                Console.WriteLine($"Welkom {bezoeker.Voornaam} {familienaam}!");
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Registreer als lid\n[2]Zoek een item\n[3]Geef overzichten\n[4]Log uit");
                intParse = Int32.TryParse(Console.ReadLine(), out userIntInput);
            } while (!intParse || userIntInput > 4 || userIntInput < 1);
            switch (userIntInput)
            {
                case 1:
                    bezoeker.RegistreerAlsLid();
                    break;
                case 2:
                    bezoeker.ZoekItem();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    BezoekerMenu(bezoeker.Voornaam, bezoeker.Familienaam);
                    break;
                case 3:
                    bezoeker.ToonOverzicht();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    BezoekerMenu(bezoeker.Voornaam, bezoeker.Familienaam);
                    break;
                case 4:
                    Console.Clear();
                    StartScherm();
                    break;
                default:
                    throw new Exception("Ingegeven index bestaat niet! (Menu bezoeker)");
            }
        }
        internal static void LidMenu(string gebruikersNaam)
        {
            int inputInt = 1;
            bool intParse = true;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            Console.Clear();
            Console.WriteLine($"Welkom {CollectieBibliotheek.Leden[accountIndex].Voornaam} {CollectieBibliotheek.Leden[accountIndex].Familienaam}");
            do
            {
                if (inputInt<0||inputInt>9||!intParse)
                {
                    Console.WriteLine("Ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Zoek een item");
                Console.WriteLine("[2]Toon overzichten");
                Console.WriteLine("[3]Leen een item uit");
                Console.WriteLine("[4]Reserveer een item");
                Console.WriteLine("[5]Breng een item terug");
                Console.WriteLine("[6]Bekijk uitleenhistoriek");
                Console.WriteLine("[7]Bekijk uitgeleende items");
                Console.WriteLine("[8]Bekijk gereserveerde items");
                Console.WriteLine("[9]Log uit en keer terug");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 0 || inputInt > 9 || !intParse);
            switch (inputInt)
            {
                case 1:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ZoekItem();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    LidMenu(gebruikersNaam);
                    break;
                case 2:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonOverzicht();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    LidMenu(gebruikersNaam);
                    break;
                case 3:
                    Console.Clear();
                    UitleenMenu(gebruikersNaam);
                    break;
                case 4:
                    Console.Clear();
                    ReservatieMenu(gebruikersNaam);
                    break;
                case 5:
                    Console.Clear();
                    TerugbrengMenu(gebruikersNaam);
                    break;
                case 6:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonUitleenHistoriek();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    LidMenu(gebruikersNaam);
                    break;
                case 7:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonItemsUitgeleend();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    LidMenu(gebruikersNaam);
                    break;
                case 8:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonGereserveerdeItems();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    LidMenu(gebruikersNaam);
                    break;
                case 9:
                    Console.Clear();
                    StartScherm();
                    break;
                default:
                    break;
            }

        }
        private static void MedewerkerMenu(string gebruikersNaam)
        {  
            int inputInt = 1;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            bool intParse = true;
            Console.Clear();
            Console.WriteLine($"Welkom {CollectieBibliotheek.Leden[accountIndex].Voornaam} {CollectieBibliotheek.Leden[accountIndex].Familienaam}");
            do
            {
                if (inputInt < 0 || inputInt > 9 || !intParse)
                {
                    Console.WriteLine("Ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Zoek een item");
                Console.WriteLine("[2]Toon overzichten");
                Console.WriteLine("[3]Leen een item uit");
                Console.WriteLine("[4]Reserveer een item");
                Console.WriteLine("[5]Breng een item terug");
                Console.WriteLine("[6]Bekijk uitleenhistoriek");
                Console.WriteLine("[7]Bekijk uitgeleende items");
                Console.WriteLine("[8]Bekijk gereserveerde items");
                Console.WriteLine("[9]Promoveer een lid naar medewerker");
                Console.WriteLine("[10]Voeg een item toe aan de collectie");
                Console.WriteLine("[11]Voer een item af uit de collectie");
                Console.WriteLine("[12]Log uit en keer terug");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 0 || inputInt > 12 || !intParse);
            switch (inputInt)
            {
                case 1:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ZoekItem();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 2:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonOverzicht();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 3:
                    Console.Clear();
                    UitleenMenu(gebruikersNaam);
                    break;
                case 4:
                    Console.Clear();
                    ReservatieMenu(gebruikersNaam);
                    break;
                case 5:
                    Console.Clear();
                    TerugbrengMenu(gebruikersNaam);
                    break;
                case 6:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonUitleenHistoriek();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 7:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonItemsUitgeleend();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 8:
                    Console.Clear();
                    CollectieBibliotheek.Leden[accountIndex].ToonGereserveerdeItems();
                    Console.WriteLine("Druk enter om terug te keren");
                    Console.ReadLine();
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 9:
                    Console.Clear();
                    PromoveerMenu(gebruikersNaam);
                    break;
                case 10:
                    Console.Clear();
                    ToevoegMenu(gebruikersNaam);
                    break;
                case 11:
                    Console.Clear();
                    AfvoerMenu(gebruikersNaam);
                    break;
                case 12:
                    Console.Clear();
                    StartScherm();
                    break;
                default:
                    break;
            }
        }
        private static void UitleenMenu(string gebruikersNaam)
        {
            string inputID = "";
            int itemIndex = 0;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            bool itemLeenbaar = false;
            CollectieBibliotheek.Leden[accountIndex].ToonOverzichtBeschikBaar();
            Console.WriteLine("Geef het ID van het item dat u wenst uit te lenen");
            Console.Write("ID:");
            inputID = Console.ReadLine();
            for (int i = 0; i < CollectieBibliotheek.ItemsInCollectie.Count; i++)
            {
                if (CollectieBibliotheek.ItemsInCollectie[i].ItemId == inputID )
                {
                    Console.WriteLine("Item gevonden.");
                    if (CollectieBibliotheek.ItemsInCollectie[i].Uitgeleend == false)
                    {
                        
                        if (CollectieBibliotheek.ItemsInCollectie[i].Gereserveerd == true)
                        {
                            
                            if (CollectieBibliotheek.Leden[accountIndex].IsGereserveerd(CollectieBibliotheek.ItemsInCollectie[i]))
                            {
                                itemLeenbaar = true;
                                itemIndex = i;
                                Console.WriteLine("Je hebt dit item gereserveert. Item beschikbaar.");
                            }
                            else
                            {
                                itemLeenbaar = false;
                                Console.WriteLine("Een andere gebruiker heeft dit item gereserveert");
                            }
                        }
                        else
                        {
                            itemLeenbaar = true;
                            itemIndex = i;
                            Console.WriteLine("Item beschikbaar.");
                        }
                        
                    }
                    else if (CollectieBibliotheek.ItemsInCollectie[i].Uitgeleend == true)
                    {
                        Console.WriteLine("Item niet beschikbaar.");
                    }
                }
            }
            if (itemLeenbaar == true)
            {
                
                CollectieBibliotheek.Leden[accountIndex].Uitlenen(CollectieBibliotheek.ItemsInCollectie[itemIndex]);
                
                
                Console.WriteLine($"Item met ID:{inputID} werd uitgeleend door gebruiker {CollectieBibliotheek.Leden[accountIndex].Gebruikersnaam}");
            }
            else
            {
                Console.WriteLine("Het gekozen item kon niet worden uitgeleend");
            }
            int inputInt = 1;
            bool intParse = true;
            do
            {
                if (inputInt<1||inputInt>2||!intParse)
                {
                    Console.Clear();
                    Console.WriteLine("Het ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Keer terug");
                Console.WriteLine("[2]Leen een ander item uit");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 1 || inputInt > 2 || !intParse);
            switch (inputInt)
            {
                case 1:
                    if (CollectieBibliotheek.Leden[accountIndex] is Medewerker)
                    {
                        MedewerkerMenu(gebruikersNaam);
                    }
                    else
                    {
                        LidMenu(gebruikersNaam);
                    }
                    break;
                case 2:
                    UitleenMenu(gebruikersNaam);
                    break;
                default:
                    throw new Exception("Het gekozen getal staat niet in het menu! (uitleen menu)");
            }
        }
        private static void ReservatieMenu(string gebruikersNaam)
        {
            string inputID = "";
            int itemIndex = 0;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            bool itemReserveerbaar = false;
            CollectieBibliotheek.Leden[accountIndex].ToonOverzichtBeschikBaar();
            Console.WriteLine("Geef het ID van het item dat u wenst te reserveren");
            Console.Write("ID:");
            inputID = Console.ReadLine();
            for (int i = 0; i < CollectieBibliotheek.ItemsInCollectie.Count; i++)
            {
                if (CollectieBibliotheek.ItemsInCollectie[i].ItemId == inputID)
                {
                    Console.WriteLine("Item gevonden.");
                }
                if (CollectieBibliotheek.ItemsInCollectie[i].ItemId == inputID && CollectieBibliotheek.ItemsInCollectie[i].Gereserveerd == false)
                {
                    itemReserveerbaar = true;
                    itemIndex = i;
                    Console.WriteLine("Item beschikbaar voor reservatie.");
                }
                else if (CollectieBibliotheek.ItemsInCollectie[i].ItemId == inputID && CollectieBibliotheek.ItemsInCollectie[i].Gereserveerd == true)
                {
                    if (CollectieBibliotheek.Leden[accountIndex].IsGereserveerd(CollectieBibliotheek.ItemsInCollectie[i]))
                    {
                        Console.WriteLine("Je hebt dit item al gereserveert!");
                    }
                    else
                    {
                        Console.WriteLine("Item is al gereserveerd door een andere gebruiker.");
                    }
                }
            }
            if (itemReserveerbaar == true)
            {
                CollectieBibliotheek.Leden[accountIndex].Reservatie.Add(CollectieBibliotheek.ItemsInCollectie[itemIndex]);
                CollectieBibliotheek.ItemsInCollectie[itemIndex].SetReservatie(true);
                Console.WriteLine($"Item met ID:{inputID} werd gereserveerd door gebruiker {CollectieBibliotheek.Leden[accountIndex].Gebruikersnaam}");
            }
            else
            {
                Console.WriteLine("Het gekozen item kon niet worden gereserveerd");
            }

            int inputInt = 1;
            bool intParse = true;
            do
            {
                if (inputInt < 1 || inputInt > 2 || !intParse)
                {
                    Console.Clear();
                    Console.WriteLine("Het ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Keer terug");
                Console.WriteLine("[2]Reserveer een ander item");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 1 || inputInt > 2 || !intParse);
            switch (inputInt)
            {
                case 1:
                    if (CollectieBibliotheek.Leden[accountIndex] is Medewerker)
                    {
                        MedewerkerMenu(gebruikersNaam);
                    }
                    else
                    {
                        LidMenu(gebruikersNaam);
                    }
                    break;
                case 2:
                    ReservatieMenu(gebruikersNaam);
                    break;
                default:
                    throw new Exception("Het gekozen getal staat niet in het menu! (reservatie menu)");
            }
        }
        private static void TerugbrengMenu(string gebruikersNaam)
        {
            string inputID = "";
            bool itemTeruggeefbaar = false;
            int terugbrengIndex = 0;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            CollectieBibliotheek.Leden[accountIndex].ToonItemsUitgeleend();
            Console.WriteLine("Geef het ID van het item dat u wenst terug te brengen");
            Console.Write("ID:");
            inputID = Console.ReadLine();
            
            for (int i = 0; i < CollectieBibliotheek.Leden[accountIndex].ItemsUitgeleend.Count; i++)
            {
                if (CollectieBibliotheek.Leden[accountIndex].ItemsUitgeleend[i].ItemId == inputID)
                {
                    terugbrengIndex = i;
                    Console.WriteLine("Item gevonden");
                    Console.WriteLine($"Item {CollectieBibliotheek.Leden[accountIndex].ItemsUitgeleend[i].ItemId} teruggebracht");
                    itemTeruggeefbaar = true;
                }
            }
            if (!itemTeruggeefbaar)
            {
                Console.WriteLine("Item met ingegeven ID is niet uitgeleend, dus kan niet teruggebracht worden.");
            }
            else
            {
                CollectieBibliotheek.Leden[accountIndex].Terugbrengen(CollectieBibliotheek.Leden[accountIndex].ItemsUitgeleend[terugbrengIndex]);
            }
            int inputInt = 1;
            bool intParse = true;
            do
            {
                if (inputInt < 1 || inputInt > 2 || !intParse)
                {
                    Console.Clear();
                    Console.WriteLine("Het ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Keer terug");
                Console.WriteLine("[2]Breng een ander item terug");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 1 || inputInt > 2 || !intParse);
            switch (inputInt)
            {
                case 1:
                    if (CollectieBibliotheek.Leden[accountIndex] is Medewerker)
                    {
                        MedewerkerMenu(gebruikersNaam);
                    }
                    else
                    {
                        LidMenu(gebruikersNaam);
                    }
                    break;
                case 2:
                    TerugbrengMenu(gebruikersNaam);
                    break;
                default:
                    throw new Exception("Het gekozen getal staat niet in het menu! (terugbreng menu)");
            }
        }
        private static void PromoveerMenu(string gebruikersNaam)
        {
            string inputUserName = "";
            int promoveerUserIndex = 0;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            bool kanPromoveren = false;
            bool isGevonden = false;
            if (CollectieBibliotheek.Leden[accountIndex] is Medewerker == false)
            {
                throw new Exception("Toegang tot promoveer menu geweigerd. Gebruiker is geen medewerker.");
            }
            else
            {
                Medewerker.GeefOverzichtLeden();
                Console.WriteLine("Geef de gebruikersnaam van het lid om te promoveren");
                inputUserName = Console.ReadLine();
                for (int i = 0; i < CollectieBibliotheek.Leden.Count; i++)
                {
                    if (CollectieBibliotheek.Leden[i].Gebruikersnaam == inputUserName)
                    {
                        Console.WriteLine("Lid gevonden");
                        isGevonden = true;
                        if (CollectieBibliotheek.Leden[i] is Medewerker == false)
                        {
                            kanPromoveren = true;
                            promoveerUserIndex = i;
                        }
                        else
                        {
                            Console.WriteLine($"De gebruiker {inputUserName} is al een medewerker!");
                        }
                    }
                }
                if (!isGevonden)
                {
                    Console.WriteLine($"De gebruiker {inputUserName} bestaat niet!");
                }
                if (kanPromoveren)
                {
                    Medewerker.PromoveerLidNaarMedewerker(CollectieBibliotheek.Leden[promoveerUserIndex]);
                    Console.WriteLine($"Het lid {inputUserName} is nu een medewerker!");
                }
                int inputInt = 1;
                bool intParse = true;
                do
                {
                    if (inputInt < 1 || inputInt > 2 || !intParse)
                    {
                        Console.Clear();
                        Console.WriteLine("Het ingevoerde getal is niet geldig!");
                    }
                    Console.WriteLine("Maak uw keuze:");
                    Console.WriteLine("[1]Keer terug");
                    Console.WriteLine("[2]Promoveer een andere gebruiker");
                    intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
                } while (inputInt < 1 || inputInt > 2 || !intParse);
                switch (inputInt)
                {
                    case 1:
                        MedewerkerMenu(gebruikersNaam);
                        break;
                    case 2:
                        PromoveerMenu(gebruikersNaam);
                        break;
                    default:
                        throw new Exception("Het gekozen getal staat niet in het menu! (promoveer menu)");
                }
            }
        }   
        private static void ToevoegMenu(string gebruikersNaam)
        {
            bool intParse = true;
            bool isTitelValid = true;
            bool isMakerValid = true;
            bool isJaartalValid = true;
            string maker = "";
            string makerWoord = "";
            string titel = "";
            int userIntInput = 1;
            SoortItem soortItem;
            int jaartal;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            if (CollectieBibliotheek.Leden[accountIndex] is Medewerker == false)
            {
                throw new Exception("Toegang tot toevoeg menu geweigerd. Gebruiker is geen medewerker.");
            }
            do
            {
                Console.Clear();
                if (userIntInput < 1 || userIntInput > 4 || !intParse)
                {
                    Console.WriteLine("Het ingegeven getal is niet geldig!");
                }
                Console.WriteLine("Kies een itemsoort om toe te voegen:");
                Console.WriteLine("[1]Boek");
                Console.WriteLine("[2]Stripverhaal");
                Console.WriteLine("[3]DVD");
                Console.WriteLine("[4]CD");
                intParse = Int32.TryParse(Console.ReadLine(), out userIntInput);
            } while (userIntInput<1||userIntInput>4||!intParse);
            soortItem = (SoortItem)userIntInput-1;
            do
            {
                Console.Clear();
                if (!isTitelValid)
                {
                    Console.Clear();
                    Console.WriteLine("Ingegeven title is niet geldig!");
                }
                Console.WriteLine($"Geef de titel het {soortItem} item");
                Console.Write("Titel:");
                titel = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(titel))
                {
                    isTitelValid = false;
                }
            } while (!isTitelValid);
            switch (soortItem)
            {
                case SoortItem.Boek:
                    makerWoord = "Auteur";
                    break;
                case SoortItem.Stripverhaal:
                    makerWoord = "Auteur";
                    break;
                case SoortItem.DVD:
                    makerWoord = "Regisseur";
                    break;
                case SoortItem.CD:
                    makerWoord = "Uitvoerder";
                    break;
                default:
                    throw new Exception("Ingegeven SoortItem bestaat niet (toevoeg menu)");
            }
            do
            {
                Console.Clear();
                if (!isMakerValid)
                {
                    Console.WriteLine($"Ingevoerde {makerWoord.ToLower()} is niet geldig!");
                }
                Console.WriteLine($"Voer de {makerWoord.ToLower()} in voor {titel}.");
                Console.Write(makerWoord + ":");
                maker = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(maker))
                {
                    isMakerValid = false;
                }
            } while (!isMakerValid);
            do
            {
                if (!isJaartalValid || !intParse)
                {
                    Console.WriteLine("Het ingegeven jaartal is niet geldig!");
                }
                Console.WriteLine($"Voer het jaartal voor {titel} in.");
                Console.Write("Jaartal:");
                intParse = Int32.TryParse(Console.ReadLine(),out jaartal);
                if (jaartal<0)
                {
                    isJaartalValid = false;
                }
            } while (!isJaartalValid || !intParse);
            Medewerker.VoegItemToe(new Item(soortItem,titel,maker,jaartal, false, false, false));
            int inputInt = 1;
            do
            {
                if (inputInt < 1 || inputInt > 2 || !intParse)
                {
                    Console.Clear();
                    Console.WriteLine("Het ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Keer terug");
                Console.WriteLine("[2]Voeg een ander item toe");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 1 || inputInt > 2 || !intParse);
            switch (inputInt)
            {
                case 1:
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 2:
                    ToevoegMenu(gebruikersNaam);
                    break;
                default:
                    throw new Exception("Het gekozen getal staat niet in het menu! (toevoeg menu)");
            }
        }
        private static void AfvoerMenu(string gebruikersNaam)
        {

            string inputID = "";
            int itemIndex = -1;
            bool isIDValid = true;
            int accountIndex = CollectieBibliotheek.GetAccountIndex(gebruikersNaam);
            if (CollectieBibliotheek.Leden[accountIndex] is Medewerker == false)
            {
                throw new Exception("Toegang tot afvoer menu geweigerd. Gebruiker is geen medewerker.");
            }
            do
            {
                Console.Clear();
                CollectieBibliotheek.Leden[accountIndex].ToonOverzichtCollectie();
                if (!isIDValid)
                {
                    Console.WriteLine($"Item {inputID} bestaat niet!");
                }
                Console.WriteLine("Geef het ID van het item om af te voeren");
                inputID = Console.ReadLine();
                for (int i = 0; i < CollectieBibliotheek.ItemsInCollectie.Count; i++)
                {
                    if (CollectieBibliotheek.ItemsInCollectie[i].ItemId == inputID)
                    {
                        Console.WriteLine("Item gevonden.");
                        isIDValid = true;
                        itemIndex = i;
                    }
                }
                if (itemIndex == -1)
                {
                    isIDValid = false;
                }
            } while (!isIDValid);
            Medewerker.VoerItemAf(CollectieBibliotheek.ItemsInCollectie[itemIndex]);
            Console.Clear();
            Console.WriteLine($"Item {inputID} werd afgevoerd!");
            int inputInt = 1;
            bool intParse = true;
            do
            {
                if (inputInt < 1 || inputInt > 2 || !intParse)
                {
                    Console.Clear();
                    Console.WriteLine("Het ingevoerde getal is niet geldig!");
                }
                Console.WriteLine("Maak uw keuze:");
                Console.WriteLine("[1]Keer terug");
                Console.WriteLine("[2]Voer een ander item af");
                intParse = Int32.TryParse(Console.ReadLine(), out inputInt);
            } while (inputInt < 1 || inputInt > 2 || !intParse);
            switch (inputInt)
            {
                case 1:
                    MedewerkerMenu(gebruikersNaam);
                    break;
                case 2:
                    AfvoerMenu(gebruikersNaam);
                    break;
                default:
                    throw new Exception("Het gekozen getal staat niet in het menu! (afvoer menu)");
            }
        }
    }
}
