using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace RHSoft.Study.SampleProject
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            try
            {
                SurninTest();
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.Message );
                Console.ReadKey();
            }
            OKostTest();
            SurninTest();
        }

        //public async static Task<string> GetPage(string url)
        //{
        //    try
        //    {

        //        // Creates an HttpWebRequest for the specified URL. 
        //        HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //        // Sends the HttpWebRequest and waits for a response.
        //        HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        //        if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
        //        {
        //            return ("\r\nResponse Status Code is OK and StatusDescription is: {0}" +
        //                                myHttpWebResponse.StatusDescription);
        //            //myHttpWebResponse.Close();
        //        }
        //        // Releases the resources of the response.
        //        else return "Undefined error";

        //    }
        //    catch (WebException e)
        //    {
        //        return "\r\nWebException Raised. The following error occured : {0}" + e.Status;
        //    }
        //    catch (Exception e)
        //    {
        //        return "\nThe following Exception was raised : {0}" + e.Message;
        //    }
        //}
    private static void OKostTest()
        {
            try
            {
                var input = new int[] { -1000, 1000 };

                var cutter = new TapeCutter();

                Console.WriteLine( Convert.ToString( cutter.ImprovedMinDelta( input ) ) + "\nEnter any key to continue..." );
                Console.ReadLine();
            }

            catch( Exception except )
            {
                Console.WriteLine( except.Message + "\nEnter any key to continue..." );
                Console.ReadLine();
            }
        }

        private static void SurninTest()
        {
            Console.WriteLine( "Start Surnin Test!\n" );
            var input = new int[] { 1, -3, 4, 3, 1, 0 };
            var checker = new EsChecker();
            Console.WriteLine( Convert.ToString( checker.IsPermutation( input ) ) );
        }
    }
}
