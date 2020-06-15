using Resources.Entities;
using System.Collections.Generic;
namespace Resources.Abstract
{
    public interface IResourceProvider
    {
        object GetResource(string name, string culture);

        IList<ResourceEntry> GetResource(string culture);

        void SetUpdatedResources();
    }
}