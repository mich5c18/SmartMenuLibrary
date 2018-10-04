using System;

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
                    //System.IO.StreamReader sr = new System.IO.StreamReader(@"../../../SmartMenuLibrary/" + path); // Åbner for filen

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
        }
}
