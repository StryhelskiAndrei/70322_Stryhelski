using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _70322_Stryhelski.DAL;
using _70322_Stryhelski.Models;
using _70322_Stryhelski.Controllers;


namespace _70322_Stryhelski.Tests
{
    [TestClass]
    public class MyTest
    {
        [TestMethod]
        public void PagingTest()
        {
            // ARRANGE
            // Макет репозитория
            var mock = new Mock<IRepository<Film>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Film>
                {
                    new Film { FilmId = 1 },
                    new Film { FilmId = 2 },
                    new Film { FilmId = 3 },
                    new Film { FilmId = 4 },
                    new Film { FilmId = 5 }
                }
            );

            // Макеты для получения HttpContext и HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание объекта контроллера
            var controller = new FilmController(mock.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Имитация AJAX запросов
            NameValueCollection valueCollection = new NameValueCollection();
            valueCollection.Add("X-Requested-With", "XMLHttpRequest");
            valueCollection.Add("Accept", "application/json");
            request.Setup(r => r.Headers).Returns(valueCollection);

            // ACT
            // Вызов метода List
            var view = controller.List(null, 2) as PartialViewResult;

            // ASSERT
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Film> model = view.Model as PageListViewModel<Film>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].FilmId);
            Assert.AreEqual(5, model[1].FilmId);
        }

        [TestMethod]
        public void CategoryText()
        {
            // ARRANGE
            // Макет репозитория
            var mock = new Mock<IRepository<Film>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Film>
                {
                    new Film { FilmId = 1, Category = "1" },
                    new Film { FilmId = 2, Category = "2" },
                    new Film { FilmId = 3, Category = "1" },
                    new Film { FilmId = 4, Category = "2" },
                    new Film { FilmId = 5, Category = "2" }
                }
            );

            // Создание объекта контроллера
            var controller = new FilmController(mock.Object);

            // Макеты для получения HttpContext и HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // ACT
            // Вызов метода List
            var view = controller.List("1", 1) as ViewResult;

            // ASSERT
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Film> model = view.Model as PageListViewModel<Film>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].FilmId);

            Assert.AreEqual(3, model[1].FilmId);
        }

        [TestMethod]
        public void DefultRouteTest()
        {
            // ARRANGE
            // Макте Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
                .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");

            // Создание коллекции маршрутов и регистрации маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // ACT
            // Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }
    }
}
