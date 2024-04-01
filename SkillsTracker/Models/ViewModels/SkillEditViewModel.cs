using System.Collections.Generic;
using System.Web.Mvc;

namespace SkillsTracker.Models.ViewModels
{
    public class SkillEditViewModel
    {
        public Skill TheSkill { get; set; }
        public IEnumerable<int> SelectedParents { get; set; }
        public IEnumerable<int> SelectedChildren { get; set; }
        public IEnumerable<SelectListItem> PotentialParents { get; set; }
    }

}