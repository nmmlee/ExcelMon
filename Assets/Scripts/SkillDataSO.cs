using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDataSO", menuName = "ScriptableObjects/SkillDataSO", order = 1)]
public class SkillDataSO : ScriptableObject
{
    public List<SkillData> skills = new List<SkillData>();
    public Dictionary<int, List<SkillEffectMapping>> skillEffects = new Dictionary<int, List<SkillEffectMapping>>();
}