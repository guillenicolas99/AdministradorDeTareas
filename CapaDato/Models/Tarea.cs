//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDato.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarea()
        {
            this.Comentarios = new HashSet<Comentario>();
        }
    
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaEstimadaEntrega { get; set; }
        public int PrioridadId { get; set; }
        public int EstadoId { get; set; }
        public int CategoriaId { get; set; }
        public int UsuarioPropietarioId { get; set; }
        public int UsuarioAsignadoId { get; set; }
    
        public virtual Prioridad Prioridad { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual Usuario UsuarioPropietario { get; set; }
        public virtual Usuario UsuarioAsignado { get; set; }
    }
}