using System;
using System.Text;
using System.Xml.Linq;

namespace Warehouse
{
    internal class MaterialInFile : MaterialBase
    {
        private List<float> weights = new List<float>();
        public List<MaterialInFile> MaterialsInMemory = new List<MaterialInFile>();

        public MaterialInFile()
        {
        }
        public MaterialInFile(string shape, int size)
            : base(shape, size)
        {
        }
        public override event WeightAddedDelegate WeightAdded;

        public override void AddWeight(float weight)
        {
            using (var writer = File.AppendText(FileNameTxt))
            {
                if (weight >= int.MinValue)
                {
                    writer.WriteLine(weight);
                    if (WeightAdded != null)
                    {
                        WeightAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new Exception("Invaid weight value");
                }
            }
        }
        public override void MaterialsToMemory()
        {
            if (File.Exists(MaterialsList))
            {
                using (var reader = File.OpenText(MaterialsList))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string input = line;
                        string[] separatedValues = input.Split(" ");
                        string shape = separatedValues[0];
                        int size = Int32.Parse(separatedValues[1]);
                        MaterialInFile materialInFile = new MaterialInFile(shape, size);
                        MaterialsInMemory.Add(materialInFile);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                return;
            }
        }
        public override void ReadMaterial(int numberInList, float weight)
        {
            if (numberInList < MaterialsInMemory.Count && numberInList >= 0)
            {
                var myMaterial = MaterialsInMemory[numberInList];
                var statsitic = myMaterial.GetStatistics();
                if (statsitic.StockStatus + weight >= 0)
                {
                    myMaterial.AddWeight(weight);
                    var status = statsitic.StockStatus + weight;
                    Console.WriteLine("Dodano wagę " + weight + " kg dla materiału " + myMaterial.FileName + " Aktualny stan materiału: " + status);

                }
                else
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine($"Aktualna waga materiału wynosi {statsitic.StockStatus} nie można odjąć wagi {weight}");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine();
                }
            }
            else
            {
                var range = MaterialsInMemory.Count - 1;
                Console.WriteLine();
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine(numberInList + " nie jest poprawną liczbą porządkową");
                Console.WriteLine("Nie ma takiego materiału! Lista materiałów zawiera się od 0 do " + range);
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine();
            }
        }
        public override void MaterialsShowList()
        {
            MaterialsInMemory.Clear();
            MaterialsToMemory();
            int number = 0;
            foreach (MaterialInFile MaterialInFile in MaterialsInMemory)
            {
                Console.WriteLine(number + " " + MaterialInFile.FileName);
                number++;
            }


        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            weights.Clear();
            if (File.Exists(FileNameTxt))
            {
                using (var reader = File.OpenText(FileNameTxt))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var weight = float.Parse(line);
                        this.weights.Add(weight);
                        line = reader.ReadLine();
                    }
                }
            }
            foreach (var weight in this.weights)
            {
                statistics.AddWeight(weight);
            }
            return statistics;
        }
    }
}