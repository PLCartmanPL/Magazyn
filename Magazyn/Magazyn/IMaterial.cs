namespace Warehouse
{
    public interface IMaterial
    {
        public string Shape { get; }
        public int Size { get; }

        void AddWeight(float weight);
        void AddWeight(string weight);
        void AddWeight(double weight);
        void AddWeight(int weight);
        Statistics GetStatistics();
    }
}
