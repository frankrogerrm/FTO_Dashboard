using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class VAdmPermissionsByObject
    {
        public string StateDesc { get; set; }
        public string PermissionName { get; set; }
        public string Schema { get; set; }
        public string ObjectName { get; set; }
        public string ObjectTypeCode { get; set; }
        public string ObjectType { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public DateTime PermissionAssignedDate { get; set; }
    }
}
