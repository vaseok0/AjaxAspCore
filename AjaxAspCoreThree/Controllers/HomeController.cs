using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AjaxAspCoreThree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AjaxAspCoreThree.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db;

        public HomeController(MyDbContext myDb)
        {
            db = myDb;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Вопроси по С#
        /// </summary>
        /// <returns></returns>
        public IActionResult QuestSharp()
        {
            ViewBag.Count = db.QuestionData.Count();  // получение количества вопросов
            var result = db.QuestionData.Where(a => a.Id == 1);
            foreach (var item in result)
            {
            }
            return View(result);
        }
        
        /// <summary>
        /// Проверка на правильность ответа пользователя
        /// </summary>
        /// <param name="answer">Вибраний ответ</param>
        /// <param name="questId">Id вопроса</param>
        /// <returns></returns>
        public IActionResult GetCheckAnswer(string answer, int questId)
        {
            var item = db.QuestionData.Where(a => a.Id == questId).Select(a => a.Answer);
            if (answer == item.First())
            {
                return Json("");
            }
            else
            {
                return Json(item.First());
            }
        }

        /// <summary>
        /// Переход по вопросам
        /// </summary>
        /// <param name="questId">Id пройденого вопроса</param>
        /// <returns></returns>
        public IActionResult GetOrderDisplay(int questId)
        {
            IQueryable<QuestionData> result;
            var count = db.QuestionData.Count(); //получение колличества вопросов
            ViewBag.NowCount = questId;
            questId++;
            if (questId > count)
            {
                //TODO: Действия после прохождения всех тестов.
                return Json("");
            }
            else
            {
                result = db.QuestionData.Where(a => a.Id == questId);
                return Json(result);
            }
        }

        /// <summary>
        /// Подведение итогов пройденого теста
        /// </summary>
        /// <param name="questId"></param>
        /// <returns></returns>
        public IActionResult Summation(int questId)
        {
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
