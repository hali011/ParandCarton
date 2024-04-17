using ParandCartonUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ParandCartonUpdate.Formula;
using ParandCartonUpdate.APIClass;
using ParandCartonUpdate.ClassHelper;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;

namespace ParandCartonUpdate.Controllers
{
    public class HomeController : Controller
    {
        #region Login
        public ActionResult LoginPage()
        {
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
        #endregion

        #region OrderInfoPage
        #region LoadView
        public ActionResult OrderInformation()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                var user = Session["UserInfo"] as UserInfo;
                ViewBag.time = getdatetime(1);
                ViewBag.usercode = user.Id;
                ViewBag.username = user.UserName + " " + user.UserFamily;
                ViewBag.sefareshcode = GetProdouctCode();
                return PartialView("OrderInformation");
            }
        }
        private int GetProdouctCode()
        {
            int id = 1;
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                var data = db.PriceInfoes.ToList();
                if (data.Count <1)
                {
                    id = 1;
                }
                else
                {
                    var onedata = data.LastOrDefault();
                    id = onedata.id + 1;
                }
            }
            return id;
        }
        #endregion
        #region Load Modal With Data 
        [HttpPost]
        public ActionResult loadmodalcustomer()
        {
            return PartialView("modalCustomer");
        }
        public JsonResult BindCustomer()
        {
            var customers = CustomerAPI.GetListCustomerAPI();
            return Json(customers);
        }
        public JsonResult SelectCustomer(string id)
        {

            List<string> item = new List<string>();

            List<List<string>> customers = new List<List<string>>();
            customers = CustomerAPI.GetListCustomerAPI();
            foreach (var listItem in customers)
            {
                if (listItem[0] == id)
                {
                    item.Add(listItem[1]);
                    item.Add(listItem[2]);
                }
            }
            return Json(item);
        }
        [HttpPost]
        public ActionResult loadmodalproduct()
        {
            return PartialView("modalProduct");
        }
        public JsonResult BindProduct()
        {
            var product = ProductAPI.GetListProductAPI();
            return Json(product);
        }
        public JsonResult SelectProduct(string id)
        {

            List<string> item = new List<string>();

            List<List<string>> products = new List<List<string>>();
            products = ProductAPI.GetListProductAPI();
            foreach (var listItem in products)
            {
                if (listItem[0] == id)
                {
                    item.Add(listItem[1]);
                    item.Add(listItem[2]);
                }
            }
            return Json(item);
        }
        #endregion
        #region Save&Edit OrderInformation
        [HttpPost]
        public ActionResult SaveOI(string CreateDate, string customercode, string customername, int salepersoncode, string productcode, string productname, string salepersonname, string address, string nationalcode, string postalcode, string rabetsazmani, string enconomiccode,string tell, string Tellrabetsazmani, string customeremail)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                string ordercode = "";
                var user = Session["UserInfo"] as UserInfo;
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    OrderInfo oi = new OrderInfo();
                    oi.Whosave = Convert.ToInt32(user.Id);
                    oi.CreateDate = CreateDate;
                    oi.CustomerCode = customercode;
                    oi.CustomerName = customername;
                    oi.SaleExpertCode = salepersoncode.ToString();
                    oi.ProductCode = productcode;
                    oi.ProductName = productname;
                    oi.SaleExpertName = salepersonname;
                    oi.Address = address;
                    if (nationalcode != "")
                    {
                        oi.NationalCode = Convert.ToDecimal(nationalcode);
                    }
                    if (postalcode != "")
                    {
                        oi.PostalCode = Convert.ToDecimal(postalcode);
                    }
                    oi.EnterPriceInterfaceName = rabetsazmani;
                    if (enconomiccode != "")
                    {
                        oi.EnconomicCode = Convert.ToDecimal(enconomiccode);
                    }
                    if(tell != "")
                    {
                        oi.Tell = Convert.ToDecimal(tell);
                    }
                    if(Tellrabetsazmani != "")
                    {
                        oi.EnterPriceInterfaceTell = Convert.ToDecimal(Tellrabetsazmani);
                    }
                    oi.Email = customeremail;
                    db.OrderInfoes.Add(oi);
                    db.SaveChanges();
                    ordercode = oi.OrderCode;
                }
                return Json(new { ordercode = ordercode });
            }
        }
        #endregion
        #region Dell OrderInformation
        [HttpPost]
        public JsonResult DeleteOi(int id)
        {
            bool flag = false;
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                var oi = db.OrderInfoes.Where(w => w.Id == id).SingleOrDefault();
                db.OrderInfoes.Remove(oi);
                db.SaveChanges();
                flag = true;
            }
            return Json(new { isok = flag });
        }
        #endregion
        #region Load EditData
        [HttpPost]
        //public JsonResult loadforeditOI(int id)
        //{
        //    OrderInfo oi = new OrderInfo();
        //    using (ParandCartondbEntities db = new ParandCartondbEntities())
        //    {
        //        oi = db.OrderInfoes.Where(w => w.Id == id).SingleOrDefault();
        //    }
        //    string salepersoncode = oi.SaleExpertCode;
        //    string salepersonname = oi.SaleExpertName;
        //    string customercode = oi.CustomerId;
        //    string customername = oi.CustomerName;
        //    string postalcode = oi.PostalCode;
        //    string enconomiccode = oi.EconomicCode;
        //    string customeremail = oi.CustometEmail;
        //    string productcode = oi.ProductId;
        //    string productname = oi.ProductName;
        //    string tell = oi.Tell;
        //    string address = oi.Address;
        //    return Json(new
        //    {
        //        isok = true,
        //        salepersoncode = salepersoncode,
        //        salepersonname = salepersonname,
        //        customercode = customercode,
        //        customername = customername,
        //        postalcode = postalcode,
        //        enconomiccode = enconomiccode,
        //        customeremail = customeremail,
        //        productcode = productcode,
        //        productname = productname,
        //        tell = tell,
        //        address = address
        //    });
        //}
        #endregion
        #endregion

        #region TechnicalInfoPage 
        public ActionResult CartonTechnicalInfo()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                return PartialView("CartonTechnicalInfo");
            }
        }
        #region SaveTechnicalInformation
        [HttpPost]
        public ActionResult SaveTI(bool technicalltype, string cartontype, int cartoncount, int cartonlenght, int cartonweight, string contenttype, int cartonwidth, int cartonheight, bool sardkhone, bool nemone, int connection, bool space)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                bool isok = false;
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    var user = Session["UserInfo"] as UserInfo;
                    var cartonti = new CartonTechnicalInfo();
                    var oi = db.OrderInfoes.Where(x => x.Whosave == user.Id).ToList().LastOrDefault();
                    cartonti.OrderInfoId = oi.Id;
                    cartonti.type = technicalltype;
                    cartonti.CartonType = cartontype;
                    cartonti.CartonCount = cartoncount;
                    cartonti.CartonLength = cartonlenght;
                    cartonti.CartonWidth = cartonwidth;
                    cartonti.CartonHeight = cartonheight;
                    cartonti.CartonWeight = cartonweight;
                    cartonti.IsCold = sardkhone;
                    cartonti.IsTemplate = nemone;
                    cartonti.CartonEmpty = space;
                    cartonti.ConnectorType = connection;
                    cartonti.Whosave = Convert.ToInt32(user.Id);
                    cartonti.CartonInsideType = contenttype;
                    db.CartonTechnicalInfoes.Add(cartonti);
                    db.SaveChanges();
                    isok = true;
                }
                return Json(new { isok = isok });
            }

        }
        [HttpPost]
        public ActionResult SaveTIV(bool technicalltype, int sheetcount, int sheettoal, int sheetarz, string sheettype, int cartonwidth, int cartonheight, int cartonlenght, int sheetweught)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                bool isok = false;
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    var user = Session["UserInfo"] as UserInfo;
                    var cartonti = new CartonTechnicalInfo();
                    var oi = db.OrderInfoes.Where(x => x.Whosave == user.Id).ToList().LastOrDefault();
                    cartonti.OrderInfoId = oi.Id;
                    cartonti.type = technicalltype;
                    cartonti.SheatCount = sheetcount;
                    cartonti.SheatLength = sheettoal;
                    cartonti.SheatWidth = sheetarz;
                    cartonti.SheatType = sheettype;
                    cartonti.CartonWidth = cartonwidth;
                    cartonti.CartonHeight = cartonheight;
                    cartonti.CartonLength = cartonlenght;
                    cartonti.Whosave = Convert.ToInt32(user.Id);
                    db.CartonTechnicalInfoes.Add(cartonti);
                    db.SaveChanges();
                    isok = true;
                }
                return Json(new { isok = isok }, JsonRequestBehavior.AllowGet);
            }

        }
        private bool getbool(int x)
        {
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int getcontenttypeid(string x)
        {
            if (x == "نوع اول")
            {
                return 1;
            }
            else if (x == "نوع دوم")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        private int getcartontypeid(string x)
        {
            switch (x)
            {
                case "باکس امریکایی":
                    return 1;
                case "چاپی دایکاتی":
                    return 2;
                case "تلسکوپی":
                    return 3;
                case "کفی":
                    return 4;
                case "سفارشی":
                    return 5;
                default:
                    return 0;
            }
        }
        #endregion
        #region پر کردن دراپ داون
        #region نوع کارتن
        [HttpPost]
        public ActionResult cartontype()
        {
            List<string> lstcartontype = GetDataT();
            return Json(lstcartontype, JsonRequestBehavior.AllowGet);
        }
        private List<string> GetDataT()
        {
            List<CartonType> lstcartontyps = new List<CartonType>();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                var types = db.CartonTypes;
                lstcartontyps = types.ToList();
            }
            List<string> valueofcartonstype = new List<string>();
            foreach (var type in lstcartontyps)
            {
                valueofcartonstype.Add(type.CartonTypeName);
            }
            return valueofcartonstype;
        }
        #endregion
        #region نوع محتوای کارتن
        [HttpPost]
        public ActionResult contentcarton()
        {
            List<string> lstcontent = GetcontentData();
            return Json(lstcontent, JsonRequestBehavior.AllowGet);
        }
        private List<string> GetcontentData()
        {
            List<InsideProduct> lstcontent = new List<InsideProduct>();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                var types = db.InsideProducts;
                lstcontent = types.ToList();
            }
            List<string> valueofcartoncontenttype = new List<string>();
            foreach (var item in lstcontent)
            {
                valueofcartoncontenttype.Add(item.Title);
            }
            return valueofcartoncontenttype;
        }
        #endregion

        #endregion
        #region load Info For Fill data When Click on Edit
        //public ActionResult Loadforedit(int id)
        //{
        //    CartonTechnicalInfo editTI = new CartonTechnicalInfo();
        //    using (ParandCartondbEntities db = new ParandCartondbEntities())
        //    {
        //        editTI = db.CartonTechnicalInfoes.Where(w => w.Id == id).SingleOrDefault();
        //    }
        //    return Json(new { cartontype = editTI.CartonTypeId, contenttype = editTI.CartonProductInsideId, cartoncount = editTI.CartonCount, cartonweight = editTI.CartonProductWeight, cartonlenght = editTI.CartonLength, cartonwidth = editTI.CartonWidth, cartonheight = editTI.CartonHeight, sardkhone = editTI.IsCold, nemone = editTI.IsSample, connection = editTI.ConnectorType, space = editTI.CartonEmpty });
        //}
        #endregion
        #region DeleteTechnicalInformation
        public ActionResult delTi(int id)
        {
            bool flag = false;
            CartonTechnicalInfo delTI = new CartonTechnicalInfo();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                delTI = db.CartonTechnicalInfoes.Where(w => w.Id == id).SingleOrDefault();
                db.CartonTechnicalInfoes.Remove(delTI);
                db.SaveChanges();
                flag = true;
            }
            return Json(new { success = flag });
        }
        #endregion
        #endregion 

        #region PrintInformationPage
        #region LoadView
        public ActionResult PrintInformation()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                return PartialView("PrintInformation");
            }
        }
        #endregion
        #region LoadModal
        public ActionResult loadmodalstore()
        {
            List<KelisheForm> final = new List<KelisheForm>();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                List<KelisheForm> frms = new List<KelisheForm>();
                frms = db.KelisheForms.ToList();
                foreach (var item in frms)
                {
                    if (item.Type == false)
                    {
                        final.Add(item);
                    }
                }
            }
            return PartialView("ModalStore", final);
        }
        public JsonResult SelectStock(int id)
        {
            string code = "";
            using (ParandCartondbEntities fda = new ParandCartondbEntities())
            {
                KelisheForm frms = new KelisheForm();
                frms = fda.KelisheForms.Where(w => w.Id == id).SingleOrDefault();
                code = frms.Code;
            }
            return Json(new { code = code });
        }
        public ActionResult loadmodalklishe()
        {
            List<KelisheForm> final = new List<KelisheForm>();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                List<KelisheForm> kl = new List<KelisheForm>();
                kl = db.KelisheForms.ToList();
                foreach (var item in kl)
                {
                    if (item.Type == true)
                    {
                        final.Add(item);
                    }
                }
            }
            return PartialView("ModalKelishe", final);
        }
        public JsonResult SelectKlishe(int id)
        {
            string code = "";
            using (ParandCartondbEntities fda = new ParandCartondbEntities())
            {
                KelisheForm frms = new KelisheForm();
                frms = fda.KelisheForms.Where(w => w.Id == id).SingleOrDefault();
                code = frms.Code;
            }
            return Json(new { code = code });
        }
        #endregion
        #region Save&Edit PrintInformation
        [HttpPost]
        public ActionResult SavePI(string colorcode1 , string colorcode2 , string colorcode3 , string colorcode4 , string colorcode5 ,string printtype, string paintcount, List<string> printtypeselection, string klishenum, string printamount, string templatenum)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                bool flag = false;
                bool isklishe = false;
                if (klishenum != string.Empty)
                {
                    isklishe = true;
                }
                bool istamplate = false;
                if (templatenum != string.Empty)
                {
                    istamplate = true;
                }
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    PrintInfo pi = new PrintInfo();
                    var user = Session["UserInfo"] as UserInfo;
                    var oi = db.OrderInfoes.Where(x => x.Whosave == user.Id).ToList().LastOrDefault();
                    var cti = db.CartonTechnicalInfoes.Where(x => x.Whosave == user.Id).ToList().LastOrDefault();
                    pi.Whosave = Convert.ToInt32(user.Id);
                    pi.OrderInfoId = oi.Id;
                    pi.CartonTechnicalId = cti.Id;
                    pi.PrintType = printtype;
                    pi.ColorCount = paintcount;
                    if (printtypeselection != null)
                    {
                        pi.PrintTypeSelection = strprinttypeselection(printtypeselection);
                    }
                    pi.PrintAmount = printamount;
                    pi.IsKelishe = isklishe;
                    pi.IsTemplate = istamplate;
                    pi.kelisheNum = klishenum;
                    pi.TemplateNum = templatenum;
                    pi.ColorCode1 = colorcode1;
                    pi.ColorCode2 = colorcode2;
                    pi.ColorCode3 = colorcode3;
                    pi.ColorCode4 = colorcode4;
                    pi.ColorCode5 = colorcode5;
                    db.PrintInfoes.Add(pi);
                    db.SaveChanges();
                    flag = true;
                }
                return Json(new { isok = flag });
            }
        }
        #endregion
        #region Load EditData
        //public JsonResult LoadforeditPI(int id)
        //{
        //    PrintInfo pi = new PrintInfo();
        //    using (ParandCartondbEntities db = new ParandCartondbEntities())
        //    {
        //        pi = db.PrintInfoes.Where(w => w.Id == id).SingleOrDefault();
        //    }
        //    bool isklishe = false;
        //    bool istemplate = false;
        //    if (pi.TemplateNum != "")
        //    {
        //        istemplate = true;
        //    }
        //    if (pi.kelisheNum != "")
        //    {
        //        isklishe = true;
        //    }
        //    return Json(new
        //    {
        //        printtype = pi.PrintType,
        //        paintcount = pi.ColorCount,
        //        printamount = pi.PrintAmount,
        //        printtypeselection = strtolistforedit(pi.PrintTypeSelection)
        //        ,
        //        klishenum = pi.kelisheNum,
        //        templatenum = pi.TemplateNum,
        //        istemplate = istemplate,
        //        isklishe = isklishe
        //    });
        //}
        private List<string> strtolistforedit(string str)
        {
            if (str == null) return null;
            List<string> result = str.Split(' ').ToList();
            return result;
        }
        private string strprinttypeselection(List<string> converttostr)
        {
            if (converttostr == null) return "";
            string str = "";
            for (int i = 0; i < converttostr.Count; i++)
            {
                str += converttostr[i] + " ";
            }
            return str.Trim();
        }
        #endregion
        #region Dell PrintInformation
        public JsonResult DellPI(int id)
        {
            bool flag = false;
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                var PI = db.PrintInfoes.Where(w => w.Id == id).SingleOrDefault();
                db.PrintInfoes.Remove(PI);
                db.SaveChanges();
                flag = true;
            }
            return Json(new { isok = flag });
        }
        #endregion
        #endregion

        #region LogesticInformationPage
        #region load Main Page
        public ActionResult LogesticInformation()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                return PartialView("LogesticInformation");
            }
        }

        #endregion
        #region Save&Edit logesticInfo
        [HttpPost]
        public ActionResult SaveLI(bool layouttype, int columennumber, bool consumtype, int distance, bool deliverytype ,int producttime ,string submittype, List<string> ispalet, string humidity, bool useaddress, string adress2)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                bool flag = false;
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    LogesticInfo li = new LogesticInfo();
                    var user = Session["UserInfo"] as UserInfo;
                    var oi = db.OrderInfoes.Where(x => x.Whosave == user.Id).ToList().LastOrDefault();
                    var pi = db.PrintInfoes.Where(x => x.Whosave == user.Id).ToList().LastOrDefault();
                    li.WhoSave = Convert.ToInt32(user.Id);
                    li.OrderInfoId = oi.Id;
                    li.PrintInfoId = pi.Id;
                    li.LayoutType = layouttype;
                    li.LayoutCount = columennumber;
                    li.TypeOfUse = consumtype;
                    li.ProductDistance = distance;
                    li.DeliveryMethod = deliverytype;
                    li.AnbareshTime = producttime;
                    li.SendMethod = submittype;
                    li.LogesticTypeSelection = strprinttypeselection(ispalet);
                    li.Humidity = humidity;
                    li.UseAddress = useaddress;
                    li.OtherAddress = adress2;
                    db.LogesticInfoes.Add(li);
                    db.SaveChanges();
                    flag = true;
                }
                return Json(new { isok = flag });
            }

        }

        #endregion
        #region Dell logestic information
        public JsonResult dellLI(int id)
        {
            bool flag = false;
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                var li = db.LogesticInfoes.Where(w => w.Id == id).SingleOrDefault();
                db.LogesticInfoes.Remove(li);
                db.SaveChanges();
                flag = true;
            }
            return Json(new { isok = flag });
        }

        #endregion
        #region Load data for Edit
        //public JsonResult loadforeditLI(int id)
        //{
        //    LogesticInfo li = new LogesticInfo();
        //    using (ParandCartondbEntities db = new ParandCartondbEntities())
        //    {
        //        li = db.LogesticInfoes.Where(w => w.Id == id).SingleOrDefault();
        //    }
        //    return Json(new { layouttype = li.LayoutType, consumtype = li.ConsumType, deliverytype = li.DeliveryType, submittype = li.SubmitType, ispalet = strtolistforedit(li.IsPalet), humidity = li.Humidity, columennumber = li.LayoutCount, distance = li.ProductDistance, producttime = li.AnbareshTime, adress = li.Address, adress2 = li.OtherAddress });
        //}

        #endregion

        #endregion

        #region StandardPage
        public ActionResult StandardOption()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                return PartialView("StandardOption");
            }
        }

        #endregion

        #region ProductPage
        public ActionResult ProductInformatiom()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                ParandCartondbEntities sda = new ParandCartondbEntities();
                List<Layer> store = new List<Layer>();
                store = sda.Layers.ToList();

                return PartialView("ProductInformatiom", store);
            }
        }

        //private List<Layer> Available(List<Layer> data)
        //{
        //    List<Layer> result = new List<Layer>();
        //    foreach (var item in data)
        //    {
        //        if (item.IsAvailabe)
        //        {
        //            result.Add(item);
        //        }
        //    }
        //    return result;
        //}
        #endregion

        #region calculate BCT with ECT and get ECT with layer
        public JsonResult CalculateECT_BCT(bool type, string liner1, string float1, string liner2,  string float2, string roye, string floattype1, string floattype2, int CartonLength, int CartonWidth, int CartonHeight)
        {
            double cartonHeight = CartonHeight / 10;
            double cartonLength = CartonLength/ 10;
            double cartonWidth = CartonWidth / 10;
            List<int> liner = strconverttoint(type, liner1, liner2);
            List<int> floot = strconverttoint(type, float1, float2);
            List<string> floattype = converttolststr(type, floattype1, floattype2);
            ECTFormula formula = new ECTFormula();
            BCTFormula bct = new BCTFormula();
            List<double> data = formula.GetECT(type, Convert.ToInt32(roye), liner, floot, floattype, cartonWidth, cartonHeight);
            data[0] = Math.Ceiling(data[0]);
            double BCT = bct.GetBCTKGwithlayer(data[0], floattype, cartonWidth, cartonLength);
            BCT = Math.Ceiling(BCT);
            return Json(new { ECT = data[0], BCT = BCT, WasteRate = data[1] });
        }
        private List<int> strconverttoint(bool type, string data1, string data2)
        {
            if (type == false)
            {
                List<int> result = new List<int>();
                result.Add(Convert.ToInt32(data1));
                return result;
            }
            else
            {
                List<int> result = new List<int>();
                result.Add(Convert.ToInt32(data1));
                result.Add(Convert.ToInt32(data2));
                return result;
            }
        }
        private List<string> converttolststr(bool type, string data1, string data2)
        {
            if (type == false)
            {

                List<string> final = new List<string>();
                final.Add(data1);
                return final;
            }
            else
            {
                List<string> final = new List<string>();
                final.Add(data1);
                final.Add(data2);
                return final;
            }
        }
        #endregion

        #region calculate cost 
        public JsonResult CalculatePrice(bool type, int CartonLength, int CartonWidth, int CartonHeight, int cartoncount, List<int> liner, List<int> floot, List<string> floattype, int roye, int WasteRate)
        {
            double cartonlength = CartonLength / 10;
            double cartonWidth = CartonWidth / 10;
            double cartonHeight = CartonHeight / 10;
            OrderPriceFormula formula = new OrderPriceFormula();
            List<double> price = formula.price(type, cartoncount, roye, floot, liner, cartonWidth, cartonlength, cartonHeight, floattype , WasteRate);
            if (price[0] != 0 && price[1] != 0)
            {
                price[0] = Math.Ceiling(price[0]);
                price[1] = Math.Ceiling(price[1]);
            }
            return Json(price);
        }
        #endregion

        #region saveproduct
        [HttpPost]
        public ActionResult saveProductinfo(string mizanvaraghmasrafi, int lowbct, int WasteRate, string DeliverDate, bool layercount, List<int> layer, List<string> floattype, int ECT, int BCT)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    ProductInfo pri = new ProductInfo();
                    var user = Session["UserInfo"] as UserInfo;
                    var li = db.LogesticInfoes.Where(x => x.WhoSave == user.Id).ToList().LastOrDefault();
                    pri.LogesticInfoId = li.Id;
                    pri.Whosave = Convert.ToInt32(user.Id);
                    if (double.TryParse(mizanvaraghmasrafi,out double mvm))
                    {
                        pri.TheAmountOfSheetsUsedForEachCarton = Convert.ToDouble(mvm);
                    }
                    pri.MinimumBCT = lowbct;
                    pri.WasteRate = WasteRate;
                    pri.DeliverTime = DeliverDate;
                    pri.LayerCount = layercount;
                    if (layercount == false)
                    {
                        pri.Layer1 = layer[0];
                        pri.Layer2 = layer[1];
                        pri.FloatType1 = floattype[0];
                        pri.Layer3 = layer[2];
                    }
                    else
                    {
                        pri.Layer1 = layer[0];
                        pri.Layer2 = layer[1];
                        pri.FloatType1 = floattype[0];
                        pri.Layer3 = layer[2];
                        pri.Layer4 = layer[3];
                        pri.FloatType2 = floattype[1];
                        pri.Layer5 = layer[4];
                    }
                    pri.BCT = BCT;
                    pri.ECT = ECT;
                    db.ProductInfoes.Add(pri);
                    db.SaveChanges();
                }
            }
            return Json(true);
        }

        #endregion

        #region Form
        #region LoadForm
        public ActionResult form()
        {
            var userinfo = Session["UserInfo"] as UserInfo;
            if (userinfo == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                return View();
            }
        }
        #endregion
        #region SaveForm
        [HttpPost]
        public ActionResult SaveForm(string Description, string percprice, string allcprice, string malyat, string takhfif, string bigprice)
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                var user = Session["UserInfo"] as UserInfo;
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    PriceInfo pr = new PriceInfo();
                    var product = db.ProductInfoes.Where(w => w.Whosave == user.Id).ToList().LastOrDefault();
                    pr.costpervaragh = Convert.ToDouble(percprice);
                    pr.costofall = Convert.ToDouble(allcprice);
                    pr.malyat = Convert.ToDouble(malyat);
                    pr.takhfif = Convert.ToDouble(takhfif);
                    pr.sumofall = Convert.ToDouble(bigprice);
                    pr.Description = Description;
                    pr.whosave = Convert.ToInt32(user.Id);
                    pr.ProductInfoId = product.Id;
                    db.PriceInfoes.Add(pr);
                    db.SaveChanges();
                }
                return Json(true);
            }
        }
        #endregion
        #endregion

        #region bctcalculate
        [HttpPost]
        public JsonResult BCTcalculate(bool type ,double vazn, int ertefa, bool sardkhane, bool space, int fasale, int zamananbaresh, bool chideman, string rtobat, string tedadrang, string mizanchap, bool daste, bool havakesh)
        {
            double Ertefa = ertefa / 10;
            BCTFormula bct = new BCTFormula();
            double bctkg = bct.KgBCTcalculate(vazn, Ertefa, sardkhane, space, fasale, zamananbaresh, chideman, rtobat, tedadrang, mizanchap, daste, havakesh);
            double result = Math.Ceiling(bctkg);
            return Json(result);
        }
        //public JsonResult VBCTcalculate(bool type ,double sheettoal , double sheetarz ,double sheetweight)
        //{

        //}
        #endregion

        #region ResultPage
        public ActionResult ResultPage()
        {
            var userinfo = Session["UserInfo"] as UserInfo;
            if (userinfo == null)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            else
            {
                OrderInfo oi = new OrderInfo();
                using (ParandCartondbEntities db = new ParandCartondbEntities())
                {
                    oi = db.OrderInfoes.Where(w => w.Whosave == userinfo.Id).ToList().LastOrDefault();
                }
                ResultView fi = GetResultview(oi.Id);
                return View("ResultPage", fi);
            }
        }
        private string getcontenttypename(int x)
        {
            if (x == 1)
            {
                return "نوع اول";
            }
            else if (x == 2)
            {
                return "نوع دوم";
            }
            else
            {
                return "";
            }
        }
        #endregion
        private string getdatetime(int id)
        {
            if (id == 0)
            {
                return DateTime.Now.ToString();
            }
            else
            {
                var date = DateTimeExtensions.GregorianToJalali(DateTime.Now);
                return date;
            }
        }
        private ResultView GetResultview(int id)
        {
            ResultView fi = new ResultView();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                OrderInfo oi = db.OrderInfoes.Where(w=>w.Id== id).SingleOrDefault();
                CartonTechnicalInfo cti = db.CartonTechnicalInfoes.Where(w => w.OrderInfoId == id).SingleOrDefault();
                PrintInfo pri = db.PrintInfoes.Where(w => w.OrderInfoId == id).SingleOrDefault();
                LogesticInfo li = db.LogesticInfoes.Where(w => w.OrderInfoId == id).SingleOrDefault();
                ProductInfo pi = db.ProductInfoes.Where(w => w.LogesticInfoId == li.Id).SingleOrDefault();
                PriceInfo p = db.PriceInfoes.Where(w => w.ProductInfoId == pi.Id).ToList().LastOrDefault();
                fi.CreateDate = oi.CreateDate;
                fi.CustomerCode = oi.CustomerCode;
                fi.CustomerName = oi.CustomerName;
                fi.SaleExpertCode = oi.SaleExpertCode;
                fi.ProductCode = oi.ProductCode;
                fi.ProductName = oi.ProductName;
                fi.SaleExpertName = oi.SaleExpertName;
                fi.Address = oi.Address;
                fi.NationalCode = oi.NationalCode;
                fi.PostalCode = oi.PostalCode;
                fi.EnterPriceInterfaceName = oi.EnterPriceInterfaceName;
                fi.EnconomicCode = oi.EnconomicCode;
                fi.Tell = oi.Tell;
                fi.EnterPriceInterfaceTell = oi.EnterPriceInterfaceTell;
                fi.Email = oi.Email;
                fi.type = cti.type;
                fi.CartonType = cti.CartonType;
                fi.CartonCount = cti.CartonCount;
                fi.CartonLength = cti.CartonLength;
                fi.CartonWidth = cti.CartonWidth;
                fi.CartonHeight = cti.CartonHeight;
                fi.CartonWeight = cti.CartonWeight;
                fi.IsCold = cti.IsCold;
                fi.IsTemplate = cti.IsTemplate;
                fi.CartonEmpty = cti.CartonEmpty;
                fi.ConnectorType = cti.ConnectorType;
                fi.CartonInsideType = cti.CartonInsideType;
                fi.SheatCount = cti.SheatCount;
                fi.SheatLength = cti.SheatLength;
                fi.SheatWidth = cti.SheatWidth;
                fi.SheatType = cti.SheatType;
                fi.PrintType = pri.PrintType;
                fi.ColorCount = pri.ColorCount;
                fi.PrintTypeSelection = pri.PrintTypeSelection;
                fi.PrintAmount = pri.PrintAmount;
                fi.IsKelishe = pri.IsKelishe;
                fi.PrintIsTemplate = pri.IsTemplate;
                fi.kelisheNum = pri.kelisheNum;
                fi.TemplateNum = pri.TemplateNum;
                fi.LayoutType = li.LayoutType;
                fi.LayoutCount = li.LayoutCount;
                fi.TypeOfUse = li.TypeOfUse;
                fi.ProductDistance = li.ProductDistance;
                fi.DeliveryMethod = li.DeliveryMethod;
                fi.AnbareshTime = li.AnbareshTime;
                fi.SendMethod = li.SendMethod;
                fi.LogesticTypeSelection = li.LogesticTypeSelection;
                fi.Humidity = li.Humidity;
                fi.UseAddress = li.UseAddress;
                fi.OtherAddress = li.OtherAddress;
                fi.TheAmountOfSheetsUsedForEachCarton = pi.TheAmountOfSheetsUsedForEachCarton;
                fi.MinimumBCT = pi.MinimumBCT;
                fi.WasteRate = pi.WasteRate;
                fi.DeliverTime = pi.DeliverTime;
                fi.LayerCount = pi.LayerCount;
                fi.Layer1 = pi.Layer1;
                fi.Layer2 = pi.Layer2;
                fi.FloatType1 = pi.FloatType1;
                fi.Layer3 = pi.Layer3;
                fi.Layer4 = pi.Layer4;
                fi.FloatType2 = pi.FloatType2;
                fi.Layer5 = pi.Layer5;
                fi.BCT = pi.BCT;
                fi.ECT = pi.ECT;
                fi.costpervaragh = p.costpervaragh;
                fi.costofall = p.costofall;
                fi.malyat = p.malyat;
                fi.takhfif = p.takhfif;
                fi.sumofall = p.sumofall;
                fi.Description = p.Description;
                fi.OrderCode = oi.OrderCode;
            }
            return fi;
        }
        public ActionResult PdfPage(int id)
        {
            var data = GetResultview(id);
            return View("ResultPage",data);
        }
        public JsonResult onloaddata(int id)
        {
            var data = GetResultview(id);
            return Json(data);
        }
    }

}