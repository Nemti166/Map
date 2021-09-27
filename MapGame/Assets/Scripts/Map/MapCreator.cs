using System.Linq;
using UnityEngine;
using Game.Helper;

namespace Game.Map
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cell;

        private MapList _mapList = new MapList();

        private void Start()
        {
            LoadResources();
        }

        private void LoadResources()
        {
            TextAsset asset = Resources.Load("JSON/testing_views_settings_normal_level") as TextAsset;

            if (asset != null)
            {
                _mapList = JsonUtility.FromJson<MapList>(json: asset.text);
            }
            else
            {
                Debug.Log("no assets");
                return;
            }

            CreateMap();
        }

        private void CreateMap()
        {
            var list = _mapList.List;

            Borders.BordersStruct borders;

            borders.Left = list.First().X - list.First().Width * 0.5f;
            borders.Top = list.First().Y + list.First().Height * 0.5f;
            
            borders.Right = list.Last().X + list.Last().Width * 0.5f;
            borders.Bottom = list.Last().Y - list.Last().Height * 0.5f;

            Borders.GameBorders = borders;

            foreach (var m in _mapList.List)
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
