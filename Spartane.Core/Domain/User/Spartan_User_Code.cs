using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.User
{
    public class RoleSpartanUserRole
    {
        public int User_Role_Id { get; set; }
        public string Description { get; set; }
        public object Status { get; set; }
        public object Status_Spartan_User_Role_Status { get; set; }
        public int Id { get; set; }
    }

    public class ImageSpartanFile
    {
        public int File_Id { get; set; }
        public object Description { get; set; }
        public object File1 { get; set; }
        public object File_Size { get; set; }
        public object Object { get; set; }
        public object User_Id { get; set; }
        public object Date_Time { get; set; }
        public object File1_TTArchivos { get; set; }
        public int Id { get; set; }
    }

    public class StatusSpartanUserStatus
    {
        public int User_Status_Id { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }

    public class SpartanUser
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public object Image { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleSpartanUserRole Role_Spartan_User_Role { get; set; }
        public ImageSpartanFile Image_Spartan_File { get; set; }
        public StatusSpartanUserStatus Status_Spartan_User_Status { get; set; }
        public int Id { get; set; }
    }

    public class Spartan_User_Core
    {
        public IList<SpartanUser> Spartan_Users { get; set; }
        public int RowCount { get; set; }
    }

}
