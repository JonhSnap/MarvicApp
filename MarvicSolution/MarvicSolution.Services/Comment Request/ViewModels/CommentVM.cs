using System;

namespace MarvicSolution.Services.Comment_Request.ViewModels
{
    public class CommentVM
    {
        public CommentVM() { }
        public CommentVM(Guid id, Guid id_User, Guid id_Issue, string userName, string content, DateTime update_Date, DateTime create_Date, Guid id_ParentComment)
        {
            Id = id;
            Id_User = id_User;
            UserName = userName;
            Id_Issue = id_Issue;
            Content = content;
            Update_Date = update_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Create_Date = create_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Id_ParentComment = id_ParentComment;
        }

        public CommentVM(Guid id, Guid id_User, Guid id_Issue, string content, DateTime update_Date, DateTime create_Date, Guid id_ParentComment)
        {
            Id = id;
            Id_User = id_User;
            Id_Issue = id_Issue;
            Content = content;
            Update_Date = update_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Create_Date = create_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Id_ParentComment = id_ParentComment;
        }

        public Guid Id { get; set; }
        public Guid Id_User { get; set; }
        public Guid Id_Issue { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public string Update_Date { get; set; }
        public string Create_Date { get; set; }
        public Guid Id_ParentComment { get; set; }
        public int CountChild { get; set; }

    }
    
}
