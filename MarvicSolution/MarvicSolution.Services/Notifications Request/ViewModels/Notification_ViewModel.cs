using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Notifications_Request.ViewModels
{
    public class Notification_ViewModel
    {
        public Guid IdItemRef { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public EnumStatus IsView { get; set; }
        public Notification_ViewModel()
        {
            IdItemRef = Guid.Empty;
            Message = string.Empty;
            Date = DateTime.Now;
            IsView = EnumStatus.False;
        }
    }
}
