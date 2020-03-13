﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RHSoft.Study.Monitoring.Models;
using RHSoft.Study.Monitoring.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace RHSoft.Study.Monitoring.Controllers
{
    [Authorize]
    public class WebSitesController : Controller
    {
        private SiteService _siteService;
        private HttpService _httpService;
        private MonitoringService _monitoringService;
        public WebSitesController(SiteService siteService, HttpService httpService, MonitoringService monitoringService )
        {
            _siteService = siteService;
            _httpService = httpService;
            _monitoringService = monitoringService;
        }

        public IActionResult Index(SitesViewModel model)
        {
            model.Sites = _siteService.GetSites(new Guid(HttpContext.User.FindFirst("userId")?.Value));
            return View(model);
        }

        //public void ModifiedIndex(WebSitesViewModel model)
        //{
        //    model.SiteToAdd.siteStatus = GetPage(model.SiteToAdd.siteURL);
        //    _siteService.SaveSite(model.SiteToAdd);
        //    //model.WebSites.Add(model.SiteToAdd);
        //    //return View(model);
        //    Response.Redirect("https://localhost:5001/WebSites/Index/");
        //}
        
        [HttpPost]
        public IActionResult AddSite( SiteModel model )
        {
            var site = new Site
            {
                Id = Guid.NewGuid(),
                Url = model.url,
                UserId = new Guid( HttpContext.User.FindFirst( "userId" )?.Value ),
                AddTime = DateTime.Now
            };
            if( !ModelState.IsValid )
            {
                return View( model );
            }
            else
            {
                if( _siteService.IsUsersSiteAlreadyInDB( site ) )
                {
                    ModelState.AddModelError( "url", "Такой сайт уже присутствует в Вашем списке наблюдения" );
                    return View( model );
                }
                else
                {
                    _siteService.SaveSite( site );
                    return RedirectToAction( "SitesList", "WebSites" );
                }
            }
        }

        [HttpGet]
        public ActionResult EditSite( Guid id )
        {
            Site site = _siteService.GetSite( id );
            //var currentSite = new WebSiteModel()
            //{
            //    siteURL = site.Url,
            //    siteStatus = site.Name,
            //    siteID = site.Id
            //};
            var editSite = new SiteModel
            {
                id = site.Id,
                url = site.Url
            };
            return View( editSite );
        }

        [HttpGet]
        public ActionResult Details( Guid id )
        {
            VisitsViewModel model = new VisitsViewModel();
            model.visits = _siteService.GetVisits( new Guid( HttpContext.User.FindFirst( "userId" )?.Value ), id );
            var site = _siteService.GetSite( id );
            ViewBag.SiteStatus = site.LastStatus;
            ViewBag.SiteAddTime = site.AddTime;
            if( model.visits.Count != 0 )
            {
                ViewBag.SiteLastCheck = model.visits.Where( p => p.SiteId == id ).FirstOrDefault().VisitTime;
            }
            else
            {
                ViewBag.SiteLastCheck = "Сайт еще не подвергался проверке";
            }
            return View( model );
        }

        [HttpGet]
        public ActionResult SiteLogs( string url )
        {
            var visits = _siteService.GetSiteVisits( url );
            return View( visits );
        }
        public IActionResult UpdateSiteState( Guid id)
        {
            Site site = _siteService.GetSite(id);
            Visit visit = new Visit();
            visit.SiteId = site.Id;
            visit.Id = Guid.NewGuid();
            visit.Url = site.Url;
            visit.VisitTime = DateTime.Now;
            visit.Status = _httpService.GetSiteResponse(visit.Url).Status;
            _siteService.UpdateSite(site, visit.Status);
            return RedirectToAction("SitesList");
        }
        [HttpPost]
        public ActionResult EditSite( SiteModel site )
        {
            //site.siteStatus = GetPage( site.siteURL );
            //_siteService.EditSite( site );
            //return RedirectToAction("SitesList");
            var editSite = new Site
            {
                Id = site.id,
                Url = site.url,
                UserId = new Guid( HttpContext.User.FindFirst( "userId" )?.Value ),
                AddTime = DateTime.Now
            };
            if( !ModelState.IsValid )
            {
                return View( site );
            }
            if( _siteService.IsUsersSiteAlreadyInDB( editSite ) )
            {
                ModelState.AddModelError( "url", "Такой сайт уже присутствует в Вашем списке наблюдения" );
                return View( site );
            }
            else
            {
                _siteService.EditSite( editSite );
                return RedirectToAction( "SitesList", "WebSites" );
            }
        }

        //public void AddVisit()
        //{
        //    List<Site> sites = _siteService.GetSites();
        //    //model.WebSites.Add(model.SiteToAdd);
        //    //return View(model);
        //    //return "Сайт добавлен в список";
        //    foreach (Site st in sites)
        //    {
        //        Visit visit = new Visit();
        //        visit.url = st.Url;
        //        visit.VisitStatus = _serviceG(st.siteURL);
        //        vm.visitTime = DateTime.Now;
        //        vm.siteId = st.siteID;
        //        _siteService.SaveVisit(vm);
        //    }
        //    Response.Redirect("https://localhost:5001/WebSites/Index/");
        //}

        [HttpGet]
        public IActionResult SitesLog()
        {
            List<Site> distinctSites = new List<Site>();
            distinctSites = _siteService.GetSites(new Guid(HttpContext.User.FindFirst("userId")?.Value));
            ViewBag.DistinctSites = distinctSites;
            // var model = GetVisitsViewModel();
            //return View( model );
            return View();
        }

        [HttpPost]
        public IActionResult SiteVisits(string url)
        {
            var visits = _siteService.GetSiteVisits( url );
            return PartialView( visits );
        }
        [HttpGet]

        public IActionResult SitesList()
        {
            //List<string> statusList = new List<string>();
            //foreach (Site site in sites)
            //{
            //    statusList.Add(CheckSite(site));
            //}
            //ViewBag.Status = statusList;
            ViewBag.Status = _monitoringService.CheckThreadState();
            SitesViewModel model = new SitesViewModel();
            model.Sites = _siteService.GetSites(new Guid(HttpContext.User.FindFirst("userId")?.Value));
            return View(model);
        }

        //private SitesViewModel GetWebSitesViewModel()
        //{
        //    SitesViewModel model = new SitesViewModel() { Sites = _siteService.GetSites(new Guid(HttpContext.User.FindFirst("userId")?.Value)) };
        //    return model;
        //}

        //private VisitsViewModel GetVisitsViewModel(Site site)
        //{
        //    VisitsViewModel model = new VisitsViewModel() { visits = _siteService.GetVisits(new Guid(HttpContext.User.FindFirst("userId")?.Value), site.Id)};
        //    return model;
        //}

        public IActionResult ShowSite(Site site)
        {
            return View(_siteService.GetVisits( new Guid( HttpContext.User.FindFirst( "userId" )?.Value ), site.Id ) );
        }

        public IActionResult AddSite()
        {
            return View();
        }
        //public IActionResult HistoryStatus()
        //{
        //    return View();
        //}
        public IActionResult StopUpdate()
        {
            _monitoringService.Stop();
            return RedirectToAction( "SitesList" );
        }
        public IActionResult StartUpdate()
        {
            _monitoringService.Run();
            return RedirectToAction( "SitesList" );
        }
        public IActionResult CheckThread()
        {
            _monitoringService.CheckThreadState();
            return RedirectToAction( "SitesList" );
        }
        //public bool CheckThreadState()
        //{
        //    return _mo
        //}
        //public string CheckSite(Site site)
        //{
        //    return _siteService.CheckSiteState(site);
        //}
    }
}