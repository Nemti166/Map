using System.Linq;
using UnityEngine;
using Game.Helper;

namespace Game.UI
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        private Transform _pointTransform;

        public string GetTileName()
        {
            var list = Borders.instance.Map.List;
            
            Vector2 minVector = new Vector2(Mathf.Abs(_pointTransform.position.x - list.First().X),
                Mathf.Abs(list.First().Y - _pointTransform.position.y));
            
            string name = null;

            for (int i = 0; i < list.Count; i++)
            {
                Vector2 currentTilePosition = new Vector2(Mathf.Abs(_pointTransform.position.x - list[i].X),
                    Mathf.Abs(list[i].Y - _pointTransform.position.y));

                if(currentTilePosition.x <= minVector.x)
                {
                    if(currentTilePosition.y <= minVector.y)
                    {
                        minVector = currentTilePosition;
                        name = list[i].Id;

                    }
                }
            }
            
            return name;
        }
    }
}
