//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FLOWER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLOWER()
        {
            this.CHARACTERISTICs = new HashSet<CHARACTERISTIC>();
        }
    
        public int FLOWER_ID { get; set; }
        public string FLOWER_NAME { get; set; }
        public int COLOR_ID { get; set; }
        public string FLOWER_SIZE { get; set; }
        public Nullable<int> FLOWER_PRICE { get; set; }
    
        public virtual COLOR COLOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHARACTERISTIC> CHARACTERISTICs { get; set; }

        public string convertToNormalName(string flowerName)
        {
            string newString = flowerName.ToLower();
            newString = newString.Replace("_", " ");

            return newString;
        }
    }
}
