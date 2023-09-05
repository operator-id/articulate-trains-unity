using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(fileName = "NewItemData", menuName = "ScriptableObjects/Item Data", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private string displayName;
        [SerializeField] private string description;

        public string Id => id;

        public string DisplayName => displayName;

        public string Description => description;
    }
}