using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;

namespace WpfUI
{
    internal static class ContainerProvider
    {
        private static CompositionContainer container;

        public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    List<AssemblyCatalog> catalogList = new List<AssemblyCatalog>();
                    catalogList.Add(new AssemblyCatalog(typeof(IMatrixEntryForm).Assembly));
                    container = new CompositionContainer(new AggregateCatalog(catalogList));
                }

                return container;
            }
        }
    }
}
