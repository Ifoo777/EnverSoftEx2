using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CSVProgram; // Make sure to include the namespace of the class being tested.


namespace CSVProgram.Test
{
    // The FrequencyCalculatorTests class contains test methods for the FrequencyCalculator class.
    [TestClass]
    public class CSVProgramTest
    {
        // This test method tests the CalculateFrequencies method of the FrequencyCalculator class.
        [TestMethod]
        public void TestCalculateFrequencies()
        {
            {
                // Arrange: Prepare the test data for the FrequencyCalculator method to be tested.
                var data = new List<(string Name, string Address)>

            {
                ("Matt Brown" , "12 Acton St"),
                ("Heinrich Jones" , "31 Clifton Rd"),
                ("Johnson Smith" , "22 Jones Rd"),
                ("Tim Johnson" , "7 Elm St")
            };

                // Act: Call the method to be tested and capture its return values.
                var firstNameFrequencies = FrequencyCalculator.CalculateFrequencies(data, name => name.Split(' ').First());
                var lastNameFrequencies = FrequencyCalculator.CalculateFrequencies(data, name => name.Split(' ').Last());


                // Assert: Verify that the method produced the expected results.
                Assert.AreEqual(2, firstNameFrequencies["Johnson"]);
                Assert.AreEqual(1, firstNameFrequencies["Brown"]);
                Assert.AreEqual(1, firstNameFrequencies["Heinrich"]);
                Assert.AreEqual(1, firstNameFrequencies["Jones"]);
                Assert.AreEqual(1, firstNameFrequencies["Matt"]);
                Assert.AreEqual(1, firstNameFrequencies["Smith"]);
                Assert.AreEqual(1, firstNameFrequencies["Tim"]);

                Assert.AreEqual(1, lastNameFrequencies["Brown"]);
                Assert.AreEqual(1, lastNameFrequencies["Jones"]);
                Assert.AreEqual(1, lastNameFrequencies["Smith"]);
                Assert.AreEqual(2, lastNameFrequencies["Johnson"]);




            }
        }
    }
}