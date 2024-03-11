
using System;
using System.ComponentModel.Design;
using Warehouse;
using static System.Runtime.InteropServices.JavaScript.JSType;
MaterialInFile toMemory = new MaterialInFile();
Console.WriteLine("Wczytano materiał z pliku:");
toMemory.MaterialsShowList();

Console.WriteLine("======================================");
Console.WriteLine("Witamy w programie do obługi magazynu");
Console.WriteLine("======================================");
Console.WriteLine();
void MaterialWeightAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano Nową Wagę");
}
while (true)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("-----Jesteś w Głównym menu, podaj nr menu---------");
        Console.WriteLine();
        Console.WriteLine("wpisz 1 aby dodać nowy materiał");
        Console.WriteLine("wpisz 2 aby dodać wagę");
        Console.WriteLine("wpisz 3 aby wyświelić liste materiałów");
        Console.WriteLine("wpisz 4 aby wyświelić stan całego magazynu");
        Console.WriteLine("wpisz q aby zakączyć");
        Console.WriteLine();

        var input = Console.ReadLine();

        if (input == "1")
        {
            if (input == "q" || input == "Q")
            {
                break;
            }
            else
            {
                string nameMaterial = "";
                string sizeMaterial = "";
                string otherName = "";
                while (nameMaterial != "q" || nameMaterial != "Q" || sizeMaterial != "q" || sizeMaterial != "Q")
                {
                    Console.WriteLine("wybierz rodzaj materiału wpisując 1, 2 lub 3");
                    Console.WriteLine(" 1 - Materiał okrągły");
                    Console.WriteLine(" 2 - Materiał kwadratowy");
                    Console.WriteLine(" 3 - Materiał sześciokąt");
                    Console.WriteLine(" 4 - inny ksztat - WPISZ RĘcznie!!");
                    Console.WriteLine();
                    nameMaterial = Console.ReadLine();
                    if (nameMaterial == "q" || nameMaterial == "Q" || sizeMaterial == "q" || sizeMaterial == "Q")
                    {
                        break;
                    }
                    else if (nameMaterial == "4")
                    {
                        Console.WriteLine("Wpisz WŁASNY kształt materiału - UŻYJ TYLKO LITER!!!");
                        otherName = Console.ReadLine();

                    }
                    Console.WriteLine("Wpisz rozmiar materiału w mm (Tylko liczby całkowite)");
                    sizeMaterial = Console.ReadLine();
                    if (nameMaterial == "q" || nameMaterial == "Q" || sizeMaterial == "q" || sizeMaterial == "Q")
                    {
                        break;
                    }
                    else if (nameMaterial == "1")
                    {
                        int sizeMaterialInInt = Int32.Parse(sizeMaterial);
                        var newMaterial = new MaterialInFile("Okrągły", sizeMaterialInInt);
                        break;
                    }
                    else if (nameMaterial == "2")
                    {
                        int sizeMaterialInInt = Int32.Parse(sizeMaterial);
                        var newMaterial = new MaterialInFile("Kwadrat", sizeMaterialInInt);
                        break;
                    }
                    else if (nameMaterial == "3")
                    {
                        int sizeMaterialInInt = Int32.Parse(sizeMaterial);
                        var newMaterial = new MaterialInFile("Sześciokąt", sizeMaterialInInt);
                        break;
                    }
                    else if (nameMaterial == "4")
                    {
                        int sizeMaterialInInt = Int32.Parse(sizeMaterial);
                        var newMaterial = new MaterialInFile(otherName, sizeMaterialInInt);
                    }
                    else
                    {
                        Console.WriteLine("Błędne dane");
                        break;
                    }
                }
                continue;
            }
        }
        else if (input == "2") // Dodawanie wagi do materiału
        {
            string numberInListString = "";
            string weightString = "";
            while (numberInListString != "q" || numberInListString != "Q" || weightString != "q" || weightString != "Q")
            {
                Console.WriteLine("Podaj liczbę porzadkową materiału lub wpisz Q aby wyjść!");
                toMemory.MaterialsShowList();
                numberInListString = Console.ReadLine();
                if (numberInListString == "q" || numberInListString == "Q")
                {
                    break;
                }
                Console.WriteLine("Podaj wagę w kg jaką chcesz wprowadzić");
                weightString = Console.ReadLine();
                if (weightString == "q" || weightString == "Q")
                {
                    break;
                }

                int numberInList;
                if (int.TryParse(numberInListString, out numberInList))
                {
                    string weightStringDote = weightString.Replace(".", ",");
                    float weight = float.Parse(weightStringDote);
                    toMemory.ReadMaterial(numberInList, weight);
                }
                else
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Podana liczba porządkowa nie jest poprwną liczbą");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                }
                continue;
            }
        }
        else if (input == "3")
        {

            string filePath = "./materials/materials.txt";
            if (File.Exists(filePath))
            {
                toMemory.MaterialsShowList();
                continue;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Brak Materiałów / Dodaj pierwszy Materiał!");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine();
            }
        }
        else if (input == "4")
        {
            toMemory.StockStatus();
            continue;
        }
        else if (input == "q" || input == "Q" || input == "d" || input == "D")
        {
            if (input == "q" || input == "Q")
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine();
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Console.WriteLine($"Wystąpił błąd: {e.Message}");
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Console.WriteLine();
    }
}

