using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utility
{
    public enum ConfigurationKey
    {
        SMPT_SERVER_PORT,
        SMPT_SERVER_HOST,
        SMPT_USERNAME,
        SMPT_PASSWORD
    }
    public enum TemplateIdentifier
    {
        TASK_ASSIGNED,
        TASK_UPDATE,
        TASK_STATUS_UPDATE,
        TASK_ASSIGNED_SUBJECT,
        TASK_UPDATE_SUBJECT,
        TASK_STATUS_UPDATE_SUBJECT,
        TASK_REMINDER,
        TASK_REMINDER_SUBJECT,
        SCHEDULE_TASK_REMINDER,
        SCHEDULE_TASK_REMINDER_SUBJECT,
        RESET_PASSWORD,
        RESET_PASSWORD_SUBJECT
    }
}
