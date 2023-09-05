using TMPro;
using UnityEngine;

namespace Scripts
{
    public class ItemDataPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI buttonText;

        private ItemData _data;
        public void Show(bool value)
        {
            gameObject.SetActive(value);
        }

        public void Setup(ItemData data)
        {
            _data = data;
            titleText.text = data.DisplayName;
            descriptionText.text = data.Description;
            buttonText.text = $"Start the {data.DisplayName} learning nugget";
        }

        public void OnCloseButtonClick()
        {
            GameEvents.CloseItemDataPopup.Invoke();
        }

        public void OnStartButtonClick()
        {
            GameEvents.StartLearningNugget.Invoke(_data);
        }
    }
}