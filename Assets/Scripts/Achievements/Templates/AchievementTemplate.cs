using UnityEngine;

namespace Achievements
{
    public enum AchievementCondition
    {
        Kill,
        JumpOver,
        Collect,
        Destroy,
        Tap
    }
    
    [CreateAssetMenu(fileName = "New Achievement", menuName = "New Achievement")]
    public class AchievementTemplate : ScriptableObject
    {
        
        
        public Sprite icon;
        public string title;
        public string description;
        public AchievementCondition condition;
        public GameObject obj;
        public int amount;
    }
}
