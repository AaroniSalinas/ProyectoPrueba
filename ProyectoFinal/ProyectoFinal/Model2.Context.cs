﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BaseDatosWebEntities6 : DbContext
    {
        public BaseDatosWebEntities6()
            : base("name=BaseDatosWebEntities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<carrito> carritoes { get; set; }
        public virtual DbSet<categoria> categorias { get; set; }
        public virtual DbSet<orden> ordens { get; set; }
        public virtual DbSet<pedido> pedidos { get; set; }
        public virtual DbSet<producto> productoes { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<subcategoria> subcategorias { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
    
        public virtual int addProduct(string nombre, Nullable<double> precio, Nullable<int> cantidad, Nullable<int> idCategoria, string categoria, Nullable<int> idSubcategoria, string subcategoria)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(double));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            var categoriaParameter = categoria != null ?
                new ObjectParameter("categoria", categoria) :
                new ObjectParameter("categoria", typeof(string));
    
            var idSubcategoriaParameter = idSubcategoria.HasValue ?
                new ObjectParameter("idSubcategoria", idSubcategoria) :
                new ObjectParameter("idSubcategoria", typeof(int));
    
            var subcategoriaParameter = subcategoria != null ?
                new ObjectParameter("subcategoria", subcategoria) :
                new ObjectParameter("subcategoria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addProduct", nombreParameter, precioParameter, cantidadParameter, idCategoriaParameter, categoriaParameter, idSubcategoriaParameter, subcategoriaParameter);
        }
    
        public virtual int agregarProductoOrden(Nullable<int> productoId, Nullable<int> ordenId, Nullable<int> cantidad, Nullable<int> usuarioId)
        {
            var productoIdParameter = productoId.HasValue ?
                new ObjectParameter("productoId", productoId) :
                new ObjectParameter("productoId", typeof(int));
    
            var ordenIdParameter = ordenId.HasValue ?
                new ObjectParameter("ordenId", ordenId) :
                new ObjectParameter("ordenId", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            var usuarioIdParameter = usuarioId.HasValue ?
                new ObjectParameter("usuarioId", usuarioId) :
                new ObjectParameter("usuarioId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("agregarProductoOrden", productoIdParameter, ordenIdParameter, cantidadParameter, usuarioIdParameter);
        }
    
        public virtual int createSignUp(string correo, string nombre, string apellido, Nullable<int> telefono, string contraseña)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("contraseña", contraseña) :
                new ObjectParameter("contraseña", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createSignUp", correoParameter, nombreParameter, apellidoParameter, telefonoParameter, contraseñaParameter);
        }
    }
}
