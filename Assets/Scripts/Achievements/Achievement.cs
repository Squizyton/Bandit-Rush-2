using System.Collections;
using System.Collections.Generic;
using Achievements;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string name;
    public Sprite icon;
    public string description;
    public bool completed;
    public string achievementTitle;
    //Conditions
    public AchievementCondition condition;
    public GameObject RelavantGameObject;
    public int amountLeft;
    public int amountHave;
    
    public Achievement(string name,string achievementTitle, Sprite icon, string description, GameObject obj, int amount, AchievementCondition condition)
    {
        this.name = name;
        this.achievementTitle = achievementTitle;
        this.icon = icon;
        this.description = description;
        this.condition = condition;
        this.RelavantGameObject = obj;
        this.amountLeft = amount;
    }
}
