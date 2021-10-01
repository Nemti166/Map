using System.Linq;
using UnityEngine;
using Game.Helper;

namespace Game.Map
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cell;

        private void Start()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            var list = Borders.instance.Map.List;

            foreach (var m in list)
            {
                GameObject cloneCell = Instantiate(_cell, transform);
                cloneCell.GetComponent<SpriteRenderer>().sprite = Image(m.Id);

                cloneCell.transform.localPosition = new Vector3(m.X, m.Y);
            }
        }

        private Sprite Image(string name)
        {
            Sprite sprite = Resources.Load<Sprite>("MapSprites/" + name);
            
            return sprite;
        }
    }
}
