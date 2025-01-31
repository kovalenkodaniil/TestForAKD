using UnityEngine;

namespace _Core.Scripts.Item
{
    public class Item : MonoBehaviour
    {
        private Transform _parent;

        public Transform Parent => _parent;

        public void ReplaceParent(Transform newParent)
        {
            _parent = newParent;
            
            transform.SetParent(_parent);
            transform.localPosition = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}