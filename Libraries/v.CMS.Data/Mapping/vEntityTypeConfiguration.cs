using System.Data.Entity.ModelConfiguration;

namespace v.CMS.Data.Mapping
{
    public abstract class VEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected VEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}