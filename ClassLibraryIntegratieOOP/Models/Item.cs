using System;

namespace ClassLibraryIntegratieOOP.Models
{
    public class Item
    {
        public SoortItem SoortItem { get; private set; }
        public string ItemId { get; private set; }
        public string Titel { get; private set; }
        public string Auteur { get; private set; }
        public string Regisseur { get; private set; }
        public string Uitvoerder { get; private set; }
        public int Jaartal { get; private set; }
        public bool Uitgeleend { get; private set; }
        public bool Gereserveerd { get; private set; }
        public bool Afgevoerd { get; private set; }

        private static int[] itemCounter = new int[Enum.GetNames(typeof(SoortItem)).Length];//telt elk soort item in enum SoortItem apart (voor de ID)
        public Item(SoortItem soortItem, string titlel, string maker, int jaartal, bool uitgeleend, bool gereserveerd, bool afgevoerd)
        {
            SoortItem = soortItem;
            ItemId = generateID(soortItem,itemCounter[(int)SoortItem]);
            Titel = titlel;
            Auteur = maker;
            Regisseur = maker;
            Uitvoerder = maker;
            Jaartal = jaartal;
            itemCounter[(int)SoortItem]++;
            Uitgeleend = uitgeleend;
            Gereserveerd = gereserveerd;
            Afgevoerd = afgevoerd;
        }
        public Item(SoortItem soortItem, string titlel, string maker, int jaartal, bool uitgeleend, bool gereserveerd, bool afgevoerd, string manualID)
        {
            SoortItem = soortItem;
            ItemId = manualID;
            Titel = titlel;
            Auteur = maker;
            Regisseur = maker;
            Uitvoerder = maker;
            Jaartal = jaartal;
            itemCounter[(int)SoortItem]++;
            Uitgeleend = uitgeleend;
            Gereserveerd = gereserveerd;
            Afgevoerd = afgevoerd;
        }
        public void LeenUit()
        {
            Uitgeleend = true;
        }
        public void BrengTerug()
        {
            Uitgeleend = false;
        }
        public void VoerAf()
        {
            Afgevoerd = true;
        }
        public void SetReservatie(bool res)
        {
            Gereserveerd = res;
        }
        public override string ToString()
        {
            switch (SoortItem)
            {
                case SoortItem.Boek:
                    return $"ID:{ItemId}\nSoort:{SoortItem}\nTitel:{Titel}\nAuteur:{Auteur}\nJaartal:{Jaartal}";
                case SoortItem.Stripverhaal:
                    return $"ID:{ItemId}\nSoort:{SoortItem}\nTitel:{Titel}\nAuteur:{Auteur}\nJaartal:{Jaartal}";
                case SoortItem.DVD:
                    return $"ID:{ItemId}\nSoort:{SoortItem}\nTitel:{Titel}\nRegisseur:{Regisseur}\nJaartal:{Jaartal}";
                case SoortItem.CD:
                    return $"ID:{ItemId}\nSoort:{SoortItem}\nTitel:{Titel}\nUitvoerder:{Uitvoerder}\nJaartal:{Jaartal}";
                default:
                    throw new Exception("Ingegeven enum SoortItem bestaat niet!"); 
            } 
        }
        private string generateID(SoortItem soortItem, int counter)
        {
            string id = "";
            int idNoLength = 4;
            string prefix = "";
            switch (soortItem)
            {
                case SoortItem.Boek:
                    prefix = "BOE";
                    break;
                case SoortItem.Stripverhaal:
                    prefix = "STR";
                    break;
                case SoortItem.DVD:
                    prefix = "DVD";
                    break;
                case SoortItem.CD:
                    prefix = "MCD";
                    break;
                default:
                    throw new Exception("Ingegeven enum SoortItem bestaat niet!");
            }
            if (counter.ToString().Length>idNoLength)//als er een langere id moet zijn dan 4 cijfers
            {
                idNoLength = counter.ToString().Length;
            }
            id = prefix + new String('0',idNoLength-counter.ToString().Length)+counter.ToString();//het nummer deel van de ID is altijd 4 cijfers of meer.
            return id;
        }
    }
}
