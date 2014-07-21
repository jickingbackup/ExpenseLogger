using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAL;
using Models;
using AutoMapper;
using DataAccess.EFModels;
using System.Data.Entity.Infrastructure;
namespace DataAccess
{

    #region Original implementation
    //internal class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    //{
    //    internal ExpenseLoggerContext context;
    //    internal DbSet<TEntity> dbSet;

    //    static GenericRepository()
    //    {
    //        Mapper.CreateMap<CompanyModel, Company>();
    //        Mapper.CreateMap<ProductModel, Product>();
    //        Mapper.CreateMap<ExpenseRecordModel, ExpenseRecord>();

    //        Mapper.CreateMap< Company,CompanyModel>();
    //        Mapper.CreateMap<Product,ProductModel>();
    //        Mapper.CreateMap< ExpenseRecord, ExpenseRecordModel>();
    //    }

    //    public GenericRepository(ExpenseLoggerContext context)
    //    {
    //        this.context = context;
    //        this.dbSet = context.Set<TEntity>();
    //    }

    //    //public virtual IEnumerable<TEntity> Get(
    //    //    Expression<Func<TEntity, bool>> filter = null,
    //    //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    //    //    string includeProperties = "")
    //    //{
    //    //    IQueryable<TEntity> query = dbSet;

    //    //    if (filter != null)
    //    //    {
    //    //        query = query.Where(filter);
    //    //    }

    //    //    foreach (var includeProperty in includeProperties.Split
    //    //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
    //    //    {
    //    //        query = query.Include(includeProperty);
    //    //    }

    //    //    if (orderBy != null)
    //    //    {
    //    //        return orderBy(query).ToList();
    //    //    }
    //    //    else
    //    //    {
    //    //        return query.ToList();
    //    //    }
    //    //}

    //    public virtual IList<TEntity> Get()
    //    {
    //        IQueryable<TEntity> query = dbSet;
    //        return query.ToList();
    //    }

    //    public virtual TEntity GetByID(object id)
    //    {
    //        return dbSet.Find(id);
    //    }

    //    public virtual void Insert(TEntity entity)
    //    {
    //        dbSet.Add(entity);
    //    }

    //    public virtual void Delete(object id)
    //    {
    //        TEntity entityToDelete = dbSet.Find(id);
    //        Delete(entityToDelete);
    //    }

    //    public virtual void Delete(TEntity entityToDelete)
    //    {

    //        if (context.Entry(entityToDelete).State == EntityState.Detached)
    //        {
    //            dbSet.Attach(entityToDelete);
    //        }
    //        dbSet.Remove(entityToDelete);
    //    }

    //    public virtual void Update(TEntity entityToUpdate)
    //    {
    //        dbSet.Attach(entityToUpdate);
    //        context.Entry(entityToUpdate).State = EntityState.Modified;
    //    }
    //}

    ///// <summary>
    ///// Handles crud operation for Product.
    ///// </summary>
    //internal class ProductRepository : GenericRepository<Product>
    //{
    //    public ProductRepository(ExpenseLoggerContext context)
    //        : base(context)
    //    {
    //    }

    //    /// <summary>
    //    /// Updates a given entity on db.
    //    /// </summary>
    //    /// <param name="entityToUpdate"></param>
    //    public override void Update(Product entityToUpdate)
    //    {
    //        var product = this.GetByID(entityToUpdate.Id);
    //        product.Name = entityToUpdate.Name;
    //        product.Description = entityToUpdate.Description;
    //        product.CompanyId = entityToUpdate.CompanyId;
    //        //base.Update(entityToUpdate);
    //    }

    //    /// <summary>
    //    /// Removes a given entity from db.
    //    /// </summary>
    //    /// <param name="entityToDelete"></param>
    //    public override void Delete(Product entityToDelete)
    //    {
    //        var product = this.GetByID(entityToDelete.Id);
    //        dbSet.Remove(product);
    //        //base.Delete(entityToDelete);
    //    }
    //}

    ///// <summary>
    ///// Handles crud operations for Company
    ///// </summary>
    //internal class CompanyRepository : GenericRepository<Company>
    //{
    //    public CompanyRepository(ExpenseLoggerContext context)
    //        : base(context)
    //    {
    //    }

    //    /// <summary>
    //    /// Updates a given entity on db.
    //    /// </summary>
    //    /// <param name="entityToUpdate"></param>
    //    public override void Update(Company entityToUpdate)
    //    {
    //        var company = this.GetByID(entityToUpdate.Id);
    //        company.Name = entityToUpdate.Name;
    //        company.Address = entityToUpdate.Address;
    //        company.Tin = entityToUpdate.Tin;

    //        //base.Update(entityToUpdate);
    //    }

    //    /// <summary>
    //    /// Removes a given entity from db.
    //    /// </summary>
    //    /// <param name="entityToDelete"></param>
    //    public override void Delete(Company entityToDelete)
    //    {
    //        var company = this.GetByID(entityToDelete.Id);
    //        dbSet.Remove(company);
    //        //base.Delete(entityToDelete);
    //    }

