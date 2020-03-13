using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RHSoft.Study.Monitoring.Services
{
    public class MonitoringService
    {
        private IServiceProvider _serviceProvider;
        private Thread _thread;

        public MonitoringService( IServiceProvider serviceProvider )
        {
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {
            Console.WriteLine( "Monitoring started. ServcieProvider: {0}", _serviceProvider );

            _thread = new Thread( Process );
            _thread.Start();
        }
        public bool CheckThreadState() {
            Console.WriteLine( "\n\n\n\n\n\n\n"+"/n/n/n"+_thread.ThreadState );
            if( _thread.ThreadState == ThreadState.WaitSleepJoin )
            {
                return true;
            }
            else
                return false;
        }
        public void Stop()
        {
            _thread.Interrupt();
            Console.WriteLine( "Monitoring stopped. ServcieProvider: {0}", _serviceProvider );
            //throw new NotImplementedException();
        }

        private void Process( object state )
        {
            try
            {
                while( true )
                {
                    Console.WriteLine( "Monitoring action {0}", DateTime.Now );
                    // отдельная песочница в рамках которой будет жить соединениес 
                    // с БД и прочие сервисы
                    using( var scope = _serviceProvider.CreateScope() )
                    {
                        var service = scope.ServiceProvider.GetService<SiteService>();
                        var httpservice = scope.ServiceProvider.GetService<HttpService>();
                        CheckSites( service, httpservice );
                    }

                    Thread.Sleep( 10000 );
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine( "error in monitoging run:{0}", ex );
            }
        }

        private void CheckSites( SiteService siteService, HttpService httpService )
        {
            var sites = siteService.GetAllSites();
            foreach(Site site in sites )
            {
                Visit currentVisit = new Visit();
                currentVisit.Id = Guid.NewGuid();
                currentVisit.Url = site.Url;
                currentVisit.VisitTime = DateTime.Now;
                currentVisit.SiteId = site.Id;
                currentVisit.Status = httpService.GetSiteResponse(site.Url).Status;
                siteService.SaveVisit( currentVisit );
            }
            Console.WriteLine( "Checking sites. SiteService: {0}", siteService );
        }
    }
}
