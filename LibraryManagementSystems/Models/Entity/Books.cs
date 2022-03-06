//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagementSystems.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Activities = new HashSet<Activities>();
        }
    
        public int Id { get; set; }
        public string BookName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public string PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string Page { get; set; }
        public Nullable<bool> Status { get; set; }
        public string BookFoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activities> Activities { get; set; }
        public virtual Authors Authors { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
