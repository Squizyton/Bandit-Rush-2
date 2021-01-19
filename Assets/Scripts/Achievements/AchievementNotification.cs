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
}
