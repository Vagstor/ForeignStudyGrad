using System;
using System.Collections.Generic;
using System.Text;

namespace RHSoft.Study.SampleProject
{
    public class EsChecker
    {
        public int IsPermutation( int[] input )
        {
            if( input.Length == 0 )
            {
                return 0;
            }
            if( input.Length > 100000 )
            {
                throw new ArgumentException( "Array's length is out of bounds, its length should not be more 100000" );
            }

            int[] check = new int[input.Length];

            for( int i = 0; i < input.Length; i++ )
            {
                if( input[i] > 1000000000 || input[i] < 1 )
                {
                    throw new ArgumentException( $"Element value '{input[i]}' is out of bounds" );
                }
                else
                {
                    int currentValue = input[i];
                    if( currentValue > input.Length || currentValue < 1 )
                    {
                        return 0;
                    }
                    else
                    {
                        if( check[currentValue - 1] == 0 )
                        {
                            check[currentValue - 1] = 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            return 1;
        }

    }
}

