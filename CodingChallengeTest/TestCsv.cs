﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratory.Domain;
using Laboratory.Domain.Config;

namespace CodingChallengeTest
{
    [DeploymentItem("Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions.dll")]
    [TestClass]
    public class TestCsv
    {
        [DeploymentItem("expectedWithoutPadding.csv")]
        [DeploymentItem("expectedWithPadding.csv")]
		[DeploymentItem(@"Config\DataStructureConfig.json")]
		[TestMethod]
        public void TestGeneratedCsv()
        {
			// TODO: uncomment one of the following two lines depending on whether you're generating numbers with or without padding.
			var expected = this.GetPlaces("expectedWithoutPadding.csv");
            //var expected = this.GetPlaces("expectedWithPadding.csv");

            //TODO: invoke your code here to generate the "actual.csv" file
            InMemoryData dataTree = new InMemoryData(
                new CSVFileGenerator(), 
                new CustomConfiguration(), 
                new TreeBuildService()
                );

            dataTree.GenerateFile();

            var actual = this.GetPlaces(Environment.CurrentDirectory +  "\\actual.csv");

            // Feel free to modify the checks to add additional logging or assertions to assist troubleshooting
            Assert.AreEqual(expected.Count, actual.Count);
            
            foreach (var expectedKey in expected.Keys)
            {
                var expectedPlace = expected[expectedKey];
                var actualPlace = actual[expectedKey];

                Assert.AreEqual(expectedPlace.PublicId.ToLower(), actualPlace.PublicId.ToLower());
                Assert.AreEqual(expectedPlace.PublicParentId.ToLower(), actualPlace.PublicParentId.ToLower());
                Assert.AreEqual(expectedPlace.Type.ToLower(), actualPlace.Type.ToLower());
            }
        }       

        private Dictionary<string, Place> GetPlaces(string csvFile)
        {
            return File.ReadAllLines(csvFile)
                .Select(l =>
                {
                    var tokens = l.Split(new char[] { ',' });
                    return new Place(tokens[0].Trim(), tokens[1].Trim(), tokens[2].Trim());
                })
                .ToDictionary(p => $"${p.PublicParentId}/{p.PublicId}");
        }

        private class Place
        {
            public Place(string publicId, string publicParentId, string type)
            {
                this.PublicId = publicId;
                this.PublicParentId = publicParentId;
                this.Type = type;
            }

            public string PublicId { get; }

            public string PublicParentId { get; }

            public string Type { get; }
        }
    }
}
