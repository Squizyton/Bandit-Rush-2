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
        private void Start()
        {
            var tempList = new List<Achievement>();
            
            foreach (AchievementTemplate test in testList)
            {
                switch (test.condition)
                {
                    case AchievementCondition.Collect:
                        testAchievement = new Achievement(test.title, test.icon, test.description, test.obj, test.amount,
                            test.condition);
                        tempList.Add(testAchievement);
                        break;
                }
            }
            achievements.Add(testAchievement.condition,tempList);
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
                    if (achievement.condition == condition && achievement.name == name)
                    {
                        if (!achievement.completed)
                            achievement.amountLeft -= amount;
                        if (achievement.amountLeft <= 0)
                        {
                            achievement.completed = true;
                        }
                    }
                }
            }
        }
    }
}
