using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using mvc_magaza_sitesi.Models;
using System.Diagnostics;

namespace mvc_magaza_sitesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using StreamReader reader = new StreamReader("Appdata/product.txt");
            string productTxt = reader.ReadToEnd();
            var productLines = productTxt.Split('\n');

            var product = new List<Product>();
            
            foreach (var line in productLines)
            {
                var splittedLine = line.Split("|");
                var productToAdd = new Product();
                productToAdd.Name = splittedLine[0];
                productToAdd.Price = splittedLine[1];
                productToAdd.Image = splittedLine[2];
                product.Add(productToAdd);
            }
           
            return View(product);
        }
    }
}
