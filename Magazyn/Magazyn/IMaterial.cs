namespace Warehouse
{
    public interface IMaterial
    {
        public string Shape { get; }
        public int Size { get; }
        public string FileNameTxt { get; }
        public string FileName { get; }

        void AddWeight(float weight);
        void AddWeight(string weight);
        void AddWeight(double weight);
        void AddWeight(int weight);
        void NewMaterial(string name);
        void ReadMaterial(int numberInList, float weight);
        void MaterialsToMemory();
        void MaterialsShowList();
        Statistics GetStatistics();
    }
}
