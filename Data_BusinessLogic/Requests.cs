//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_BusinessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requests()
        {
            this.Comments = new HashSet<Comments>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public string problemDescryption { get; set; }
        public Nullable<System.DateTime> completionDate { get; set; }
        public Nullable<int> homeTechType { get; set; }
        public Nullable<int> homeTechModel { get; set; }
        public Nullable<int> repairParts { get; set; }
        public Nullable<int> clientID { get; set; }
        public Nullable<int> masterID { get; set; }
        public Nullable<int> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual HomeTechModel HomeTechModel1 { get; set; }
        public virtual HomeTechType HomeTechType1 { get; set; }
        public virtual RepairParts RepairParts1 { get; set; }
        public virtual ReqStatusType ReqStatusType { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
