using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Achievements
{
    public class AchievementManager : MonoBehaviour
    {
        public AchievementManager instance;

        public List<AchievementTemplate> startAchievements;
        private List<Achievement> completedAchievements = new List<Achievement>();

        public GameObject achieNotification;

       
        //Would it be more efficent to make a custom dictionary class??????
        private Dictionary<string, Achievement>
            achievements = new Dictionary<string, Achievement>();

        public GameObject canvas;

        private void Start()
        {
            if (instance != null) instance = this;
            LoadAchievementProgress();
            DontDestroyOnLoad(this);
        }


        void CheckAchievement(AchievementCondition condition, string name, int amount)
        {
            if (achievements.TryGetValue(name.ToLower(), out var achievement))
            {
                Debug.Log("Found " + achievement.name);
                if (achievement.condition == condition && !achievement.completed)
                {
                    achievement.amountHave += amount;
                    if (achievement.amountHave >= achievement.amountLeft)
                    {
                        achievement.completed = true;
                        //Send AchievementNotification
                        SendNotification(achievement);
                    }
                }
            }
        }


        void SendNotification(Achievement achievement)
        {
            Debug.Log("Achievement COmpleted:" + achievement.name);
            Debug.Log(achievement.icon + achievement.achievementTitle + achievement.description);
            var notification = Instantiate(achieNotification, canvas.transform);
            var notificationElements = FindObjectOfType<AchievementNotification>();
            if (notificationElements != null)
                notificationElements.UpdateAchievement(achievement.icon, achievement.achievementTitle,
                    achievement.description);
        }
        #region Saving&Loading

        void OnApplicationQuit()
        {
            SaveAchievementProgress();
        }

        void SaveAchievementProgress()
        {
        }

        void LoadAchievementProgress()
        {
            var x = 0;
            foreach (AchievementTemplate temp in startAchievements)
            {
                var achievement = new Achievement(temp.name.ToLower(), temp.achievementTitle, temp.icon,
                    temp.description, temp.obj, temp.amount,
                    temp.condition);
                //Debug.Log(achievement.name);
                x++;
                achievements.Add(achievement.name, achievement);
            }
        }

        #endregion
    }
}