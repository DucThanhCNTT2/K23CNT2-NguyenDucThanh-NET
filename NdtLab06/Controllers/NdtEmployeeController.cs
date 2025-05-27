using Microsoft.AspNetCore.Mvc;
using NdtLab06.Models;

namespace NdtLab06.Controllers
{
    public class NdtEmployeeController : Controller
    {
        private static List<NdtEmployee> ndtListEmployee = new List<NdtEmployee>
{
    new NdtEmployee {
        NdtId = 1,
        NdtName = "Nguyễn Đức Thành",
        NdtBirthDay = new DateTime(2005, 4, 3),
        NdtEmail = "dthanh2005@gmail.com",
        NdtPhone = "0912345678",
        NdtSalary = 1000,
        NdtStatus = true
    },
    new NdtEmployee {
        NdtId = 2,
        NdtName = "Trần Thị B",
        NdtBirthDay = new DateTime(1992, 5, 12),
        NdtEmail = "b.tran@example.com",
        NdtPhone = "0987654321",
        NdtSalary = 1200,
        NdtStatus = true
    },
    new NdtEmployee {
        NdtId = 3,
        NdtName = "Lê Văn C",
        NdtBirthDay = new DateTime(1985, 8, 22),
        NdtEmail = "c.le@example.com",
        NdtPhone = "0933123123",
        NdtSalary = 900,
        NdtStatus = false
    },
    new NdtEmployee {
        NdtId = 4,
        NdtName = "Phạm Thị D",
        NdtBirthDay = new DateTime(1998, 3, 10),
        NdtEmail = "d.pham@example.com",
        NdtPhone = "0909090909",
        NdtSalary = 1100,
        NdtStatus = true
    },
    new NdtEmployee {
        NdtId = 5,
        NdtName = "Đỗ Văn E",
        NdtBirthDay = new DateTime(1995, 7, 30),
        NdtEmail = "e.do@example.com",
        NdtPhone = "0966666666",
        NdtSalary = 1050,
        NdtStatus = false
    }
};
        public IActionResult NdtIndex()
        {
            return View(ndtListEmployee);
        }

        //Thêm mới; Action GET: /NdtEmployee/NdtCrete
        public IActionResult NdtCreate() 
        { 
            return View(); 
        }

        //POST: /NdtEmployee/NdtCrete
        [HttpPost]
        public IActionResult NdtCreate(NdtEmployee emp)
        {
            // Gán ID tự động (tăng tiếp theo)
            emp.NdtId = ndtListEmployee.Count > 0 ? ndtListEmployee.Max(e => e.NdtId) + 1 : 1;

            // Thêm nhân viên vào danh sách
            ndtListEmployee.Add(emp);

            // Chuyển về trang danh sách
            return RedirectToAction("NdtIndex");
        }

        //Sửa; Action GET: /NdtEmployee/NdtEdit
        [HttpGet]
        public IActionResult NdtEdit(int id)
        {
            var emp = ndtListEmployee.FirstOrDefault(e => e.NdtId == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        //POST: /NdtEmployee/NdtEdit
        [HttpPost]
        public IActionResult NdtEdit(NdtEmployee updatedEmp)
        {
            var emp = ndtListEmployee.FirstOrDefault(e => e.NdtId == updatedEmp.NdtId);
            if (emp != null)
            {
                emp.NdtName = updatedEmp.NdtName;
                emp.NdtBirthDay = updatedEmp.NdtBirthDay;
                emp.NdtEmail = updatedEmp.NdtEmail;
                emp.NdtPhone = updatedEmp.NdtPhone;
                emp.NdtSalary = updatedEmp.NdtSalary;
                emp.NdtStatus = updatedEmp.NdtStatus;
            }

            return RedirectToAction("NdtIndex");
        }


        //Xóa; ACTION: NdtDelete (GET + POST)
        [HttpGet]
        public IActionResult NdtDelete(int id)
        {
            var emp = ndtListEmployee.FirstOrDefault(e => e.NdtId == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        //POST: /NdtEmployee/NdtDelete
        [HttpPost, ActionName("NdtDelete")]
        public IActionResult NdtDeleteConfirmed(int id)
        {
            var emp = ndtListEmployee.FirstOrDefault(e => e.NdtId == id);
            if (emp != null)
            {
                ndtListEmployee.Remove(emp);
            }

            return RedirectToAction("NdtIndex");
        }

    };
    
}

