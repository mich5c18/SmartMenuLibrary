using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bindings;

namespace SmartMenuLibrary
{
    public class SmartMenu
    {
        List<string> menuStructure = new List<string>(); // Laver en liste hvor menu strukturen gemmes
        List<string> menuPoints = new List<string>(); // Laver en liste med menu-id
        public void LoadMenu(string path)
        {
            if (path == "Fejl") // Checker om filstien findes
            {
                Console.WriteLine("Det indtastede menupunkt findes ikke, prøv igen.");
            }
            else
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(@"../../../SmartMenuLibrary/" + path); // Åbner for filen

                string line = null;
                int count = 1;

                menuStructure.Add(sr.ReadLine()); // Tilføjer første linje til listen
                menuStructure.Add(" "); // Tilføjer et mellemrum i listen
                string endLine = sr.ReadLine(); // // Gemmer anden linje i en variable

                // Starter et while loop, der køre indtil der ikke er flere linjer i filen
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitMenu = line.Split(';'); // Splitter hver menupunkt op i mellem semikolon
                    menuStructure.Add(" " + count + ". " + splitMenu[0]); // Tilføjer menu opsættelsen for hver menu linje
                    menuPoints.Add(splitMenu[1]); // Tilføjer menu-id til listen
                    count++; // Tæller en op 
                }
                sr.Close(); // Lukker åbningen af filen

                menuStructure.Add(" "); // Tilføjer et mellemrum i listen
                menuStructure.Add(endLine); // Tilføjer den gemte variable
            }
        }
        public void Activate()
        {
            Binding binding = new Binding(); // 
            bool checker = true;
            while (checker) // Lavet et while loop for at få menuen til at blive vist efter hver menupunkt bliver vist
            {
                Console.Clear(); // Clear console
                menuStructure.ForEach(Console.WriteLine); // Skrive hele "menuStructure" listen ud
                int.TryParse(Console.ReadLine(), out int r); // Tester om input fra brugeren er et tal
                Console.Clear(); // Clear menuen, så det er menupunktet der bliver vist
                switch (r) // Switch case, der fortælle hvilket menupunkt der er blevet valgt
                {
                    case 0:
                        Console.WriteLine("Farvel");
                        checker = false;
                        break;
                    case 1:
                        binding.callID(menuPoints[0]);
                        break;
                    case 2:
                        binding.callID(menuPoints[1]);
                        break;
                    case 3:
                        binding.callID(menuPoints[2]);
                        break;
                    case 4:
                        binding.callID(menuPoints[3]);
                        break;
                    default:
                        Console.WriteLine("Input var ikke et menupunkt.");
                        break;
                }
                Console.ReadLine(); // Venter på et input, før den går videre
            }

        }

        public string ChooseLanguage(int language)
        {
            // Checker om der bliver valgt dansk eller engelsk
            if (language == 1)
            {
                return "MenuSpecDK.txt";
            }
            else if (language == 2)
            {
                return "MenuSpecENG.txt";
            }

            return "Fejl"; // Hvis der ikke vælges dansk eller engelsk bliver der sendt en fejl
        }
    }
}