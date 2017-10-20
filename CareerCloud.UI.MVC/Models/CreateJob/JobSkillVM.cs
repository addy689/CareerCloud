using System.ComponentModel.DataAnnotations;

namespace CareerCloud.UI.MVC.Models.CreateJob
{
    public class JobSkillVM
    {
        public string Skill { get; set; }
        [Display(Name = "SkillLevel")]
        public string SelectedSkillLevel { get; set; }

        [Display(Name = "Importance")]
        public string SelectedImportance { get; set; }

        public static string[] SkillLevelChoiceList { get; set; }
        public static string[] ImportanceChoiceList { get; set; }
    }
}