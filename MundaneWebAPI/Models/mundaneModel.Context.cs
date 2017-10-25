﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MundaneWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class mundanedbEntities : DbContext
    {
        public mundanedbEntities()
            : base("name=mundanedbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Items> Items { get; set; }
    
        public virtual ObjectResult<GetAllItems_Result> GetAllItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllItems_Result>("GetAllItems");
        }
    
        public virtual ObjectResult<GenerateLoot_Result> GenerateLoot(Nullable<int> numResults, Nullable<bool> bEnableMagicalItems)
        {
            var numResultsParameter = numResults.HasValue ?
                new ObjectParameter("NumResults", numResults) :
                new ObjectParameter("NumResults", typeof(int));
    
            var bEnableMagicalItemsParameter = bEnableMagicalItems.HasValue ?
                new ObjectParameter("bEnableMagicalItems", bEnableMagicalItems) :
                new ObjectParameter("bEnableMagicalItems", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GenerateLoot_Result>("GenerateLoot", numResultsParameter, bEnableMagicalItemsParameter);
        }
    }
}
