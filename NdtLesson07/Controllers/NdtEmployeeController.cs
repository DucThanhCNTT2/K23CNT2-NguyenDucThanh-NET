using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NdtLesson07.Models;

namespace NdtLesson07.Controllers
{
    public class NdtEmployeeController : Controller
    {
        //Mock Data:
        private static List<NdtEmployee> ndtListEmployee = new List<NdtEmployee>()
        {
            new NdtEmployee
            {
                NdtId = 231090098,
                NdtName = "Nguyễn Đức Thành",
                NdtBirthDay = new DateTime(2005, 4, 3),
                NdtEmail = "dhann2005@gmail.com",
                NdtPhone = "0367907165",
                NdtSalary = 15000000,
                NdtStatus = true
            },
            new NdtEmployee
            {
                NdtId = 2,
                NdtName = "Trần Thị B",
                NdtBirthDay = new DateTime(1992, 8, 14),
                NdtEmail = "tranthib@example.com",
                NdtPhone = "0911222333",
                NdtSalary = 17000000,
                NdtStatus = true
            },
            new NdtEmployee
            {
                NdtId = 3,
                NdtName = "Lê Văn C",
                NdtBirthDay = new DateTime(1987, 12, 2),
                NdtEmail = "levanc@example.com",
                NdtPhone = "0933444555",
                NdtSalary = 16000000,
                NdtStatus = false
            },
            new NdtEmployee
            {
                NdtId = 4,
                NdtName = "Phạm Thị D",
                NdtBirthDay = new DateTime(1995, 4, 30),
                NdtEmail = "phamthid@example.com",
                NdtPhone = "0977666888",
                NdtSalary = 20000000,
                NdtStatus = true
            },
            new NdtEmployee
            {
                NdtId = 5,
                NdtName = "Hoàng Văn E",
                NdtBirthDay = new DateTime(1993, 9, 17),
                NdtEmail = "hoangvane@example.com",
                NdtPhone = "0909998888",
                NdtSalary = 15500000,
                NdtStatus = false
            }
        };
        // GET: NdtEmployeeController
        public ActionResult NdtIndex()
        {
            return View(ndtListEmployee);
        }

        // GET: NdtEmployeeController/Details/5
        public ActionResult NdtDetails(int id)
        {
            var ndtEmployee = ndtListEmployee.FirstOrDefault(x => x.NdtId == id);
            return View(ndtEmployee);
        }

        // GET: NdtEmployeeController/NdtCreate
        public ActionResult NdtCreate()
        {
            var ndtEmployee = new NdtEmployee();
            return View(ndtEmployee);
        }

        // POST: NdtEmployeeController/NdtCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NdtCreate(NdtEmployee ndtModel)
        {
            try
            {
                //Thêm mới vào list
                ndtModel.NdtId = ndtListEmployee.Max(x => x.NdtId) + 1; // Tự động tăng ID
                ndtListEmployee.Add(ndtModel);
                return RedirectToAction(nameof(NdtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NdtEmployeeController/NdtEdit/5
        public ActionResult NdtEdit(int id)
        {
            var ndtEmployee = ndtListEmployee.FirstOrDefault(x => x.NdtId == id);
            return View(ndtEmployee);
        }

        // POST: NdtEmployeeController/NdtEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NdtEdit(int id, NdtEmployee ndtModel)
        {
            try
            {
                for (int i = 0; i < ndtListEmployee.Count; i++)
                {
                    if (ndtListEmployee[i].NdtId == id)
                    {
                        ndtListEmployee[i] = ndtModel; // Cập nhật thông tin nhân viên
                        break;
                    }
                }
                return RedirectToAction(nameof(NdtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NdtEmployeeController/NdtDelete/5
        public ActionResult NdtDelete(int id)
        {
            var emp = ndtListEmployee.FirstOrDefault(x => x.NdtId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: NdtEmployeeController/NdtDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NdtDelete(int id, NdtEmployee ndtModel)
        {
            var emp = ndtListEmployee.FirstOrDefault(x => x.NdtId == id);
            if (emp != null) ndtListEmployee.Remove(emp);
            return RedirectToAction(nameof(NdtIndex));
        }
    }
}
