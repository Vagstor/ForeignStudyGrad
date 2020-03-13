using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RHSoft.Study.SampleProject.Tests
{
    public class EsCheckerTests
    {
        [Theory]
        [InlineData( "", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1,2,3", 1 )]
        [InlineData( "2,2,2", 0 )]
        [InlineData( "1,2,2", 0 )]
        [InlineData( "1,3,2", 1 )]
        [InlineData( "5,6,2", 0 )]
        [InlineData( "4,2,3,1", 1 )]
        public void Tests( string input, int expected )
        {
            var array = input == "" ? new int[0] : input.Split( "," ).Select( a => Convert.ToInt32( a ) ).ToArray();
            var checker = new EsChecker();
            Assert.Equal( expected, checker.IsPermutation( array ) );
        }

        [Fact]
        public void TestExceptionElementValue()
        {
            var input = new int[] { 1, -3, 4, 3, 1, 0 };
            EsChecker checker = new EsChecker();
            Assert.Throws<ArgumentException>( () => checker.IsPermutation( input ) );
        }
        [Fact]
        public void TestExceptionArraysLength()
        {
            var input = new int[1000000001];
            for( var i=0; i<input.Length; i++ )
            {
                input[i] = 0;
            }
            EsChecker checker = new EsChecker();
            Assert.Throws<ArgumentException>( () => checker.IsPermutation( input ) );
        }
    }
}
