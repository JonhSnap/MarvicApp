using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Notifications_Request.ViewModels
{
    public class GetNotification_ViewModel
    {
        public int CountUnView { get; set; }
        
        public List<Notification_ViewModel> Items { get; set; }
        public GetNotification_ViewModel()
        {
            CountUnView = 0;
            Items = new List<Notification_ViewModel>();
        }
        public GetNotification_ViewModel(int countUnView, List<Notification_ViewModel> items)
        {
            CountUnView = countUnView;
            Items = items;
        }
    }
}
