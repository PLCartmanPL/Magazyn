using System.Xml.Linq;

namespace Warehouse
{
    internal class MaterialInFile : MaterialBase
    {
        private List<float> weights = new List<float>();

        private  string FileName = "weight.txt";
        public MaterialInFile(string shape, int size)
            : base(shape, size)
        {
        }
        public override event WeightAddedDelegate WeightAdded;

        public override void AddWeight(float weight)
        {
            using (var writer = File.AppendText(FileName))
            {
                if (weight >= 0)
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

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            weights.Clear();
            if (File.Exists(FileName))
            {
                using (var reader = File.OpenText(FileName))
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