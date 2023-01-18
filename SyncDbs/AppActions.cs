using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncDbs
{
    public class AppActions : IDisposable
    {
        DateTime start = DateTime.Now;
        public AppActions()
        {
            start = DateTime.Now;
            Console.WriteLine($"operation started at {start}");
        }
        public void Dispose()
        {
        }
        public void Execute() 
        {
            using (DbActions actions = new DbActions()) 
            {
                if (actions.BackupDestination())
                {
                    Console.WriteLine("destination backup completed.");
                    if (actions.ClearDestination())
                    {
                        Console.WriteLine("destination clear completed.");
                        GC.Collect();
                        using (DbActions actions1 = new DbActions())
                        {
                            int transactionCount = 0;
                            int alltransaction = actions1.GetSourceCount();
                            var thread = new Thread(() =>
                            {
                                transactionCount = actions1.UpdateDestination();
                            });
                            thread.Start();
                            System.Timers.Timer timer = new System.Timers.Timer();
                            timer.Interval = 10000;
                            timer.Elapsed += (sender, e) => Timer_Elapsed(sender, e, thread.IsAlive, alltransaction, actions1.InsertCount);
                            timer.Disposed += (sender, e) => Timer_Disposed(sender, e, alltransaction, actions1.InsertCount, actions1);
                            timer.Start();
                        }
                    }
                    else
                    {
                        var end = DateTime.Now;
                        var message = $"operation ended with error at {end}.backup destination was successfull but error occured in destination clearing.";
                        Console.WriteLine(message);
                        actions.AddLog(false, message, DateAndTime.DateDiff(DateInterval.Minute, start, end));
                    }
                }
                else
                {
                    var end = DateTime.Now;
                    var message = $"operation ended with error at {end}.error occured in backup destination.";
                    Console.WriteLine(message);
                    actions.AddLog(false, message, DateAndTime.DateDiff(DateInterval.Minute, start, end));
                }
            }
        }
        void Timer_Disposed(object? sender, EventArgs e, int AllTransaction, int progressed, DbActions baseClass)
        {
            var end = DateTime.Now;
            Console.WriteLine($"{progressed}/{AllTransaction} transaction done!please wait");
            string message = "";
            switch (progressed)
            {
                case -1:
                    message = $"operation ended with error at {end}.destination has been backed up and cleared successfully but error occured in insert operation.";
                    break;
                case 0:
                    message = $"operation ended at {DateTime.Now}.no record to transfer found.";
                    break;
                default:
                    message = $"operation ended successfully at {DateTime.Now}. row transfer count : {progressed}";
                    break;
            }
            Console.WriteLine(message);
            baseClass.AddLog(true, message, DateAndTime.DateDiff(DateInterval.Minute, start, end));
            GC.Collect();
            baseClass.Dispose();
        }

        void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e, bool Alive, int AllTransaction, int progressed)
        {
            if (Alive)
            {
                Console.WriteLine($"{progressed}/{AllTransaction} transaction done!please wait");
            }
            else
            {
                var timer = (System.Timers.Timer)sender;
                timer.Dispose();
            }
        }
    }
}
