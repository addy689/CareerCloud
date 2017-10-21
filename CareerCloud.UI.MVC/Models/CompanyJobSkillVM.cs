using System.ComponentModel.DataAnnotations;

namespace CareerCloud.UI.MVC.Models
{
    public class CompanyJobSkillVM
    {
        [Display(Name = "Skill")]
        public string SkillName { get; set; }
        [Display(Name = "Skill Level")]
        public string SelectedSkillLevel { get; set; }

        [Display(Name = "Importance")]
        public string SelectedImportance { get; set; }

        public static string[] SkillLevelChoiceList { get; set; }
        public static string[] ImportanceChoiceList { get; set; }
    }
}