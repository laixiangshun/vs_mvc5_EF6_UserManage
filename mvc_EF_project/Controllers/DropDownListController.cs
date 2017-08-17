using mvc_EF_project.DAL;
using mvc_EF_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_EF_project.Controllers
{
    public class DropDownListController : Controller
    {
        private MyDbContext db = new MyDbContext();
        //
        // GET: /DropDownList/
        public ActionResult Index()
        {
            //第一种下拉框绑定方式
            ViewBag.hard_value = new List<SelectListItem>(){
                new SelectListItem(){Value="0",Text="bbbbbb"},
                new SelectListItem(){Value="1",Text="ccccc"}
            };

            //第二种方式，从数据库读取数据进行绑定
            var workers = new List<Worker>();
            var ws = from w in db.Workers
                    select w;
            var selectItemList = new List<SelectListItem>(){
                new SelectListItem(){Value="0",Text="全部",Selected=true}
            };
            var selectList = new SelectList(ws, "FirstName", "LastName");
            selectItemList.AddRange(selectList);
            ViewBag.data = selectItemList;

            //第三种绑定方式：绑定枚举
            ViewBag.from_enum = Enum.GetValues(typeof(Language)).Cast<Language>();
            return View();
        }
	}
    public enum Language
    {
        Chinese,
        English,
        Japan,
        Spanish,
        Urdu
    }
}