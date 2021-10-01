using System;
using System.Linq;
using Game.Map;
using UnityEngine;

namespace Game.Helper
{
    public class Borders : MonoBehaviour
    {
        public static Borders instance;

        private MapList _map = new MapList();

        [Serializable]
        public struct BordersStruct
        {
            public float Left;
            public float Right;
            public float Top;
            public float Bottom;
        }

        private BordersStruct _gameBorders;
        
        public MapList Map => _map;
        public BordersStruct GameBorders => _gameBorders;

        public void Awake()
        {
            if(instance == null)
            {
                instance = this;

                LoadMapTile();
            }
        }

        private void LoadMapTile()
        {
            TextAsset asset = Resources.Load("JSON/testing_views_settings_normal_level") as TextAsset;

            if (asset != null)
            {
                _map = JsonUtility.FromJson<MapList>(json: asset.text);
            }

            CreateBorders();
        }

        private void CreateBorders()
        {
            var list = _map.List;

            Vector2 leftRight = new Vector2(list.Min(x => x.X), list.Max(y => y.X));
            Vector2 topBottom = new Vector2(list.Max(x => x.Y), list.Min(y => y.Y));
            float height = list.Max(h => h.Height);
            float width = list.Max(w => w.Width);

            _gameBorders.Left = leftRight.x - width * 0.5f;
            _gameBorders.Right = leftRight.y + width * 0.5f;

            _gameBorders.Top = topBottom.x + height * 0.5f;
            _gameBorders.Bottom = topBottom.y - height * 0.5f;
        }
    }
}
