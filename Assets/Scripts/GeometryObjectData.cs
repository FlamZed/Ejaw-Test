using System.Collections.Generic;

public class GeometryObjectData : ScriptableObject
{
    public static List<ClickColorData> ClicksData { get; set; }

    private void Awake()
    {
        ClicksData = new List<ClickColorData>
        {
            new ClickColorData("Cube", Cube.MinClick, Cube.MaxClick, Cube.ObservableTime, Cube.colors),
            new ClickColorData("Sphere", Sphere.MinClick, Sphere.MaxClick, Sphere.ObservableTime, Sphere.colors),
            new ClickColorData("Capsule", Capsule.MinClick, Capsule.MaxClick, Capsule.ObservableTime, Capsule.colors)
        };
    }

    public static ClickColorData GetData(string type) // Get data object ClickColorData from ObjectBehavior
    {
        foreach (var item in ClicksData)
        {
            if (type == item.ObjectType)
                return item;
        }
        return null;
    }
}