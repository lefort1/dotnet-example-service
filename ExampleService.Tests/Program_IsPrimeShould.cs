using System;
using static ExampleService.Program;
using Xunit;

namespace ExampleService.Tests
{
    public class Program_IsPrimeShould
    {
        private readonly Program _program;

        public Program_IsPrimeShould()
        {
            _program = new Program();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            bool result = _program.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void ReturnTrueGivenPrimesLessThan10(int value)
        {
            bool result = _program.IsPrime(value);

            Assert.True(result, $"{value} should be prime");
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        public void ReturnFalseGivenNonPrimesLessThan10(int value)
        {
            bool result = _program.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}
