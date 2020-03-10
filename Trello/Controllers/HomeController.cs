using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trello.Database;
using Trello.Models;

namespace Trello.Controllers
{
    public class HomeController : Controller
    {

        private TrelloContext _db;

        public HomeController(TrelloContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveTask(TaskCard task)
        {
            try
            {
                if (_db.Cards.Find(task.CardId) == null)
                {
                    _db.Cards.Add(task);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Cards.Update(task);
                    _db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult DeleteTask(TaskCard task)
        {
            try
            {
                _db.Cards.Remove(task);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetTaskCard(int ListId)
        {
            try
            {


                var listCard = _db.Cards.ToList();
                /*
                List<TaskCard> listCard = new List<TaskCard>();
                TaskCard obj1 = new TaskCard { CardId = 1, ListId = 0, Name = "qualquer coisa1"};
                TaskCard obj2 = new TaskCard { CardId = 2, ListId = 0, Name = "qualquer coisa2" };
                TaskCard obj3 = new TaskCard { CardId = 3, ListId = 1, Name = "qualquer coisa3" };
                TaskCard obj4 = new TaskCard { CardId = 4, ListId = 1, Name = "qualquer coisa4" };
                TaskCard obj5 = new TaskCard { CardId = 5, ListId = 2, Name = "qualquer coisa5" };
                TaskCard obj6 = new TaskCard { CardId = 6, ListId = 2, Name = "qualquer coisa6" };

                listCard.Add(obj1);
                listCard.Add(obj2);
                listCard.Add(obj3);
                listCard.Add(obj4);
                listCard.Add(obj5);
                listCard.Add(obj6);
                */

                return Json(listCard.Where(x => x.ListId == ListId));

            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
