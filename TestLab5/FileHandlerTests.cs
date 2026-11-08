using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLab5
{
    [TestClass]
    public sealed class FileHandlerTests
    {

        private string _tempFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            _tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".json");
        }


        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_tempFilePath))
            {
                File.Delete(_tempFilePath);
            }
        }

        [TestMethod]
        public async Task SaveAsync_Should_WriteDataToFile()
        {
            var data = new List<string> { "Test1", "Test2", "Test3" };

            var fileSaver = new net_lab5.Classes.JSONFileWriter();

            await fileSaver.SaveAsync(_tempFilePath, data);

            Assert.IsTrue(File.Exists(_tempFilePath));

            string fileContent = await File.ReadAllTextAsync(_tempFilePath);

            Assert.IsTrue(fileContent.Contains("Test1"));
        }

        [TestMethod]
        public async Task ReadAsync_Should_ReadDataFromFile()
        {
            var data = new List<string> { "Test1", "Test2", "Test3" };
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(_tempFilePath, json);
            var fileLoader = new net_lab5.Classes.JSONFileReader();
            List<string> loadedData = await fileLoader.LoadAsync<string>(_tempFilePath);
            CollectionAssert.AreEqual(data, loadedData);
        }
    }
}
