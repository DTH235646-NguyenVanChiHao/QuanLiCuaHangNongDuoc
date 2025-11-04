using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    internal class DBConnection
    {
        private string connectionString;
       
        public DBConnection() {
            //Kết nối csdl của từng thành viên
            string datasource_ChiHao = "ADMIN-PC\\SQLEXPRESS";
<<<<<<< HEAD
            string datasource_HieuHau = "DESKTOP-33RD74C\\SQLEXPRESS";
            string datasource_PhuocHao;
=======
            string datasource_HieuHau;
            string datasource_PhuocHao ;
>>>>>>> eb13b2bec56e8c0c348f1b8ebc0c0ce6af354343

            string tenDatabase_ChiHao = "QuanLiCuaHangNongDuoc";
            //Khởi tạo chuỗi dùng để kết nối CSDL
<<<<<<< HEAD
            connectionString = $"Data Source={datasource_HieuHau};Initial Catalog=TenDatabase;Integrated Security=True";
            this.GetConnection();   
=======
            this.connectionString = $"Data Source={datasource_ChiHao};Initial Catalog={tenDatabase_ChiHao};Integrated Security=True";

>>>>>>> eb13b2bec56e8c0c348f1b8ebc0c0ce6af354343
        }

        public SqlConnection GetConnection()
        {
            //Kết nối với csdl và trả về một biến là gọi là cn - hay connection 
            return new SqlConnection(this.connectionString);
          
        }


            //Lí do nên dùng using
            //using giúp tự động giải phóng tài nguyên khi bạn dùng xong một đối tượng,
            //                         mà không cần viết thêm code để đóng nó thủ công.
            //============================Các hàm truy xuất dữ liệu


            // Hàm lấy hình ảnh nhân viên => hiển thị lên sau khi đăng nhập
       
    }
}
