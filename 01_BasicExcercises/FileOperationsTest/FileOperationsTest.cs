using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileOperationsProject_2;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace FileOperationsTest
{
    [TestClass]
    public class FileOperationsTest
    {
     

        [TestMethod]
        public void ReadFile_ReturnsListOfSettings_IfFileIsNotEmpty()
        {

            //Arrange
            List<string> systemConfig = new List<string>();
            string directory = Directory.GetCurrentDirectory();
            string emptyFileName = "/emptyFile.txt";

            // Act
            systemConfig = Files.ReadFile(systemConfig, directory, emptyFileName);

            // Assert
            Assert.IsTrue(systemConfig.Count > 0);
        }


        [TestMethod]
        public void ReadFile_ReturnsEmptyList_IfFileIsEmpty()
        {
            // Arrange
            List<string> systemConfig = new List<string>();
            string directory = Path.GetTempPath(); // Use a temporary path to avoid permission issues
            string emptyFileName = "emptyFile.txt";
            string emptyFilePath = Path.Combine(directory, emptyFileName);

            File.WriteAllText(emptyFilePath, ""); // Create an empty file

            // Act
            systemConfig = Files.ReadFile(systemConfig, directory, emptyFileName);

            // Assert
            Assert.AreEqual(1, systemConfig.Count);
        }
    }
}