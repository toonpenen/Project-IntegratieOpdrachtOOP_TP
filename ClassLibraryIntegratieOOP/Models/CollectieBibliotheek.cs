using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibraryIntegratieOOP.Models
{
    public static class CollectieBibliotheek
    {
        public static List<Item> ItemsInCollectie { get; private set; }
        public static List<Item> AfgevoerdeItems { get; private set; }
        public static List<Lid> Leden { get; private set; }
        static CollectieBibliotheek()
        {
            ItemsInCollectie = new List<Item>();
            AfgevoerdeItems = new List<Item>();
            Leden = new List<Lid>();
        }
        public static int GetAccountIndex(string gebruikersnaam)
        {
            int index = -1;
            bool accountFound = false;
            for (int i = 0; i < Leden.Count; i++)
            {
                if (Leden[i].Gebruikersnaam == gebruikersnaam)
                {
                    accountFound = true;
                    index =  i;   
                }
            }
            if (accountFound == false)
            {
                throw new Exception("Gebruikersnaam bestaat niet!");
            }
            return index;
        }
        public static void CheckDataFiles()
        {
            //checks if files exists. creates copies from default files from data folder (copyPath).
            string dataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\Data";
            string copyPath = Environment.CurrentDirectory + @"\DefaultData";
            
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            if (!File.Exists(dataPath+ @"\CollectieBibliotheek_ItemsInCollectie.txt"))
            {
                File.Copy(copyPath+ @"\CollectieBibliotheek_ItemsInCollectie.txt", dataPath + @"\CollectieBibliotheek_ItemsInCollectie.txt");
            }
            if (!File.Exists(dataPath + @"\CollectieBibliotheek_AfgevoerdeItems.txt"))
            {
                File.Copy(copyPath + @"\CollectieBibliotheek_AfgevoerdeItems.txt", dataPath + @"\CollectieBibliotheek_AfgevoerdeItems.txt");
            }
            if (!File.Exists(dataPath + @"\CollectieBibliotheek_Leden.txt"))
            {
                File.Copy(copyPath + @"\CollectieBibliotheek_Leden.txt", dataPath + @"\CollectieBibliotheek_Leden.txt");
            }
        }
        public static void LoadUsersFromFile()
        {
            string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\Data\CollectieBibliotheek_Leden.txt"; 
            List<string> fileList = File.ReadAllLines(filePath).ToList();
            List<Lid> temp_Leden = new List<Lid>();
            fileList = File.ReadAllLines(filePath).ToList();
            foreach (var item in fileList)
            {
                string[] entries = item.Split(',');

                if (entries[5]=="lid")
                {
                    temp_Leden.Add(new Lid(entries[0], entries[1], DateTime.Parse(entries[2]), entries[3], entries[4]));
                }
                else if (entries[5] == "medewerker")
                {
                    temp_Leden.Add(new Medewerker(entries[0], entries[1], DateTime.Parse(entries[2]), entries[3], entries[4]));
                }
                else
                {
                    throw new Exception($"Lid type kan niet worden geladen uit teksbestand {filePath}. String niet correct");
                }
            }
            Leden = temp_Leden;
        }
        public static void LoadCollectionsFromFile()
        {
            string dataFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\Data";
            string filePath = dataFolderPath + @"\CollectieBibliotheek_ItemsInCollectie.txt";
            List<string> fileList = File.ReadAllLines(filePath).ToList();
            List<Item> temp_ItemsInCollectie = new List<Item>();
            //fileList = File.ReadAllLines(filePath).ToList();
            foreach (var item in fileList)
            {
                string[] entries = item.Split(',');
                temp_ItemsInCollectie.Add(new Item((SoortItem)Int32.Parse(entries[0]), entries[1], entries[2], Int32.Parse(entries[3]), entries[4].ToBool(), entries[5].ToBool(), entries[6].ToBool(), entries[7]));
            }
            ItemsInCollectie = temp_ItemsInCollectie;



            filePath = dataFolderPath + @"\CollectieBibliotheek_AfgevoerdeItems.txt";
            fileList = File.ReadAllLines(filePath).ToList();
            List<Item> temp_AfgevoerdeItems = new List<Item>();

            foreach (var item in fileList)
            {
                string[] entries = item.Split(',');
                temp_AfgevoerdeItems.Add(new Item((SoortItem)Int32.Parse(entries[0]), entries[1], entries[2], Int32.Parse(entries[3]), entries[4].ToBool(), entries[5].ToBool(), entries[6].ToBool(), entries[7]));
            }
            AfgevoerdeItems = temp_AfgevoerdeItems;
        }
        public static void CheckUserData()
        {
            string userDataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\UserData";
            //checks if files exists, in case it was deleted. creates new files if they don't exist
            for (int i = 0; i < Leden.Count; i++)
            {
                string userFolder = $@"{userDataPath}\{Leden[i].Gebruikersnaam}"; 
                if (!Directory.Exists(userFolder))
                {
                    Directory.CreateDirectory(userFolder);
                }
                if (!File.Exists(userFolder + @"\uitleenhistoriek.txt"))
                {
                    
                    File.Create(userFolder + @"\uitleenhistoriek.txt").Close();
                    
                }
                if (!File.Exists(userFolder + @"\uitgeleend.txt"))
                {
                    File.Create(userFolder + @"\uitgeleend.txt").Close();
                }
                if (!File.Exists(userFolder + @"\reservatie.txt"))
                {
                    File.Create(userFolder + @"\reservatie.txt").Close();
                }
            }
        }
        public static void LoadUserData()
        {
            string userDataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\UserData";
            if (Directory.Exists(userDataPath))
            {
                for (int i = 0; i < Leden.Count; i++)
                {
                    string userFolder = $@"{userDataPath}\{Leden[i].Gebruikersnaam}";
                    List<string> fileList = File.ReadAllLines(userFolder + @"\uitleenhistoriek.txt").ToList();
                    List<Item> temp_Uitleenhistoriek = new List<Item>();
                    foreach (var item in fileList)
                    {
                        string[] entries = item.Split(',');
                        temp_Uitleenhistoriek.Add(new Item((SoortItem)Int32.Parse(entries[0]), entries[1], entries[2], Int32.Parse(entries[3]), entries[4].ToBool(), entries[5].ToBool(), entries[6].ToBool(), entries[7]));
                    }
                    Leden[i].UitleenHistoriek = temp_Uitleenhistoriek;
                    fileList = File.ReadAllLines(userFolder + @"\uitgeleend.txt").ToList();
                    List<Item> temp_Uitgeleend = new List<Item>();
                    foreach (var item in fileList)
                    {
                        string[] entries = item.Split(',');
                        temp_Uitgeleend.Add(new Item((SoortItem)Int32.Parse(entries[0]), entries[1], entries[2], Int32.Parse(entries[3]), entries[4].ToBool(), entries[5].ToBool(), entries[6].ToBool(), entries[7]));
                    }
                    Leden[i].ItemsUitgeleend = temp_Uitgeleend;
                    fileList = File.ReadAllLines(userFolder + @"\reservatie.txt").ToList();
                    List<Item> temp_Reservatie = new List<Item>();
                    foreach (var item in fileList)
                    {
                        string[] entries = item.Split(',');
                        temp_Reservatie.Add(new Item((SoortItem)Int32.Parse(entries[0]), entries[1], entries[2], Int32.Parse(entries[3]), entries[4].ToBool(), entries[5].ToBool(), entries[6].ToBool(), entries[7]));
                    }
                    Leden[i].Reservatie = temp_Reservatie;
                }
            } 
        }
        public static void CreateNewUserDataFolder(string gebruikersnaam)
        {
            string userDataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\UserData";
            string userFolder = $@"{userDataPath}\{gebruikersnaam}";
            Directory.CreateDirectory(userFolder);
            File.Create(userFolder + @"\uitleenhistoriek.txt").Close();
            File.Create(userFolder + @"\uitgeleend.txt").Close();
            File.Create(userFolder + @"\reservatie.txt").Close();
        }
        public static void SaveUsersToFile()
        {
            string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\Data\CollectieBibliotheek_Leden.txt";
            List<string> stringList = new List<string>();
            foreach (var item in Leden)
            {
                string userType = "lid";
                if (item is Medewerker)
                {
                    userType = "medewerker";
                }
                stringList.Add($"{item.Voornaam},{item.Familienaam},{item.GeboorteDatum.Day.ToString()}/{item.GeboorteDatum.Month.ToString()}/{item.GeboorteDatum.Year.ToString()},{item.Gebruikersnaam},{item.Wachtwoord},{userType}");
            }
            File.WriteAllLines(filePath,stringList);
        }
        public static void SaveCollectionsToFile()
        {
            string dataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\Data";
            List<string> collectieList = new List<string>();
            foreach (var item in ItemsInCollectie)
            {
                collectieList.Add($"{(int)item.SoortItem},{item.Titel},{item.Auteur},{item.Jaartal},{item.Uitgeleend},{item.Gereserveerd},{item.Afgevoerd},{item.ItemId}");
            }
            File.WriteAllLines(dataPath+@"\CollectieBibliotheek_ItemsInCollectie.txt",collectieList);
            List<string> afgevoerdList = new List<string>();
            foreach (var item in AfgevoerdeItems)
            {
                afgevoerdList.Add($"{(int)item.SoortItem},{item.Titel},{item.Auteur},{item.Jaartal},{item.Uitgeleend},{item.Gereserveerd},{item.Afgevoerd},{item.ItemId}");
            }
            File.WriteAllLines(dataPath + @"\CollectieBibliotheek_AfgevoerdeItems.txt", afgevoerdList);
        }
        public static void SaveUserData()
        {
            string userDataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TimothyHsu_OOPIntegratie\UserData";
            for (int i = 0; i < Leden.Count; i++)
            {
                List<string> uitleenHistoriekList = new List<string>();
                foreach (var item in Leden[i].UitleenHistoriek)
                {
                    uitleenHistoriekList.Add($"{(int)item.SoortItem},{item.Titel},{item.Auteur},{item.Jaartal},{item.Uitgeleend},{item.Gereserveerd},{item.Afgevoerd},{item.ItemId}");
                }
                
                File.WriteAllLines($@"{userDataPath}\{Leden[i].Gebruikersnaam}\uitleenhistoriek.txt",uitleenHistoriekList);
                List<string> uitgeleendList = new List<string>();
                foreach (var item in Leden[i].ItemsUitgeleend)
                {
                    uitgeleendList.Add($"{(int)item.SoortItem},{item.Titel},{item.Auteur},{item.Jaartal},{item.Uitgeleend},{item.Gereserveerd},{item.Afgevoerd},{item.ItemId}");
                }
                File.WriteAllLines($@"{userDataPath}\{Leden[i].Gebruikersnaam}\uitgeleend.txt", uitgeleendList);
                List<string> reservatieList = new List<string>();
                foreach (var item in Leden[i].Reservatie)
                {
                    reservatieList.Add($"{(int)item.SoortItem},{item.Titel},{item.Auteur},{item.Jaartal},{item.Uitgeleend},{item.Gereserveerd},{item.Afgevoerd},{item.ItemId}");
                }
                File.WriteAllLines($@"{userDataPath}\{Leden[i].Gebruikersnaam}\reservatie.txt", reservatieList);
            }
        }
        public static void LoadAll()
        {
            CheckDataFiles();
            LoadUsersFromFile();
            LoadUserData();
            CheckUserData();
            LoadCollectionsFromFile();
        }
        public static void SaveAll()
        {
            SaveUsersToFile();
            SaveCollectionsToFile();
            SaveUserData();
        }
        
    }
}
