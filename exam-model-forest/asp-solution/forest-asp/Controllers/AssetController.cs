using forest_asp.DataAbstractionLayer;
using forest_asp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace forest_asp.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View("ViewAsset");
        }

        public ActionResult GetAssetsOfUser()
        {

            DAL dal = new DAL();
            int uid = int.Parse(Request.Params["userId"]);
            List<Asset> assetsList = dal.getAssetsOfUser(uid);
            return Json(new { assets = assetsList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddAssets()
        {
            DAL dal = new DAL();


            List<Asset> list = JsonConvert.DeserializeObject<List<Asset>>(Request.Params["newAssetsToAdd"]);
            foreach (Asset asset in list)
            {
                Debug.WriteLine(asset.ToString());
                dal.SaveAsset(asset);
            }
            return Json(new { });
        }

    }
}