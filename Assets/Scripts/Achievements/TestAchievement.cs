using System;
using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    public class TestAchievement : MonoBehaviour
    {
        public AchievementTemplate test;

        public Achievement testAchievement;
        
        Dictionary<>
        private void Start()
        {
            testAchievement = new Achievement(test.title, test.icon, test.description, test.obj, test.amount, test.condition);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckAchievement();
            }

        }
        
        void CheckAchievement(AchievementTemplate.AchievementCondition condition, string name, int amount)
        {
            
        }
    }
}
