namespace Warehouse.Tests
{
    public class Tests
    {
        [Test]
        public void WhenCreateNewMaterialThenConstructorCreatesParametersShape()
        {
            var material = new MaterialInFile("Test", 18);

            var statistic = material.GetStatistics();
            var result = statistic.StockStatus;

            Assert.AreEqual("Test", material.Shape);
        }
        [Test]
        public void WhenCreateNewMaterialThenConstructorCreatesParametersSize()
        {
            var material = new MaterialInFile("Test", 18);
            material.AddWeight(16);
            material.AddWeight(16);

            var statistic = material.GetStatistics();
            var result = statistic.StockStatus;

            Assert.AreEqual(18, material.Size);
        }

        [Test]
        public void WhenAddWeightThenGetTheSum()
        {
            var material = new MaterialInFile("Test", 18);

            var statistic = material.GetStatistics();
            material.AddWeight(16.5);
            material.AddWeight(16);

            var statistic1 = material.GetStatistics();
            var result = statistic1.StockStatus - statistic.StockStatus;

            Assert.AreEqual(32.5, result);
        }
    }
}