using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementNotification : MonoBehaviour
{
   public Image icon;
   public TextMeshProUGUI title, description;


   public void Delete()
   {
      Destroy(this.gameObject);
   }


   public void UpdateAchievement(Sprite icon, string title, string description)
   {
      Debug.Log(title);
      Debug.Log(description);
      this.icon.sprite = icon;
      this.title.SetText(title);
      this.description.SetText(description);
   }
}
