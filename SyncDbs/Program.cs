using AutoMapper;
using Microsoft.VisualBasic;
using SyncDbs;
using System.ServiceProcess;

if (Environment.UserInteractive)
{
    using (AppActions appActions = new AppActions())
    {
        appActions.Execute();
    }
    Console.ReadKey();
}
else
{
    using (var service = new SyncDbService())
    {
        ServiceBase.Run(service);
    }
}
