using System;
using System.Collections.Generic;
using System.Text;

namespace RHSoft.Study.SampleProject
{
    public class TapeCutter
    {
        public int MinDelta( int[] input )
        {
            int minPartSumDelta = int.MaxValue, partSumDelta;

            if( input.Length > 100000 )
            {
                throw new ArgumentException( "Sorry, but the number of elements should not be higher than 100000!" );
            }
            else if( input.Length < 2 )
            {
                throw new ArgumentException( "Sorry, but the number of elements should not be lower than 2!" );
            }
            for( var i = 0; i < input.Length - 1; i++ )
            {
                int partSum1 = 0, partSum2 = 0;
                for( var j = 0; j <= i; j++ )
                {
                    if( (input[j] <= 1000) && (input[j] >= -1000) )
                    {
                        partSum1 = partSum1 + input[j];
                    }
                    else
                    {
                        throw new ArgumentException( "Sorry, but the integer should not be lower than -1000 nor higher than 1000!" );
                    }
                }

                for( var j2 = i + 1; j2 < input.Length; j2++ )
                {
                    partSum2 += input[j2];
                }

                partSumDelta = Math.Abs( partSum1 - partSum2 );

                if( partSumDelta < minPartSumDelta )
                {
                    minPartSumDelta = partSumDelta;
                }
            }

            return minPartSumDelta;
        }

        public int ImprovedMinDelta( int[] input )
        {
            int minPartSumDelta = int.MaxValue;
            int sumbox1 = 0;
            int sumbox2 = 0;
            int[] sumUp = new int[input.Length];
            int[] sumDown = new int[input.Length - 1];
            int[] sumDelta = new int[input.Length * 2];

            if( input.Length > 100000 )
            {
                throw new ArgumentException( "Sorry, but the number of elements should not be higher than 100000!" );
            }
            else if( input.Length < 2 )
            {
                throw new ArgumentException( "Sorry, but the number of elements should not be lower than 2!" );
            }
            else if( input == null )
            {
                throw new ArgumentException( "Please, enter an array!" );
            }

            for( var i = 0; i < sumUp.Length; i++ )
            {
                if( (input[i] > 1000) || (input[i] < -1000) )
                {
                    throw new ArgumentException( "Sorry, but the integer should not be lower than -1000 nor higher than 1000!" );
                }
                sumUp[i] = sumbox1 + input[i];
                sumbox1 = sumUp[i];
            }

            for( var m = 0; m < sumUp.Length - 1; m++ )
            {
                if( Math.Abs( sumUp[m] - ( sumUp[sumUp.Length - 1] - sumUp[m] ) ) < minPartSumDelta )
                {
                    minPartSumDelta = Math.Abs( sumUp[m] - (sumUp[sumUp.Length - 1] - sumUp[m]) );
                }
            }
            /*
            for( var j = sumDown.Length; j > 0; j-- )
            {
                if( j == sumDown.Length )
                {
                    if( (input[j] > 1000) || (input[j] < -1000) )
                    {
                        throw new ArgumentException( "Sorry, but the integer should not be lower than -1000 nor higher than 1000!" );
                    }
                }

                sumDown[j - 1] = sumbox2 + input[j];
                sumbox2 = sumDown[j - 1];
            }

            for( var k = 0; k < sumUp.Length; k++ )
            {
                if( Math.Abs( sumUp[k] - sumDown[k] ) < minPartSumDelta )
                {
                    minPartSumDelta = Math.Abs( sumUp[k] - sumDown[k] );
                }
            }
            */
            return minPartSumDelta;
        }
    }
}
