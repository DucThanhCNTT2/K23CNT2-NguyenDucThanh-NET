using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NdtLesson08Annotation.Models; // Đổi namespace nếu đã đổi tên dự án

namespace NdtLesson08Annotation.Controllers
{
    public class NdtAccountController : Controller
    {
        private static List<NdtAccount> ndtListAccount = new List<NdtAccount>()
        {
            new NdtAccount
                {
                    NdtId = 230022113,
                    NdtFullName = "Nguyễn Đức Thành",
                    NdtEmail = "dthann2005@gmail.com",
                    NdtPhone = "0367907165",
                    NdtAddress = "Lớp K23CNT2",
                    NdtAvatar = "ducthanh.jpg",
                    NdtBirthday = new DateTime(2005, 4, 3),
                    NdtGender = "Nam",
                    NdtPassword = "Dthanh03042005",
                    NdtFacebook = "https://facebook.com/deveduvn"
                },
            new NdtAccount
                {
                    NdtId = 2,
                    NdtFullName = "Trần Thị B",
                    NdtEmail = "tranthib@example.com",
                    NdtPhone = "0987654321",
                    NdtAddress = "456 Đường B, Quận 3, TP.HCM",
                    NdtAvatar = "avatar2.jpg",
                    NdtBirthday = new DateTime(1992, 8, 15),
                    NdtGender = "Nữ",
                    NdtPassword = "password2",
                    NdtFacebook = "https://facebook.com/tranthib"
                },
            new NdtAccount
                {
                    NdtId = 3,
                    NdtFullName = "Lê Văn C",
                    NdtEmail = "levanc@example.com",
                    NdtPhone = "0911222333",
                    NdtAddress = "789 Đường C, Quận 5, TP.HCM",
                    NdtAvatar = "avatar3.jpg",
                    NdtBirthday = new DateTime(1988, 12, 1),
                    NdtGender = "Nam",
                    NdtPassword = "password3",
                    NdtFacebook = "https://facebook.com/levanc"
                },
            new NdtAccount
                {
                    NdtId = 4,
                    NdtFullName = "Phạm Thị D",
                    NdtEmail = "phamthid@example.com",
                    NdtPhone = "0909876543",
                    NdtAddress = "321 Đường D, Quận 7, TP.HCM",
                    NdtAvatar = "avatar4.jpg",
                    NdtBirthday = new DateTime(1995, 3, 10),
                    NdtGender = "Nữ",
                    NdtPassword = "password4",
                    NdtFacebook = "https://facebook.com/phamthid"
                },
            new NdtAccount
                {
                    NdtId = 5,
                    NdtFullName = "Hoàng Văn E",
                    NdtEmail = "hoangvane@example.com",
                    NdtPhone = "0933444555",
                    NdtAddress = "654 Đường E, Quận 10, TP.HCM",
                    NdtAvatar = "avatar5.jpg",
                    NdtBirthday = new DateTime(1991, 7, 22),
                    NdtGender = "Nam",
                    NdtPassword = "password5",
                    NdtFacebook = "https://facebook.com/hoangvane"
                }
        };

        // GET: NdtAccountController
        public ActionResult NdtIndex()
        {
            return View(ndtListAccount);
        }

        // GET: NdtAccountController/NdtDetails/5
        public ActionResult NdtDetails(int id)
        {
            var ndtAccount = ndtListAccount.FirstOrDefault(x => x.NdtId == id);
            return View(ndtAccount);
        }

        // GET: NdtAccountController/NdtCreate
        public ActionResult NdtCreate()
        {
            var ndtAccount = new NdtAccount();
            return View(ndtAccount);
        }

        // POST: NdtAccountController/NdtCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NdtCreate(NdtAccount ndtModel)
        {
            try
            {
                //Thêm mới vào list
                ndtModel.NdtId = ndtListAccount.Max(x => x.NdtId) + 1; // Tự động tăng ID
                ndtListAccount.Add(ndtModel);
                return RedirectToAction(nameof(NdtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NdtAccountController/NdtEdit/5
        public ActionResult NdtEdit(int id)
        {
            var ndtAccount = ndtListAccount.FirstOrDefault(x => x.NdtId == id);
            return View(ndtAccount);
        }

        // POST: NdtAccountController/NdtEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NdtEdit(int id, NdtAccount ndtModel)
        {
            try
            {
                for (int i = 0; i < ndtListAccount.Count; i++)
                {
                    if (ndtListAccount[i].NdtId == id)
                    {
                        ndtListAccount[i] = ndtModel; // Cập nhật thông tin nhân viên
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

        // GET: NdtAccountController/NdtDelete/5
        public ActionResult NdtDelete(int id)
        {
            var emp = ndtListAccount.FirstOrDefault(x => x.NdtId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: NdtAccountController/NdtDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NdtDelete(int id, NdtAccount ndtModel)
        {
            var emp = ndtListAccount.FirstOrDefault(x => x.NdtId == id);
            if (emp != null) ndtListAccount.Remove(emp);
            return RedirectToAction(nameof(NdtIndex));
        }
    }
}
