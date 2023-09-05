using System;

namespace Scripts
{
    public static class GameEvents
    {
        public static Action<ItemData> ShowItemDataPopup = delegate { };
        public static Action<ItemData> StartLearningNugget = delegate { };
        public static Action CloseItemDataPopup = delegate { };
    }
}