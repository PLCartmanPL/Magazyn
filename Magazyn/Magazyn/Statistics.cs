using System.Xml.Linq;

namespace Warehouse
{
    public class Statistics
    {
        private List<float> delivery = new List<float>();
        public float MinDelivery { get; private set; }
        public float MaxDelivery { get; private set; }
        public float StockStatus { get; private set; }
        public string CheckDelivery
        {
            get
            {
                switch (this.delivery)
                {
                    case var StockStatus when delivery.Count == 0:
                        return "Brak dostaw!";

                    default:
                        return string.Join(", ", delivery); ;
                }
            }
        }
        public float AverageDelivery
        {
            get
            {
                return this.StockStatus / this.NumberOfDelivery;
            }
        }
        public int NumberOfDelivery { get; private set; }
        public string StockLevel
        {
            get
            {
                switch (this.StockStatus)
                {
                    case var StockStatus when StockStatus >= 100:
                        return "Full";
                    case var StockStatus when StockStatus >= 50:
                        return "Meddium";
                    case var StockStatus when StockStatus >= 1:
                        return "Low";
                    default:
                        return "Empty";
                }
            }
        }

        public Statistics()
        {
            delivery.Clear();
            this.StockStatus = 0;
            this.NumberOfDelivery = 0;
            this.MaxDelivery = float.MinValue;
            this.MinDelivery = float.MaxValue;
        }
        public void AddWeight(float weight)
        {
            this.NumberOfDelivery++;
            this.StockStatus += weight;
            this.MinDelivery = Math.Min(this.MinDelivery, weight);
            this.MaxDelivery = Math.Max(this.MaxDelivery, weight);
            this.delivery.Add(weight);
        }
    }
}
