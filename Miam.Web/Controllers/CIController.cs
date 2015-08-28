using System;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.TestUtility.Seed;


namespace Miam.Web.Controllers
{
    public partial class CIController : Controller
    {
        private IApplicationDatabaseHelper _dbInit;

        public CIController(IApplicationDatabaseHelper dbInit)
        {
            if (dbInit == null) throw new NullReferenceException();
            
            _dbInit = dbInit;
        }

        public virtual ActionResult Index()
        {
            try
            {
                DeleteDb();
                SeedDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été remplie avec les données de tests </Br> <a href=\"\\\" id='go_home'>E.T téléphone maison</a> ");
        }

        public virtual ActionResult ClearDB()
        {
            try
            {
                DeleteDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été effacée.</Br> <a href=\"\\\" id='go_home'>E.T téléphone maison</a> ");
        }

        private void DeleteDb()
        {
            _dbInit.ClearAllTables();
        }

        private void SeedDb()
        {
            var testData = new SeedDataBase(new ApplicationContext());
            testData.SeedTables();
        }
    }
}
