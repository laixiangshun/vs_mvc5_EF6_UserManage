using mvc_EF_project.DAL;
using mvc_EF_project.Models;
using mvc_EF_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace mvc_EF_project.Controllers
{
    public class UserController : Controller
    {
        private MyDbContext db = new MyDbContext();
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        List<Province> provinceList = new List<Province>(){
             new Province(){provinceId=1,provinceName="湖南",Abbr="hunan_province"},
             new Province(){provinceId=2,provinceName="广东",Abbr="guangdong_province"},
             new Province(){provinceId=3,provinceName="吉林",Abbr="jilin_province"},
             new Province(){provinceId=4,provinceName="四川",Abbr="sichuang_province"}
        };
        public ActionResult Create()
        {
            List<Province> provinceList = new List<Province>();
            var provinces = from p in db.Provinces
                            select p;
            provinceList.AddRange(provinces.ToList());
            ViewBag.ProvinceList=provinceList;
            var model=new User();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userName,address,Province,City,ZipCode,phone")] User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("/DropDownList/Index");
            }
            ViewBag.ProvinceList = provinceList;
            return View(user);
        }
        //返回json数据
        public ActionResult FillCity(int provinceId)
        {
            //var cities = new List<City>(){
            //    new City(){CityId=1,CityName="榆阳",provinceId=1},
            //    new City(){CityId=2,CityName="深圳",provinceId=2},
            //    new City(){CityId=3,CityName="东莞",provinceId=2},
            //    new City(){CityId=4,CityName="沈阳",provinceId=3},
            //    new City(){CityId=5,CityName="成都",provinceId=4},
            //    new City(){CityId=6,CityName="德阳",provinceId=4},
            //    new City(){CityId=7,CityName="西昌",provinceId=4},
            //};
            var citiesList = new List<City>();
            var cities = from c in db.Cities
                         select c;
            citiesList = cities.Where(c => c.provinceId == provinceId).ToList();
            return Json(citiesList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonData()
        {
            var cities = from c in db.Cities
                         select c;
            var cityList = cities.ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < cityList.Count;i++ )
            {
                City city = cityList[i];
                if (i < cityList.Count-1)
                {
                    sb.Append("{CityName:'"+city.CityName+"',provinceId:"+city.provinceId+"},");
                }
                else
                {
                    sb.Append("{CityName:'"+city.CityName+"',provinceId:"+city.provinceId+"}");
                }
            }
            sb.Append("]");
            return Json(sb.ToString());
        }

        public JsonResult GetJsonData2()
        {
            var cities = from c in db.Cities
                         select c;
            var cityList = cities.ToList();
            JsonResult json = new JsonResult();
            json.Data = cityList;
            json.ContentEncoding = Encoding.UTF8;
            return json;
        }

        //多表查询
        [ChildActionOnly]
        public PartialViewResult Query()
        {
            var result = (from p in db.Provinces
                          join c in db.Cities on p.provinceId equals c.provinceId
                          where p.provinceId == 4
                          select new ProvinceByCity{ provinceName=p.provinceName, CityName=c.CityName }).Distinct();
            //返回匿名的数据集
            //var result = (from p in db.Provinces
            //              join c in db.Cities on p.provinceId equals c.provinceId
            //              where p.provinceId == 4
            //              select new { p.provinceName,c.CityName }).Distinct();

            //left join
            var data = (from p in db.Provinces
                        join c in db.Cities on p.provinceId equals c.provinceId into c_join
                        from c in c_join.DefaultIfEmpty()
                        select new ProvinceByCity
                        {
                            provinceName = p.provinceName,
                            CityName = c.CityName
                        });
           // List<ProvinceByCity> dataList = result.ToList();
            List<ProvinceByCity> dataList = data.ToList();
            return PartialView("Query", dataList);
        }

        [ChildActionOnly]
        public PartialViewResult JoinQuery()
        {
            //inner join
            var result = (from p in db.Provinces
                          join c in db.Cities on p.provinceId equals c.provinceId
                          select new ProvinceByCity { provinceName = p.provinceName, CityName = c.CityName }).Distinct();
            List<ProvinceByCity> dataList = result.ToList();
            return PartialView("JoinQuery", dataList);
        }
	}
}