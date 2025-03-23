using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SkillData
{
    public int id;
    public string name;
    public string attribute;
    public string monsterType;
    public int manaCost;
    public string imageFile;

    public SkillData(int id, string name, string attribute, string monsterType, int manaCost, string imageFile)
    {
        this.id = id;
        this.name = name;
        this.attribute = attribute;
        this.monsterType = monsterType;
        this.manaCost = manaCost;
        this.imageFile = imageFile;
    }
}

[System.Serializable]
public class SkillEffectMapping
{
    public int skillId;
    public string effectType;
    public float value1;
    public int turnMinValue;
    public int turnMaxValue;

    public SkillEffectMapping(int skillId, string effectType, float value1, int turnMinValue, int turnMaxValue)
    {
        this.skillId = skillId;
        this.effectType = effectType;
        this.value1 = value1;
        this.turnMinValue = turnMinValue;
        this.turnMaxValue = turnMaxValue;
    }
}