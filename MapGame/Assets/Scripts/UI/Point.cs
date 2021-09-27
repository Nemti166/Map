using System.Linq;
using UnityEngine;
using Game.Map;

namespace Game.UI
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        private Transform _pointTransform;

        private MapList _tileList = new MapList();

        public void LoadTiles()
        {
            TextAsset asset = Resources.Load("JSON/testing_views_settings_normal_level") as TextAsset;

            if (asset != null)
            {
                _tileList = JsonUtility.FromJson<MapList>(json: asset.text);
            }
            else
            {
                Debug.Log("no assets");
                return;
            }
        }

        public string GetTileName()
        {
            var list = _tileList.List;
            Vector2 minVector = new Vector2(list.Min(x => x.X), list.Min(y => y.Y));
            float minDistance = Vector2.Distance(_pointTransform.position, minVector);
            string name = null;

            for (int i = 0; i < list.Count; i++)
            {
                Vector2 currentTilePosition = new Vector2(list[i].X, list[i].Y);
                float distanceToTile = Vector2.Distance(_pointTransform.position, currentTilePosition);

                if(distanceToTile <= minDistance)
                {
                    minDistance = distanceToTile;
                    name = list[i].Id;
                }
            }
            
            return name;
        }
    }
}
