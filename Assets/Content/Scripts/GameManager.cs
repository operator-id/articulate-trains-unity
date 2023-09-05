using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        private PlayerCharacter _character;
        private List<InteractableItem> _items;

        private void OnEnable()
        {
            GameEvents.ShowItemDataPopup += ShowItemDataPopup;
            GameEvents.CloseItemDataPopup += CloseItemDataPopup;
            GameEvents.StartLearningNugget += StartLearningNugget;
        }

        private void Start()
        {
            _items = FindObjectsOfType<InteractableItem>(true).ToList();
            _character = FindObjectOfType<PlayerCharacter>(true);
        }

        private void OnDisable()
        {
            GameEvents.ShowItemDataPopup -= ShowItemDataPopup;
            GameEvents.CloseItemDataPopup -= CloseItemDataPopup;
            GameEvents.StartLearningNugget -= StartLearningNugget;
        }

        private void ShowItemDataPopup(ItemData itemData)
        {
            UiManager.Instance.ShowItemDataPopup(itemData);
            _character.CanAct = false;
            _items.ForEach(x => x.Enable(false));
        }

        private void StartLearningNugget(ItemData data)
        {
            ArticulateBridge.ShowItemNugget(data.Id);
        }

        private void CloseItemDataPopup()
        {
            _character.CanAct = true;
            _items.ForEach(x => x.Enable(true));
            UiManager.Instance.CloseItemDataPopup();
        }
    }
}