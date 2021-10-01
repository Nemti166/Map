using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class OptionsPanel : MonoBehaviour
    {
        [SerializeField]
        private Text _optionText;

        [SerializeField]
        private Point _point;

        public void OpenPanel()
        {
            _optionText.text = _point.GetTileName();

            Time.timeScale = 0;
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
            
            Time.timeScale = 1;
        }
    }
}
