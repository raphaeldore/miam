using System;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.TestUtility.Seed;


namespace Miam.Web.Controllers
{
    public partial class CIController : Controller
    {
        private readonly TestDataSeederHelper _testDataSeederHelper;

        public CIController()
        {
            _testDataSeederHelper = new TestDataSeederHelper();
        }

        public virtual ActionResult Index()
        {
            try
            {
                _testDataSeederHelper.ClearTables();
                _testDataSeederHelper.SeedTables();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été remplie avec les données de tests </Br> <a href=\"\\\" id='go_home'>Go home</a> ");
        }

        public virtual ActionResult ClearDB()
        {
            try
            {
                _testDataSeederHelper.ClearTables();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été effacée.</Br> <a href=\"\\\" id='go_home'>E.T téléphone maison</a> ");
        }
    }
}
