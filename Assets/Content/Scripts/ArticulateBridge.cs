using System.Runtime.InteropServices;

namespace Scripts
{
    public class ArticulateBridge
    {
        [DllImport("__Internal")]
        public static extern void ShowItemNugget(string itemId);
    }
}