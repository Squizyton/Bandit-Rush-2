using System;
using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    public class TestAchievement : MonoBehaviour
    {
        public AchievementTemplate test;

        public Achievement testAchievement;

        private Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
        private void Start()
        {
            testAchievement = new Achievement(test.title, test.icon, test.description, test.obj, test.amount, test.condition);
            achievements.Add(testAchievement.name, testAchievement);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckAchievement(AchievementTemplate.AchievementCondition.Kill, "boar", 1);
            }

        }
        
        void CheckAchievement(AchievementTemplate.AchievementCondition condition,string name, int amount)
        {
            if (achievements.TryGetValue(name, out var achievement))
            {
                if (achievement.condition == condition && !achievement.completed)
                {
                    achievement.
                }
                else return;
            }
        }
    }
}
