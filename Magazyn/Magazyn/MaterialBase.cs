
using System.Globalization;

namespace Warehouse
{
    public abstract class MaterialBase : IMaterial
    {
        public delegate void WeightAddedDelegate(object sender, EventArgs args);

        public abstract event WeightAddedDelegate WeightAdded;

        public MaterialBase(string shape, int size)
        {
            this.Shape = shape;
            this.Size = size;
        }
        public string Shape { get; private set; }
        public int Size { get; private set; }

        public abstract void AddWeight(float weight);

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

        public abstract Statistics GetStatistics();
    }
}
