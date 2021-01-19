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
        private SerializedDictionary<string, Achievement> achievements = new SerializedDictionary<string, Achievement>();

        public GameObject canvas;
        private void Start()
        {
            if (instance != null) instance = this;
            LoadAchievementProgress();
            DontDestroyOnLoad(this);
        }
        
        
        
        void CheckAchievement(AchievementCondition condition,string name, int amount)
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
            var notification = Instantiate(achieNotification, achieNotification.transform.position,
                achieNotification.transform.rotation,canvas.transform);
            var notificationElements = GetComponent<AchievementNotification>();
            notificationElements.title.SetText(achievement.name);
            notificationElements.description.SetText(achievement.description);
            notificationElements.icon.sprite = achievement.icon;
            
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
