
using System;
using System.Drawing;
using System.Globalization;

namespace Warehouse
{
    public abstract class MaterialBase : IMaterial
    {

        public delegate void WeightAddedDelegate(object sender, EventArgs args);
        public abstract event WeightAddedDelegate WeightAdded;
        public const string MaterialsList = "./materials/materials.txt";

        public MaterialBase()
        {
        }
        public MaterialBase(string shape, int size)
        {
            this.Shape = shape;
            this.Size = size;
            this.FileNameTxt = "./materials/" + shape + " " + size + ".txt";
            this.FileName = shape + " " + size;

            if (!File.Exists(this.FileNameTxt))
            {
                var file = File.Create(this.FileNameTxt);
                file.Close();
                using (var writer = File.AppendText(this.FileNameTxt))
                {
                    writer.WriteLine(0);
                }
                Console.WriteLine("Dodano materiał " + FileName);
            }
            else
            {

            }

            if (!File.Exists(MaterialsList))
            {
                var ListMaterial = File.Create(MaterialsList);
                ListMaterial.Close();

                using (var writer = File.AppendText(MaterialsList))
                {
                    writer.WriteLine(FileName);
                }

            }
            else
            {
                string CheckMaterials = File.ReadAllText(MaterialsList);
                if (CheckMaterials.Contains(FileName))
                {

                }
                else
                {
                    using (var writer = File.AppendText(MaterialsList))
                    {
                        writer.WriteLine(FileName);
                    }
                }
            }
        }
        public string Shape { get; private set; }
        public int Size { get; private set; }
        public string FileNameTxt { get; private set; }
        public string FileName { get; private set; }


        public abstract void AddWeight(float weight);
        public abstract void ReadMaterial(int numberInList, float weight);

        public void AddWeight(string weight)
        {
            if (float.TryParse(weight, out float result))
            {
                this.AddWeight(result);
            }
            else if (double.TryParse(weight, NumberStyles.Float, CultureInfo.InvariantCulture, out double resultDouble))
            {
                this.AddWeight(resultDouble);
            }
            else
            {
                Console.WriteLine("Weight is not a numer");
            }
        }
        public void AddWeight(double weight)
        {
            float weightAsFloat = (float)weight;
            this.AddWeight(weightAsFloat);
        }
        public void AddWeight(int weight)
        {
            float weightAsFloat = (float)weight;
            this.AddWeight(weightAsFloat);
        }
        public void NewMaterial(string name)
        {
            name = this.Shape + this.Size + ".txt";
        }
        public abstract void MaterialsToMemory();
        public abstract void MaterialsShowList();

        public abstract Statistics GetStatistics();
    }
}
