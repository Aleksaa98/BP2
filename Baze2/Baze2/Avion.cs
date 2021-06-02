//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baze2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Avion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avion()
        {
            this.Upravljas = new HashSet<Upravlja>();
            this.Izvrsavas = new HashSet<Izvrsava>();
            this.Posedujes = new HashSet<Poseduje>();
        }
    
        public int Id { get; set; }
        public string BrojMesta { get; set; }
        public int AerodromId { get; set; }
        public int CentralaId { get; set; }
        public string Naziv { get; set; }
    
        public virtual Aerodrom Aerodrom { get; set; }
        public virtual Centrala Centrala { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Upravlja> Upravljas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Izvrsava> Izvrsavas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poseduje> Posedujes { get; set; }
    }
}