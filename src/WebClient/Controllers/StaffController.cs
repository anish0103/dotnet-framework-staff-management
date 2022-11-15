using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Wrapper;
using WebModel;

namespace WebClient.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public PartialViewResult StaffList()
        {
            return PartialView("_StaffList");
        }

        public PartialViewResult StaffDetails(int id = 0)
        {
            using (ConsumeAPI<Staff> consumeAPI = new ConsumeAPI<Staff>())
            {
                if (id == 0)
                {
                    Staff staff = new Staff();
                    return PartialView("_StaffDetails", staff);
                }
                else
                {
                    Staff staff = consumeAPI.generaticReadAsAsync("Staff/" + id);
                    return PartialView("_StaffDetails", staff);
                }
            }

        }

        public JsonResult GetStaffList()
        {
            using (ConsumeAPI<Staff> consumeAPI = new ConsumeAPI<Staff>())
            {
                IEnumerable<Staff> staffs = consumeAPI.generaticReadAsAsyncs("Staff");
                if (staffs == null) return Json("Not OK");
                return Json(staffs);
            }
        }

        public JsonResult DeleteRecord(int id)
        {
            using (ConsumeAPI<Staff> consumeAPI = new ConsumeAPI<Staff>())
            {
                Staff staff = consumeAPI.generaticDeleteAsync("Staff/"+ id);
                if (staff == null) return Json("Not OK");
                return Json("OK");
            }
        }

        public JsonResult InsertRecord(Staff staffObj)
        {
            using (ConsumeAPI<Staff> consumeAPI = new ConsumeAPI<Staff>())
            {
                Staff staff = consumeAPI.generaticPostAsJsonAsync("Staff", staffObj);
                if (staff == null) return Json("Not OK");
                return Json("OK");
            }
        }

        public JsonResult UpdateRecord(Staff staffObj, int id)
        {
            using (ConsumeAPI<Staff> consumeAPI = new ConsumeAPI<Staff>())
            {
                staffObj.id = id;
                Staff staff = consumeAPI.generaticPutAsJsonAsync("Staff", staffObj);
                if (staff == null) return Json("Not OK");
                return Json("OK");
            }
        }

    }
}