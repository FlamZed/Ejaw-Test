using System;
using System.Collections.Generic;

[Serializable]
public class ListItem
{
    public Values[] Objects;
}

[Serializable]
public class Values
{
    public string Name;
}