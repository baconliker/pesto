using NUnit.Framework;
using ColinBaker.Pesto.Services.Spreadsheet;

namespace ColinBaker.Pesto.Tests.Services.Spreadsheet
{
    [TestFixture]
    class SpreadsheetConverterTests
    {
        [Test]
        public void Create()
        {
            Assert.IsNotNull(new SpreadsheetConverter());
        }

        [Test]
        public void ConvertToCsv()
        {
            string csvFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());

            SpreadsheetConverter converter = new SpreadsheetConverter();

            Assert.IsTrue(converter.ConvertToCsv(System.AppDomain.CurrentDomain.BaseDirectory + @"Services\Spreadsheet\DataTypes.xlsx", csvFilePath, "Sheet1"));

            string[] csvContents = System.IO.File.ReadAllLines(csvFilePath);

            if (csvContents.Length != 2)
            {
                Assert.Fail("Csv file contains the wrong number of rows.");
            }

            string[] csvLineData;

            csvLineData = csvContents[0].Split(',');

            if (csvLineData.Length != 11)
            {
                Assert.Fail("Csv file contains the wrong number of columns.");
            }

            csvLineData = csvContents[1].Split(',');

            if (csvLineData[0] != "123.46")
            {
                Assert.Fail("Number (2DP) is not formatted correctly.");
            }

            if (csvLineData[1] != "123.5")
            {
                Assert.Fail("Number (1DP) is not formatted correctly.");
            }

            if (csvLineData[2] != "123")
            {
                Assert.Fail("Number (0DP) is not formatted correctly.");
            }

            if (csvLineData[3] != "13:14:15")
            {
                Assert.Fail("Time (HH:mm:ss) is not formatted correctly.");
            }

            if (csvLineData[4] != "09:36")
            {
                Assert.Fail("Time (mm:ss) is not formatted correctly.");
            }

            if (csvLineData[5] != "00:12.3")
            {
                Assert.Fail("Time (mm:ss.0) is not formatted correctly.");
            }

            if (csvLineData[6] != "00:12.35")
            {
                Assert.Fail("Time (mm:ss.00) is not formatted correctly.");
            }

            if (csvLineData[7] != "12%")
            {
                Assert.Fail("Percentage (0DP) is not formatted correctly.");
            }

            if (csvLineData[8] != "")
            {
                Assert.Fail("Blank contains a value.");
            }

            if (csvLineData[9] + "," + csvLineData[10] != "\"Comma, test\"")
            {
                Assert.Fail("Comments is not formatted correctly.");
            }

            if (csvLineData[11] != "09:48.3")
            {
                Assert.Fail("Time (mm:ss.0) is not formatted correctly (formula).");
            }
        }
    }
}
