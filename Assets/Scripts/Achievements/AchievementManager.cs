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
        
        //Would it be more efficent to make a custom dictionary class??????
        private SerializedDictionary<string, Achievement> achievements = new SerializedDictionary<string, Achievement>();
        private void Start()
        {
            if (instance != null) instance = this;
            LoadAchievementProgress();
            DontDestroyOnLoad(this);
        }
        
        
        
        void CheckAchievement(AchievementCondition condition,string name, int amount)
        {
            Debug.Log("Attempting to find thing");
            if (achievements.TryGetValue(name.ToLower(), out var achievement))
            {
                Debug.Log("Found " + achievement.name);
                if (achievement.condition == condition && !achievement.completed)
                {
                    achievement.amountLeft -= amount;
                    Debug.Log(achievement.name + "has " + achievement.amountLeft + " left");
                    if (achievement.amountLeft <= 0)
                    {
                        achievement.completed = true;
                        //Send AchievementNotification
                    }
                }
            }
        }


        void SendNotification(Achievement achievement)
        {
            Debug.Log(achievement.name + " has been completed, woo");
        }

        // Test purposes
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckAchievement(AchievementCondition.Kill, "kill boars", 1);
                
            }
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
                var achievement = new Achievement(temp.name.ToLower(), temp.icon, temp.description, temp.obj, temp.amount,
                    temp.condition);
                Debug.Log(temp.name.ToLower());
                Debug.Log(temp.condition);
                x++;
                achievements.Add(achievement.name,achievement);
            }
            Debug.Log("Created "+x+" entries");
        }
        #endregion
    }
}
