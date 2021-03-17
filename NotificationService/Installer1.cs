using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace NotificationService
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {

        private ServiceInstaller serviceInstaller1;
        private ServiceProcessInstaller processInstaller;
        public Installer1()
        {
            // Instantiate installer for process and service.
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller1 = new ServiceInstaller();

            // The service runs under the system account.
            processInstaller.Account = ServiceAccount.LocalSystem;

            // The service is started manually.
            serviceInstaller1.StartType = ServiceStartMode.Manual;

            // ServiceName must equal those on ServiceBase derived classes.
            serviceInstaller1.ServiceName = "NotificationService";

            // Add installer to collection. Order is not important if more than one service.
            Installers.Add(serviceInstaller1);
            Installers.Add(processInstaller);
        }
    }
}
