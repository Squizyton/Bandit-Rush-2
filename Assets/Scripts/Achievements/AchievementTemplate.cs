using UnityEngine;

namespace Achievements
{
    [CreateAssetMenu(fileName = "New Achievement", menuName = "Scriptable Objects/New Achievement")]
    public class AchievementTemplate : ScriptableObject
    {
        public Sprite icon;
        public string title;
        public string description;
        public bool kill, jump, collect, destroy, tap;
        public int amount;
    }
}
