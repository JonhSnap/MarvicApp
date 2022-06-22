namespace MarvicSolution.Services.Project_Resquest.Dtos.ViewModels
{
    public class SetUserRoleByIdProject_ViewModel
    {
        public int Value { get; set; }
        public string RoleName { get; set; }

        public SetUserRoleByIdProject_ViewModel()
        {
            Value = 0;
            RoleName = string.Empty;
        }
    }
}
