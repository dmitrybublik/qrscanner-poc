using System;
using System.Collections.Generic;
using System.Reflection;
using Caliburn.Micro;
using QRScanner.Launcher;

namespace QRScanner.iOS
{
    //TODO: Replace with a proper bootstrapper
    public class CaliburnAppDelegate : CaliburnApplicationDelegate
    {       
        public CaliburnAppDelegate()
        {
            Initialize();
        }

        protected override void Configure()
        {            
            ContainerContext.Registrator.RegisterInstance(ContainerContext.Registrator);
            ContainerContext.Registrator.RegisterSingleton<FormsApp>();
            ContainerContext.Registrator.RegisterSingleton<IEventAggregator, EventAggregator>();
        }

        protected override void BuildUp(object instance)
        {
            ContainerContext.Adapter.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return ContainerContext.Adapter.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return ContainerContext.Adapter.GetInstance(service, key);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return
                new[]
                {                    
                    //TODO: Needed for views to be registered - consider using this manually in the bootstrapper
                    Assembly.LoadFile(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "QRScanner.Presentation.Shell.dll"))
                };
        }
    }
}