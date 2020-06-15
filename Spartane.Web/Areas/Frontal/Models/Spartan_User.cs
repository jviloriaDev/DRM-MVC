using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Models
{
    public partial class Spartan_User
    {
        public Spartan_User()
        {
            this.Most_Used_Object = new HashSet<Spartan_User_Most_Used_Object>();
            this.Quicklinks = new HashSet<Spartan_User_Quicklink>();
            this.Files = new HashSet<Spartan_File>();
            this.Favorite_Obects = new HashSet<Spartan_User_Favorite_Object>();
            this.Alerts = new HashSet<Spartan_User_Alert>();
            this.Favorite_List = new HashSet<Spartan_User_Favorite_List>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        //public int Role { get; set; }
        //public int Image { get; set; }
        public string Email { get; set; }
        //public int Status { get; set; }

        public Spartan_User_Status Status { get; set; }
        public Spartan_Object Image { get; set; }
        public Spartan_User_Role Role {get;set;}

        public virtual ICollection<Spartan_User_Most_Used_Object> Most_Used_Object {get;set;}
        public virtual ICollection<Spartan_User_Quicklink> Quicklinks { get; set; }
        public virtual ICollection<Spartan_File> Files { get; set; }
        public virtual ICollection<Spartan_User_Favorite_Object> Favorite_Obects { get; set; }
        public virtual ICollection<Spartan_User_Alert> Alerts { get; set; }
        public virtual ICollection<Spartan_User_Favorite_List> Favorite_List { get; set; }

    }

    public partial class Spartan_User_Role
    {
        public int User_RoleId { get; set; }
        public string Description { get; set; }
        //public int Status { get; set; }

        public Spartan_User_Role_Status Status { get; set; }
    }

    public partial class Spartan_File
    {
        public int FileId { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public int FileSize { get; set; }
        //public int Object { get; set; }
        public int User { get; set; }
        public DateTime Datetime { get; set; }

        public virtual Spartan_Object Object { get; set; }

    }

    public partial class Spartan_User_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_User_Role_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_Object
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        //public int Status { get; set; }
        //public int Image { get; set; }
        public string URL { get; set; }

        public virtual Spartan_Object_Status Status { get; set; }
        public virtual Spartan_File Image { get; set; }

    }

    public partial class Spartan_Object_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_System { 
        
        public int SystemId { get; set; }
        public string Version { get; set; }
        //public int SystemImage { get; set; }
        //public int CustomerImage { get; set; }
        //public int DeveloperImage { get; set; }

        public virtual Spartan_File SystemImage { get; set; }
        public virtual Spartan_File CustomerImage { get; set; }
        public virtual Spartan_File DeveloperImage { get; set; }
    }

    public partial class Spartan_User_Favorite_Object {
        public int Favorite_ObjectId { get; set; }
        public int User { get; set; }
        //public int Object { get; set; }
        public int Order_Shown { get; set; }

        public Spartan_Object Object { get; set; }
    }

    public partial class Spartan_User_Alert {
        public int User_AlertId { get; set; }
        public int User { get; set; }
        //public int Alert_Type { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        //public int Status { get; set; }

        public virtual Spartan_User_Alert_Type Alert_Type { get; set; }
        public virtual Spartan_User_Alert_Status Status { get; set; }
    }

    public partial class Spartan_User_Alert_Status {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_User_Alert_Type {
        public int Id { get; set; }
        public string Description { get; set; }
        //public int Image { get; set; }

        public virtual Spartan_File Image { get; set; }
    }

    public partial class Spartan_Notice {
        public int NoticeId { get; set; }
        public string Description { get; set; }
        //public int Notice_Type { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        //public int Status { get; set; }

        public virtual Spartan_Notice_Status Status { get; set; }
        public virtual Spartan_Notice_Status Notice_Type { get; set; }
    }

    public partial class Spartan_Notice_Status {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_Notice_Type
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_User_Most_Used_Object {

        public int Most_Used_ObjectId { get; set; }
        public int User { get; set; }
        //public int Object { get; set; }
        public int Order_Shown { get; set; }

        public virtual Spartan_Object Object { get; set; }
    }

    public partial class Spartan_User_Favorite_List { 
        public int Favorite_ListId { get; set; }
        public int User { get; set; }
        //public int Object { get; set; }
        public int Order_Shown { get; set; }

        public virtual Spartan_Object Object { get; set; }
    }

    public partial class Spartan_User_Quicklink {
        public int Quicklink { get; set; }
        public int User { get; set; }
        //public int Object { get; set; }
        public int Order_Shown { get; set; }
        //public int Method_Type { get; set; }
        public string Description { get; set; }
        public int AtributeId { get; set; }
        //public int Control_Type { get; set; }

        public virtual Spartan_Control_Type Control_Type { get; set; }
        public virtual Spartan_Method_Type Method_Type { get; set; }
        public virtual Spartan_Object Object { get; set; }
    }

    public partial class Spartan_Method_Type {
        public int Method_TypeId { get; set; }
        public string Description { get; set; }
    }

    public partial class Spartan_Control_Type {
        public int Favorite_ListId { get; set; }
        public int User { get; set; }
        //public int Object { get; set; }
        public int Order_Shown { get; set; }

        public virtual Spartan_Object Object { get; set; }
    }

    public partial class Spartan_System_Language {
        public int System_LanguageId { get; set; }
        public string ResourceId { get; set; }
    }

}