using System;
using FreshMvvm;

namespace PBEye
{
    public class PageModelMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            return pageModelType.AssemblyQualifiedName.Replace("ViewModel", "View");
        }
    }
}