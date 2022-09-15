using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraceSystem.Data;
using TraceSystem.Models;

namespace TraceSystem.Controllers
{
    public class OperationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OperationController> _logger;
        public OperationController(ApplicationDbContext context, ILogger<OperationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Operation> operations = _context.Operations.Where(p => !p.DeliveryStatus);
            return View(operations);
        }
        public IActionResult ListAllOperation(int page = 1)
        {
            OperationPagingModel pagingModel = new();
            var ChunkedData = _context.Operations.ToList().Chunk(10);
            if (ChunkedData.Count() > 0)
            {
                pagingModel.Operations = ChunkedData.ElementAt(page - 1).ToList();
                pagingModel.CurrentPage = page;
                pagingModel.MaxIndex = ChunkedData.Count();
            }
            return View(pagingModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Operation operation)
        {
            if (ModelState.IsValid)
            {
                _context.Operations.Add(operation);
                _context.SaveChanges();
                var OperationFromDB = _context.Operations.OrderBy(p => p.ID).LastOrDefault();
                if (OperationFromDB == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Detail", new { id = operation.ID });
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var OperationFromDB = _context.Operations.Find(id);
            if (OperationFromDB == null)
            {
                return NotFound();
            }
            return View(OperationFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Operation operation)
        {
            if (ModelState.IsValid)
            {
                _context.Operations.Update(operation);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var OperationFromDB = _context.Operations.Find(id);
            if (OperationFromDB == null)
            {
                return NotFound();
            }
            _context.Operations.Remove(OperationFromDB);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delivery(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var OperationFromDB = _context.Operations.Find(id);
            if (OperationFromDB == null)
            {
                return NotFound();
            }
            OperationFromDB.DeliveryStatus = true;
            OperationFromDB.DeliveryDate = DateTime.Now;
            _context.Operations.Update(OperationFromDB);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            ViewBag.PreviousUrl = Request.Headers.Referer;
            if (id == null)
            {
                return NotFound();
            }
            var OperationFromDB = _context.Operations.Find(id);
            if (OperationFromDB == null)
            {
                return NotFound();
            }
            return View(OperationFromDB);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
