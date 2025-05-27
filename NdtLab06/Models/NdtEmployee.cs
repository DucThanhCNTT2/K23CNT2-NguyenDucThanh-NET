namespace NdtLab06.Models
{
    public class NdtEmployee
    {
        public int NdtId { get; set; }                 //Mã nhân viên
        public String NdtName { get; set; }            //Họ tên
        public DateTime NdtBirthDay { get; set; }        //Ngày sinh
        public String NdtEmail { get; set; }           //Email
        public String NdtPhone { get; set; }           //Điện thoại
        public decimal NdtSalary { get; set; }          //Lương
        public bool NdtStatus { get; set; }         //Trạng thái (true = dang làm việc, false = nghỉ việc)
    }
}
