using System;
using System.ServiceProcess;

namespace NotificationServiceV1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new NotificationService());

        }
    }
}
