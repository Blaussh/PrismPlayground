using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

namespace PrismOutlook.Core.Regions
{
    public class DependentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionBehavior";

        public DependentViewRegionBehavior()
        {

        }

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var view in e.NewItems)
                {
                    var atts = GetCustomAttributes<DependentViewAttribute>(view.GetType());

                    foreach (var att in atts)
                    {
                        var info = CreateDependentViewInfo(att);
                    }
                }

            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {

            }
        }


        DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
        {
            var info = new DependentViewInfo();
            info.Region = attribute.Region;
            
            return info;
        }

        private static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }


    public class DependentViewInfo
    {
        public object View { get; set; }
        public string Region { get; set; }
    }
}
