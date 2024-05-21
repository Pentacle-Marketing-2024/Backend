using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class FormRequest
    {
        [Required (ErrorMessage = "Vui lòng điền email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng điền họ và tên.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn cách mà bạn biết đến Pentacle Marketing.")]
        public string Method { get; set; }

        [Required(ErrorMessage = "Vui lòng điền thông tin mô tả về dự án của doanh nghiệp.")]
        public string Description { get; set; }
    }
}
