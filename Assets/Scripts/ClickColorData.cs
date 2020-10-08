using UnityEngine;

public class ClickColorData
{
    public string ObjectType;   //тип создаваемого объекта (куб, сфера, капсула)
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color[] Color;
    public int ObservableTime;

    public ClickColorData(string objectType, int minClick, int maxClick, int observableTime , params Color[] color)
    {
        ObjectType = objectType;
        MinClicksCount = minClick;
        MaxClicksCount = maxClick;
        ObservableTime = observableTime;
        Color = color;
    }
}