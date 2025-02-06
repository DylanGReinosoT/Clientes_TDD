using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Controllers
{
	public class ClienteController : Controller
	{
		ClienteDataAccessLayer objClienteDal = new ClienteDataAccessLayer();
		public IActionResult Index()
		{
			List<Cliente> listCliente = new List<Cliente>();
			listCliente = objClienteDal.GetClientes().ToList();
			return View(listCliente);
		}

		[HttpGet]
		public IActionResult Create() { 

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind] Cliente objcliente)
		{
			if (ModelState.IsValid)
			{
				objClienteDal.AddCliente(objcliente);
				return RedirectToAction("Index");
			}
			return View(objcliente);
		}
	}
}