    //    //public override IList<Company> Get()
    //    //{
    //    //    using(var context = new ExpenseLoggerContext())
    //    //    {
    //    //        List<Company> companies = context.Companies.ToList();
    //    //        return companies;
    //    //    }
    //    //    //return base.Get();
    //    //}
    //}

    ///// <summary>
    ///// Handles CRUD operations for records.
    ///// </summary>
    //internal class ExpenseRecordRepository : GenericRepository<ExpenseRecord>
    //{
    //    public ExpenseRecordRepository(ExpenseLoggerContext context)
    //        : base(context)
    //    {
    //    }

    //    /// <summary>
    //    /// Updates a given entity on db.
    //    /// </summary>
    //    /// <param name="entityToUpdate"></param>
    //    public override void Update(ExpenseRecord entityToUpdate)
    //    {
    //        ExpenseRecord record = this.GetByID(entityToUpdate.Id);
    //        record.Price = entityToUpdate.Price;
    //        record.ProductId = entityToUpdate.ProductId;
    //        record.Date = entityToUpdate.Date;
    //        record.Description = entityToUpdate.Description;
    //        //base.Update(entityToUpdate);
    //    }

    //    /// <summary>
    //    /// Removes a given entity on db.
    //    /// </summary>
    //    /// <param name="entityToDelete"></param>
    //    public override void Delete(ExpenseRecord entityToDelete)
    //    {
    //        var record = this.GetByID(entityToDelete.Id);
    //        dbSet.Remove(record);
    //        //base.Delete(entityToDelete);
    //    }
    //} 
    #endregion

    #region New Implementation

    internal abstract class GenericRepository<B, EF> : IRepository<B>
        where EF : class
        where B : class
    {
        protected ExpenseLoggerContext context;
        protected DbSet<EF> dbSet;
        //CTOR to set mapper
        static GenericRepository()
        {
            //Mapper.CreateMap<B, EF>();
            //Mapper.CreateMap<EF, B>();

            Mapper.CreateMap<CompanyModel, Company>();
            Mapper.CreateMap<ProductModel, Product>();
            Mapper.CreateMap<ExpenseRecordModel, ExpenseRecord>();

            Mapper.CreateMap<Company, CompanyModel>();
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<ExpenseRecord, ExpenseRecordModel>();
        }
        //CTOR for IOC Implemaentation.
        public GenericRepository(ExpenseLoggerContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<EF>();

            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var set = objectContext.CreateObjectSet<EF>();
            set.MergeOption = System.Data.Entity.Core.Objects.MergeOption.NoTracking;
        }

        #region IRepository<B> Members

        public IList<B> Get()
        {
            List<EF> list = dbSet.AsNoTracking().ToList();
            return Mapper.Map<List<EF>, List<B>>(list); 
        }

        public B GetByID(object id)
        {
            //TODO:Implement a better solution to this
            EF entity = dbSet.Find(id);
            return Mapper.Map<EF,B>(entity);
        }

        public void Insert(B entity)
        {
            EF newEntity = Mapper.Map<B,EF>(entity);
            dbSet.Add(newEntity);
        }

        public void Delete(object id)
        {
            EF entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public abstract void Update(B entityToUpdate);

        //public void Update(B entityToUpdate)
        //{
        //    EF entity = Mapper.Map<B,EF>(entityToUpdate);

        //    dbSet.Attach(entity);
        //    context.Entry(entity).State = EntityState.Modified;
        //}
        
        #endregion
    }


    internal class CompanyRepository : GenericRepository<Company,CompanyModel>
    {
        public CompanyRepository(ExpenseLoggerContext context)
            :base(context)
        {
        }

        public override void Update(Company entityToUpdate)
        {
            CompanyModel entity = dbSet.Find(entityToUpdate.Id);
            entity.Address = entityToUpdate.Address;
            entity.Name = entityToUpdate.Name;
            entity.Tin = entityToUpdate.Tin;

            //TODO:REFACTOR
            //context.Companies.Attach(entity);
            //context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

    internal class ProductRepository : GenericRepository<Product, ProductModel>
    {
        public ProductRepository(ExpenseLoggerContext context)
            :base(context)
        {
        }

        public override void Update(Product entityToUpdate)
        {
            ProductModel entity = dbSet.Find(entityToUpdate.Id);
            entity.CompanyId = entityToUpdate.CompanyId;
            entity.Description = entityToUpdate.Description;
            entity.Name = entityToUpdate.Name;
        }
    }

    internal class ExpenseRecordRepository : GenericRepository<ExpenseRecord, ExpenseRecordModel>
    {
        public ExpenseRecordRepository(ExpenseLoggerContext context)
            :base(context)
        {
        }

        public override void Update(ExpenseRecord entityToUpdate)
        {
            ExpenseRecordModel entity = dbSet.Find(entityToUpdate.Id);
            entity.Date = entityToUpdate.Date;
            entity.Description = entityToUpdate.Description;
            entity.Price = entityToUpdate.Price;
            entity.ProductId = entityToUpdate.ProductId;
        }
    }


    #endregion
}
