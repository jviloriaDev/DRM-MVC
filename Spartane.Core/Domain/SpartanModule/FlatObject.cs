using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartanModule
{
    public class FlatObject
    {
        public Int64 Id { get; set; }
        public Int64 ParentId { get; set; }
        public string data { get; set; }
        public int Order_Shown { get; set; }
        public int? Image { set; get; }

        //public List<int> DisplayModule {get;set;}


        public FlatObject(string name, Int64 id, Int64 parentId, int origOrder)
        {
            data = name;
            Id = id;
            ParentId = parentId;
            Order_Shown = origOrder;

        }
        public FlatObject(string name, Int64 id, Int64 parentId, int origOrder, int? imageId)
        {
            data = name;
            Id = id;
            ParentId = parentId;
            Order_Shown = origOrder;
            Image = imageId;

        }

    }

    public class RecursiveInnerObject
    {
        public object Image_Spartan_File { get; set; }
        public object Object_Type_Spartan_Object_Type { get; set; }
        public object Status_Spartan_Object_Status { get; set; }
        public int Object_Id { get; set; }
        public string Name { get; set; }
        public Byte[] Image { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int Object_Type { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
    }

    public class RecursiveObject
    {
        public string text { get; set; }
        public Int64 id { get; set; }
        public FlatTreeAttribute state { get; set; }
        public List<RecursiveObject> children { get; set; }
        public int originalOrder { get; set; }
        public int moduleOrder { get; set; }
        public byte[] Image { get; set; }
        public List<RecursiveInnerObject> Objects { set; get; }
        public List<RecursiveObject> AdditionalMenu { get; set; }
        public string Link { get; set; }

        public RecursiveObject()
        {
            this.Objects = new List<RecursiveInnerObject>();
            this.children = new List<RecursiveObject>();
            this.AdditionalMenu = new List<RecursiveObject>();
        }
    }

    public class FlatTreeAttribute
    {
        public bool opened;
        public bool selected;
        public bool check;
    }

}
