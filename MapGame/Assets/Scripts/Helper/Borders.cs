using System;

namespace Game.Helper
{
    public static class Borders
    {
        [Serializable]
        public struct BordersStruct
        {
            public float Left;
            public float Right;
            public float Top;
            public float Bottom;
        }

        private static BordersStruct _gameBorders;

        public static BordersStruct GameBorders { get => _gameBorders; set => _gameBorders = value; }
    }
}
