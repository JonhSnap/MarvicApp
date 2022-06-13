using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class Notif_User
    {
        public Guid Id { get; set; }
        public Guid IdNotif { get; set; }
        public Guid IdUser { get; set; }
        public EnumStatus IsView { get; set; }
        public Notif_User()
        {
            Id = Guid.Empty;
            IdNotif = Guid.Empty;
            IdUser = Guid.Empty;
            IsView = EnumStatus.False;
        }

        public Notif_User(Guid idNotif, Guid idUser)
        {
            Id = Guid.NewGuid();
            IdNotif = idNotif;
            IdUser = idUser;
            IsView = EnumStatus.False;
        }
    }
}
