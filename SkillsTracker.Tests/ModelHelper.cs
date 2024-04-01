using SkillsTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTracker.Tests
{
    internal static class ModelHelper
    {
        public static IEnumerable<Skill> GetRandomSkillExcluding(IEnumerable<Skill> skills,int numEntities, IEnumerable<int> excludedIds)
        {
            var count = skills.Select(entity => !excludedIds.Contains(entity.Id))
                     .Count();

            if (count < numEntities)
                throw new InvalidOperationException("Tried to retrieve more items in the skills list than exist.");

            var random = new Random();

            var randomEntity = skills
                        .Where(entity => !excludedIds.Contains(entity.Id))
                        .OrderBy(entity => random.Next())
                        .Take(numEntities);

            return randomEntity;
        }

        public static IEnumerable<Skill> GetRandomSkillFromCollection(ICollection<Skill> parents, int numEntities = 1)
        {
            var random = new Random();

            var randomEntity = parents
                                .OrderBy(entity => random.Next())
                                .Take(numEntities);

            return randomEntity;
        }
    }
}
