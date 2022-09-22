using Microsoft.AspNetCore.Mvc;
using POCDependencyLifeCycle.Models;
using POCDependencyLifeCycle.Services;
using System.Diagnostics;

namespace POCDependencyLifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGuid singletonGuid;
        private readonly IScopedGuid scopedGuid;
        private readonly ITransientGuid transientGuid;
        private readonly UseInjectedService useInjectedService;

        public HomeController(ILogger<HomeController> logger, ISingletonGuid singleton, IScopedGuid scoped, ITransientGuid transient, UseInjectedService useInjectedService)
        {

            singletonGuid = singleton;
            scopedGuid = scoped;
            transientGuid = transient;
            this.useInjectedService = useInjectedService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singletonGuid.Guid.ToString();
            ViewBag.Scoped = scopedGuid.Guid.ToString();
            ViewBag.Transient = transientGuid.Guid.ToString();

            ViewBag.ServiceSingleton = useInjectedService.Singleton.Guid.ToString();
            ViewBag.ServiceScoped = useInjectedService.Scoped.Guid.ToString();
            ViewBag.ServiceTransient = useInjectedService.Transient.Guid.ToString();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}