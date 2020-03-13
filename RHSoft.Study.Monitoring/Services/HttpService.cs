using RHSoft.Study.Monitoring.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RHSoft.Study.Monitoring.Services
{
    public class HttpService
    {
        public StatusCheck GetSiteResponse(string url)
        {
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                return new StatusCheck((int)myHttpWebResponse.StatusCode);
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    return new StatusCheck((int)((HttpWebResponse)e.Response).StatusCode);
                }
                else
                {
                    return new StatusCheck((int)(e.Status));
                }
            }
        }
    }
}
