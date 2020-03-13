using System;
using System.Linq;
using Xunit;

namespace RHSoft.Study.SampleProject.Tests
{
    public class MonotoneCheckerTests
    {
        [Theory]
        [InlineData( "", false )]
        [InlineData( "1", false )]
        [InlineData( "1,2,3", true )]
        [InlineData( "2,2,2", false )]
        [InlineData( "1,2,2", false )]
        [InlineData( "5,3,2", true )]
        [InlineData( "5,6,2", false )]
        [InlineData( "5,2,3", false )]
        public void Tests( string input, bool expected )
        {
            var array = input == "" ? new int[0] : input.Split(",").Select( a => Convert.ToInt32( a ) ).ToArray();
            var checker = new MonotoneChecker();
            Assert.Equal( expected, checker.IsMonotone( array ) );
        }
    }
}
