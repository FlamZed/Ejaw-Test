using UnityEngine;

public class ScriptableObject : MonoBehaviour
{
    public struct Cube
    {
        public const int ObservableTime = 8;
        public const int MinClick = 2;
        public const int MaxClick = 5;

        public static Color[] colors = new Color[]
            {
                Color.red,
                Color.black,
                Color.green,
                Color.yellow,
            };
    }

    public struct Sphere
    {
        public const int ObservableTime = 5;
        public const int MinClick = 1;
        public const int MaxClick = 3;

        public static Color[] colors = new Color[]
            {
                Color.green,
                Color.cyan,
                Color.magenta,
            };
    }

    public struct Capsule
    {
        public const int ObservableTime = 10;
        public const int MinClick = 3;
        public const int MaxClick = 5;

        public static Color[] colors = new Color[]
            {
                Color.magenta,
                Color.yellow,
                Color.white,
            };
    }
}