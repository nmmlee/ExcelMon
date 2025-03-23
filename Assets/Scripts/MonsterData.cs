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
    public int attack;
    public int health;
    public int speed;
    public int minLevel;
    public int maxLevel;
    public string imageFile;

    public MonsterData(int id, string name, string attribute, string type, int attack, int health, int speed, int minLevel, int maxLevel, string imageFile)
    {
        this.id = id;
        this.name = name;
        this.attribute = attribute;
        this.type = type;
        this.attack = attack;
        this.health = health;  
        this.speed = speed;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.imageFile = imageFile;
    }
}
