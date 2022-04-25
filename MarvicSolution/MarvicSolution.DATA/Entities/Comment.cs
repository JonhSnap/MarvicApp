using MarvicSolution.DATA.Enums;
using System;


namespace MarvicSolution.DATA.Entities
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(Guid id_User, Guid id_Issue, string content, Guid id_ParentComment)
        {
            Id_User = id_User;
            Id_Issue = id_Issue;
            Content = content;
            Update_Date = DateTime.Now;
            Create_Date = DateTime.Now;
            Is_Delete = EnumStatus.False;
            Id_ParentComment = id_ParentComment;
        }

        public Guid Id { get; set; }
        public Guid Id_User { get; set; }
        public Guid Id_Issue { get; set; }
        public string Content { get; set; }
        public DateTime Update_Date { get; set; }
        public DateTime Create_Date { get; set; }
        public EnumStatus Is_Delete { get; set; }
        public Guid Id_ParentComment { get; set; }
    }
}
