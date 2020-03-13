namespace RHSoft.Study.SampleProject
{
    public class MonotoneChecker
    {
        public bool IsMonotone( int[] input )
        {
            if( input.Length < 2 )
            {
                return false;
            }
            var first = input[0];
            var second = input[1];
            var isRising = second > first;
            for( var i = 1; i < input.Length; ++i )
            {
                var current = input[i];
                var pred = input[i - 1];
                if( current <= pred && isRising )
                {
                    return false;
                }
                if( current >= pred && !isRising )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
