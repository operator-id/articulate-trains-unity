using System;
using UnityEngine;

namespace Scripts
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private ItemDataPopup popup;

        public void ShowItemDataPopup(ItemData itemData)
        {
            popup.Setup(itemData);
            popup.Show(true);
        }

        public void CloseItemDataPopup()
        {
            popup.Show(false);
        }
    }
}