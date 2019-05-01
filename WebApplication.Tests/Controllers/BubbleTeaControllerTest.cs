using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Models;
using WebApplication.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class BubbleTeaControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new CS4PEEntities();
            var controller = new BubbleTeaController();
            var result = controller.Index();
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as List<BubleTea>;

            Assert.IsNotNull(model);

            Assert.AreEqual(db.BubleTea.Count(), model.Count);
        }

        [TestMethod]
        public void TestDetails()
        {
            var db = new CS4PEEntities();
            var item = db.BubleTea.First();
            var controller = new BubbleTeaController();
            var result = controller.Details(item.id);
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as BubleTea;

            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

            result = controller.Details(0);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void TestCreateGet()
        {
            var controller = new BubbleTeaController();
            var result = controller.Create();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var db = new CS4PEEntities();
            var model = new BubleTea
            {
                Name = "Tra sua VL",
                Price = 25000,
                Topping = "Tran chau trang"
            };
            var controller = new BubbleTeaController();
            var result = controller.Create(model);
            var redirect = result as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);

            var item = db.BubleTea.Find(model.id);

            Assert.IsNotNull(item);
            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);
        }

        [TestMethod]
        public void TestEditGet()
        {
            var controller = new BubbleTeaController();
            var result0 = controller.Edit(0);

            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new CS4PEEntities();
            var item = db.BubleTea.First();
            var result1 = controller.Edit(item.id);
            var view = result1 as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as BubleTea;

            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
        }

        [TestMethod]
        public void TestEditPost()
        {
            var db = new CS4PEEntities();
            var item = db.BubleTea.First();
            var controller = new BubbleTeaController();
            var result = controller.Edit(item.id);
            var view = result as ViewResult;

            Assert.IsNotNull(view);

            var model = view.Model as BubleTea;

            Assert.IsNotNull(model);

            var result1 = controller.Edit(model);
            var redirect = result1 as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [TestMethod]
        public void TestDelete()
        {
            var controller = new BubbleTeaController();
            var result = controller.Delete(0);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

            var db = new CS4PEEntities();
            var item = db.BubleTea.First();
            var result1 = controller.Delete(item.id) as ViewResult;

            Assert.IsNotNull(result1);

            var model = result1.Model as BubleTea;

            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
        }

        [TestMethod]
        public void TestDeleteConfirm()
        {
        }
    }
}
