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
    
    //Conditions
    public AchievementTemplate.AchievementCondition condition;
    public GameObject RelavantGameObject;
    public int amountLeft;
    
    
    public Achievement(string name, Sprite icon, string description, GameObject obj, int amount, AchievementTemplate.AchievementCondition condition)
    {
        this.name = name;
        this.icon = icon;
        this.description = description;
        this.condition = condition;
        this.RelavantGameObject = obj;
        this.amountLeft = amount;
    }
}
