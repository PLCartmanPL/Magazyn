
using Warehouse;
Console.WriteLine("Witamy w programie do obługi magazynu");
Console.WriteLine("======================================");
Console.WriteLine();
Console.WriteLine("wpisz 1 aby dodać nowy materiał");
Console.WriteLine("wpisz 2 aby dodać wagę");
Console.WriteLine("wpisz q aby zakączyć");
Console.WriteLine("wpisz d aby wyświetlić zapisane dostawy");

var material = new MaterialInFile("Kwadrat", 16);

material.WeightAdded += MaterialWeightAdded;

void MaterialWeightAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano Nową Wagę");
}


while (true)
{
    Console.WriteLine("-----Jesteś w Głównym menu, podaj nr menu---------");
    var input = Console.ReadLine();


    if (input == "1")
    {
        if (input == "q" || input == "Q")
        {
            break;
        }
        else
        {
            var statsitic1 = material.GetStatistics();
            Console.WriteLine($"zapisane dostawy: {statsitic1.CheckDelivery}");
            continue;
        }
    }


    else if (input == "2")
    {
        var inputWeight = "";
        while (inputWeight != "q" || inputWeight != "Q")
        {
            Console.WriteLine("Podaj wagę lub cofnij się do głównego menu wpisując q");
            inputWeight = Console.ReadLine();
            if (inputWeight == "q" || inputWeight == "Q")
            {
                break;
            }
            material.AddWeight(inputWeight);
        }
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
            var statsitic1 = material.GetStatistics();
            Console.WriteLine($"zapisane dostawy: {statsitic1.CheckDelivery}");
            continue;
        }
    }

    try
    {

    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catch: {e.Message}");
    }


}
var statsitic = material.GetStatistics();


Console.WriteLine($"zapisane dostawy: {statsitic.CheckDelivery}");
Console.WriteLine($"Waga materiału w magazynie: {statsitic.StockStatus:N2}");
Console.WriteLine($"Najmniejsza dostawa: {statsitic.MinDelivery}");
Console.WriteLine($"Największa dostawa: {statsitic.MaxDelivery}");
Console.WriteLine($"Liczba dostaw: {statsitic.NumberOfDelivery}");
Console.WriteLine($"Średnia wartość dostaw: {statsitic.AverageDelivery}");
Console.WriteLine($"Poziom magazynu: {statsitic.StockLevel}");

