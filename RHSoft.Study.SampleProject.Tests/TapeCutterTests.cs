using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RHSoft.Study.SampleProject.Tests
{
    public class TapeCutterTests
    {
        [Theory]
        [InlineData("1,2,3,4,5", 3)]
        [InlineData("-1,-2,-3,-4,-5", 3)]
        [InlineData("1,1,1", 1)]
        [InlineData("0,0,0,0", 0)]
        [InlineData("-1,0,4,-3,0", 0)]
        [InlineData("2,7,0,-9,-9,4,7,8",6)]
        [InlineData("-132,632,-469,-108,-202,306,741,-955",33)]
        [InlineData("176,156,-337,229,-346,379,-417,-565",405)]
        [InlineData("1,2",1)]
        [InlineData("5,2,2",1)]
        [InlineData("-1000,1000",2000)]

        public void Tests(string input, int expected)
        {
            var array = input == "" ? new int[0] : input.Split(",").Select(a => Convert.ToInt32(a)).ToArray();
            var cutter = new TapeCutter();
            Assert.Equal( expected, cutter.ImprovedMinDelta(array));
        }

        [Fact]
        public void TestExceptionElementValue()
        {
            var input = new int[] { 1, -3, 4, 3, 1, -1001 };
            TapeCutter cutter = new TapeCutter();
            Assert.Throws<ArgumentException>( () => cutter.ImprovedMinDelta( input ) );
        }
        [Fact]
        public void TestExceptionArraysLengthMore()
        {
            var input = new int[1000000001];
            for( var i = 0; i < input.Length; i++ )
            {
                input[i] = 0;
            }
            TapeCutter cutter = new TapeCutter();
            Assert.Throws<ArgumentException>( () => cutter.ImprovedMinDelta( input ) );
        }
        [Fact]
        public void TestExceptionArraysLengthLess()
        {
            var input = new int[1];
            for( var i = 0; i < input.Length; i++ )
            {
                input[i] = 0;
            }
            TapeCutter cutter = new TapeCutter();
            Assert.Throws<ArgumentException>( () => cutter.ImprovedMinDelta( input ) );
        }

        [Theory]
        [InlineData( 1000 )]
        [InlineData( 10000 )]
        [InlineData( 100000 )]
        [InlineData( 200000 )]
        public void StressTest( int n )
        {
            var rnd = new Random();
            var input = new int[n];
            for( var i = 0; i < input.Length; ++i )
            {
                input[i] = rnd.Next();
            }
            var cutter = new TapeCutter();
            // just run. no assertions
            cutter.ImprovedMinDelta( input );
        }
    }
}
