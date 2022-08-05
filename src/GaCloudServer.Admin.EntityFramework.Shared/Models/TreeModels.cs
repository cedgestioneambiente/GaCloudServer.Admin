using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Models
{
    public class TreeViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<TreeViewModel> childrens { get; set; }
    }

    public class TreeUpdateModel
    {
        public long id { get; set; }
        public int nodeId { get; set; }
        public string nodeDesc { get; set; }
    }

    public class TreeFlatNodeModel
    {
        public bool Expandable { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public string Id { get; set; }
        public string ParentNodeId { get; set; }
    }

    public partial class ItemTreeModel
    {
        private Guid _guid = Guid.NewGuid();
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public bool IsPage { get; set; }
        public int Order { get; set; }
        public Guid Guid { get { return _guid; } set { _guid = value; } }

    }

    public partial class ItemTreeModel
    {
        public List<ItemTreeModel> Childrens { get; set; }
    }
}
