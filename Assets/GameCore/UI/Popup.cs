using TMPro;
using UnityEngine;

namespace GameCore.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textLabel;

        public void Setup(string msg)
        {
            gameObject.SetActive(true);
            _textLabel.text = msg;
        }

        public void CloseButtonClick()
        {
            gameObject.SetActive(false);
        }
    }
}
