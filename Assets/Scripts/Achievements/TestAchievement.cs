using System;
using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    public class TestAchievement : MonoBehaviour
    {
        public List<AchievementTemplate> testList = new List<AchievementTemplate>();
        public Achievement testAchievement;

        private Dictionary<AchievementCondition, List<Achievement> > achievements = new Dictionary<AchievementCondition,List<Achievement>>();
        private List<Achievement> completedAchievements = new List<Achievement>();
            
        private void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckAchievement(AchievementCondition.Kill, "boar", 1);
            }
        }
        
        void CheckAchievement(AchievementCondition condition,string name, int amount)
        {
            if (achievements.TryGetValue(condition, out var achievementList))
            {
                foreach (Achievement achievement in achievementList)
                {
                    if (achievement.condition == condition && achievement.name.ToLower() == name)
                    {
                        if (!achievement.completed)
                            achievement.amountLeft -= amount;
                        if (achievement.amountLeft <= 0)
                        {
                            achievement.completed = true;
                        }

                        break;
                    }
                }
            }
        }
    }
}
