using System.ComponentModel.DataAnnotations;

namespace CareerCloud.UI.MVC.Models.CreateJob
{
    public class JobEducationVM
    {
        public string Major { get; set; }

        [Display(Name = "Importance")]
        public string SelectedImportance { get; set; }

        public static string[] ImportanceChoiceList { get; set; }
    }
}