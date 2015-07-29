using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.ApplicationModel.Background;

namespace BackgroundTasks
{
    public sealed class NotificationListener : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();

            throw new NotImplementedException();

            _deferral.Complete();
        }
    }
}
