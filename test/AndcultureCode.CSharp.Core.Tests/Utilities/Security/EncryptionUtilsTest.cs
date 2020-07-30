using System;
using AndcultureCode.CSharp.Core.Utilities.Security;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Core.Tests.Matchers;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Utilities.Security
{
    public class EncryptionUtilsTest : CoreUnitTest
    {
        #region Setup

        public EncryptionUtilsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region GenerateHash

        [Fact]
        public void GenerateHash_When_Bits_LessThan_256_Then_Throws_Exception() =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                EncryptionUtils.GenerateHash(
                    bits: 24, // <----- less than minimum, but divisible by 8
                    salt: Random.String(),
                    value: Random.String()
                );
            });

        [Fact]
        public void GenerateHash_When_Bits_IsNot_DivisibleBy_8_Then_Throws_Exception() =>
            Assert.Throws<ArgumentException>(() =>
            {
                EncryptionUtils.GenerateHash(
                    bits: 257, // <----- not divisible by 8, but greater than minimum of 256
                    salt: Random.String(),
                    value: Random.String()
                );
            });

        [Fact]
        public void GenerateHash_When_IterationCount_LessThan_10000_Then_Throws_Exception() =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                EncryptionUtils.GenerateHash(
                    iterationCount: Random.UShort(max: 9999), // <----- less than minimum
                    salt: Random.String(),
                    value: Random.String()
                );
            });

        [Fact]
        public void GenerateHash_When_Default_Arguments_Returns_Base64_Hash()
        {
            // Arrange & Act
            var result = EncryptionUtils.GenerateHash(
                salt: EncryptionUtils.GenerateSalt(),
                value: Random.String()
            );

            // Assert
            result.ShouldBeBase64();
        }

        #endregion GenerateHash

        #region GenerateSalt

        [Fact]
        public void GenerateSalt_When_Bits_LessThan_128_Then_Throws_Exception() =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                EncryptionUtils.GenerateSalt(
                    bits: 24 // <----- less than minimum, but divisible by 8
                );
            });

        [Fact]
        public void GenerateSalt_When_Bits_IsNot_DivisibleBy_8_Then_Throws_Exception() =>
            Assert.Throws<ArgumentException>(() =>
            {
                EncryptionUtils.GenerateSalt(
                    bits: 129 // <----- not divisible by 8, but greater than minimum of 128
                );
            });

        [Fact]
        public void GenerateSalt_When_Default_Arguments_Returns_Base64_Salt() =>
            EncryptionUtils.GenerateSalt().ShouldBeBase64();

        #endregion GenerateSalt
    }
}
