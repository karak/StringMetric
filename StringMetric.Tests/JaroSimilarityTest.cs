using System;
using Xunit;

namespace StringMetric.Tests
{
    public class JaroSimilarityTest
    {
        [Fact]
        public void EmptyCases()
        {
            Assert.Equal(1, Jaro.Similarity("", ""));
            Assert.Equal(0, Jaro.Similarity("", "AB"));
            Assert.Equal(0, Jaro.Similarity("AB", ""));
        }

        [Fact]
        public void NonEmptyCases()
        {
            Assert.Equal(0.8222222, Jaro.Similarity("DWAYNE", "DUANE"), 7);
            Assert.Equal(0.9444444, Jaro.Similarity("MARTHA", "MARHTA"), 7);
            Assert.Equal(0.7666667, Jaro.Similarity("DIXON", "DICKSONX"), 7);
            Assert.Equal(0.8962963, Jaro.Similarity("JELLYFISH", "SMELLYFISH"), 7);
        }
    }
}
