using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DownloadApp
{
    class Scheduler
    {
        System.Timers.Timer _timer;
    DateTime _scheduleTime;

    public Scheduler()
    {
        _timer = new System.Timers.Timer();
        _scheduleTime = DateTime.Today.AddDays(1).AddHours(10); // Schedule to run once a day at 10:00 a.m.
    }

    public void schedule()
    {           
        // For first time, set amount of seconds between current time and schedule time
        _timer.Enabled = true;
        _timer.Interval = 1000;// _scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;                                          
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
    }

    protected void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // 1. Download FIle
        //Download dl = new Download(new DateTime(sd[0], sd[1], sd[2]), new DateTime(ed[0], ed[1], ed[2]));
        Download dl = new Download();
        
        //2.  Extract File
        Extract exFile = new Extract();
        exFile.ExtractFile();


        // 2. If tick for the first time, reset next run to every 24 hours
        if (_timer.Interval != 24 * 60 * 60 * 1000)
        {
            _timer.Interval = 24 * 60 * 60 * 1000;
        }  
    }
    }
}
