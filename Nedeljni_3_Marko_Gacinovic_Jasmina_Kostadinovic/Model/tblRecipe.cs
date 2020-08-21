//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_3_Marko_Gacinovic_Jasmina_Kostadinovic.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRecipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRecipe()
        {
            this.tblIngredients = new HashSet<tblIngredient>();
            this.tblShoppingLists = new HashSet<tblShoppingList>();
        }
    
        public int RecipeID { get; set; }
        public Nullable<int> UserDataID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> PersonsCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIngredient> tblIngredients { get; set; }
        public virtual tblUserData tblUserData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblShoppingList> tblShoppingLists { get; set; }
    }
}
