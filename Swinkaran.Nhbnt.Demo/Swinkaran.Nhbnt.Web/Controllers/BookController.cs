﻿using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Swinkaran.Nhbnt.Web.Models;

namespace Swinkaran.Nhbnt.Web.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            IList<Book> books;

            using (ISession session = NHibernateSession.OpenSession())
            {
                books = session.Query<Book>().ToList();
            }

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = new Book();

            using (ISession session = NHibernateSession.OpenSession())
            {
                book = session.Query<Book>().Where(b => b.Id == id).FirstOrDefault();
            }

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Book book = new Book();
                book.Id = 115;
                book.Title = collection["Title"].ToString();
                book.Genre = collection["Genre"].ToString();
                book.Author = collection["Author"].ToString();

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(book);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = new Book();

            using (ISession session = NHibernateSession.OpenSession())
            {
                book = session.Query<Book>().Where(b => b.Id == id).FirstOrDefault();
            }

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Book book = new Book();
                book.Id = id;
                book.Title = collection["Title"].ToString();
                book.Genre = collection["Genre"].ToString();
                book.Author = collection["Author"].ToString();

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(book);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the book

            return RedirectToAction("Index");
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
