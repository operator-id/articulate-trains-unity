using UnityEngine;

namespace Scripts
{
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] private Collider itemCollider;
        [SerializeField] private Renderer itemRenderer;
        [SerializeField] private ItemData data;

        public void Enable(bool value)
        {
            itemCollider.enabled = value;
        }
        private void OnMouseEnter()
        {
            itemRenderer.material.color = Color.green;
        }

        private void OnMouseExit()
        {
            itemRenderer.material.color = Color.white;
        }

        private void OnMouseUpAsButton()
        {
            GameEvents.ShowItemDataPopup.Invoke(data);
        }
    }
}