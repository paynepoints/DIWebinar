using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SecureLogin.Views;
using Prism.StructureMap;

namespace SecureLogin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            //This is using DI to ensure that the dependencies for main window are loaded
            //when it is created.
            MainWindow shell = this.Container.Resolve<MainWindow>();

            return shell;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppState, AppState>();
            containerRegistry.RegisterSingleton<Services.ILoginService, Services.LoginService>();


            containerRegistry.Register<Services.IThingService, Services.Thing1>();

            //Here we can change the complete implementation of the thing service and the rest of
            //the program could not care less.  Comment out the above registration and uncomment this one.
            //containerRegistry.Register<Services.IThingService, Services.Thing2>();
        }
    }
}
