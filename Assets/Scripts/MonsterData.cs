using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class MonsterData
{
    public int id;
    public string name;
    public string attribute;
    public string type;
    public int minLevel;
    public int maxLevel;
    public string imageFile;

    public MonsterData(int id, string name, string attribute, string type, int minLevel, int maxLevel, string imageFile)
    {
        this.id = id;
        this.name = name;
        this.attribute = attribute;
        this.type = type;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.imageFile = imageFile;
    }
}
