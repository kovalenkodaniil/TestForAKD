using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Player config", menuName = "Player/Create Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
        public float mouseSensitivity;
    }
}