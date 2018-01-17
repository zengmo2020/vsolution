using System;
using v.CMS.Core;
using v.CMS.Core.Data;

namespace v.CMS.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {
            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new VException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();  
                default:
                    throw new VException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
