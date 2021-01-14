using UnityEngine;

namespace Achievements
{
    [CreateAssetMenu(fileName = "New Achievement", menuName = "Scriptable Objects/New Achievement")]
    public class AchievementTemplate : ScriptableObject
    {
        public enum AchievementCondition
        {
            Kill,
            JumpOver,
            Collect,
            Destroy,
            Tap
        }


        public Sprite icon;
        public string title;
        public string description;
        public AchievementCondition condition;
        public GameObject obj;
        public int amount;
    }
}
