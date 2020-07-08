using System;
using test.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult tableIncomeOutcome()
        {
            return View();
        }
        public IActionResult tableOutcome()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Outcome()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public string req(string summ,string month,string category,string comment)
        { 
            SqlConnection sqlConnection = new SqlConnection(Global.con);
            sqlConnection.Open();
            string cmd = String.Format("insert into dbo.income (summ,month,comment,categoryIncome) values({0},N'{1}',N'{2}',N'{3}')",Convert.ToInt32(summ),month,comment,category);
            SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
            int reader = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
         
            /*
                var parser = new HtmlParser();
                List<string> hrefTags = new List<string>();
                var document = parser.ParseDocument("~/Home/Index");
                foreach (IElement element in document.QuerySelectorAll("a"))
                 {
                    hrefTags.Add(element.GetAttribute("href"));
                 }
            */
            return "добавилена статья  дохода";

        }
     
        [HttpPost]
        public object   categoryComeOut(string categoryComeOut)
        {
            SqlConnection sqlConnection = new SqlConnection(Global.con);
            sqlConnection.Open();
            string cmd = String.Format("insert into dbo.categoryOutcome (category) values(N'{0}')",categoryComeOut);
            SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
            int reader = sqlCommand.ExecuteNonQuery();
            
            sqlConnection.Close();


            return "добавилена категория";
        }
        public IActionResult createComeOut()
        {
            return View();
        }
        public IActionResult createComeIncome()
        {
            return View();
        }
        [HttpPost]
        public string categoryComeIn(string categoryComeIn)
        {
           SqlConnection sqlConnection = new SqlConnection(Global.con);
            sqlConnection.Open();
            string cmd = String.Format("insert into dbo.categoryIncome (category) values(N'{0}')", categoryComeIn);
            SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
            int reader = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
                return "категория добавлена";
            
            
            
        }

        public string req1 (string  summ, string month, string category, string comment)
        {
            try { 
            SqlConnection sqlConnection = new SqlConnection(Global.con);
            sqlConnection.Open();
            string cmd = String.Format("insert into dbo.outcome (summ,month,comment,categoryOutcome) values({0},N'{1}',N'{2}',N'{3}')", Convert.ToInt32(summ), month, comment, category);
           SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
            int reader = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            }
            catch
            {
                return "произошла какая-то ошибка";
            }
            return "добавлена статья расходов";
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
