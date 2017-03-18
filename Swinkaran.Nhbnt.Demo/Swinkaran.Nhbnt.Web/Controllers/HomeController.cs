using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Swinkaran.Nhbnt.Web.Models;
using NHibernate.Linq;
using NHibernate.Dialect;
using NHibernate.Cfg;
using NHibernate.Driver;
using System.Reflection;
using Swinkaran.Nhbnt.Web;

namespace Swinkaran.Nhbnt.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            IList<Book> books;

            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStoreDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {

                x.ConnectionString = connStr;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactgory = cfg.BuildSessionFactory();

            using (var session = sessionFactgory.OpenSession())
            using (var tx = session.BeginTransaction())
            {

                // Perform query to
                books = session.CreateCriteria<Book>().List<Book>();


                foreach (var book in books)
                {
                    string title = book.Title;
                }

                tx.Commit();
            }

            //using (ISession session = NHibernateSession.OpenSession())
            //{
            //    var book = session.Query<Book>().ToList();
            //    return View();
            //}

            return View(books);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}