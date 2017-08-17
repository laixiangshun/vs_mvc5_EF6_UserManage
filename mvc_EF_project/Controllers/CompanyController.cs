using mvc_EF_project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using mvc_EF_project.Models;
using System.Net;
using System.Data.Entity;

namespace mvc_EF_project.Controllers
{
    public class CompanyController : Controller
    {
        private MyDbContext db = new MyDbContext();
        //
        // GET: /Company/
        public ActionResult Index(string sortOrder,string searchString,string currentFilter,int ? page)
        {
            ViewBag.currentSort = sortOrder;
            //用Viewbag存储当前排列的相反排列字符串，用于在View中生成链接
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var workers = from w in db.Workers
                          select w;
            if (!String.IsNullOrEmpty(searchString)) {
                workers = workers.Where(w => w.FirstName.Contains(searchString) || w.LastName.Contains(searchString));
            }
            switch (sortOrder) { 
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.FirstName);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.LastName);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.LastName);
                    break;
                default:
                    workers = workers.OrderBy(w => w.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);//其中(page ?? 1)的意思是如果page为null则给page赋值为1否则，page不为null那么该是多少就是多少。所以能让默认页为1
            return View(workers.ToPagedList(pageNumber,pageSize));
        }


        //添加页面
        public ViewResult Create() {
            return View();
        }
        //添加提交
        [HttpPost]
        [ValidateAntiForgeryToken] //防止跨站请求伪造攻击
        //[Bind(Include = "FirstName, LastName, Sex, Rating")]是为了防止过多提交(overposting)攻击的
        public ActionResult Create([Bind(Include = "FirstName,LastName,Sex,Rating")]Worker worker) {
            try
            {
                if (ModelState.IsValid)//提交的数据是否有效
                {
                    db.Workers.Add(worker);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e) {
                ModelState.AddModelError("unableToSave", "添加失败");
                //给Model添加一条错误信息，函数的第一个参数是key，用于查找这个错误信息,第二个参数是错误信息的具体内容
                //这个错误信息可以在View中通过Html.ValidationMessage("unableToSave")来访问到
            }
            return View(worker);
        }

        //查看详情
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null) {
                return HttpNotFound();
            }
            return View(worker);
        }

        //编辑
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //此处绑定ID以便提交后找到对应的记录进行更新
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Sex,Rating")] Worker worker) {
            if (ModelState.IsValid) {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        //删除
        public ActionResult Delete(int id) {
            try
            {
                Worker worker = new Worker() { ID = id };
                db.Entry(worker).State=EntityState.Deleted;
                db.SaveChanges();
            }catch(Exception e){
                return RedirectToAction("Index",new{id=id,saveChangesError=true});
            }
            return RedirectToAction("Index");
        }
	}
}