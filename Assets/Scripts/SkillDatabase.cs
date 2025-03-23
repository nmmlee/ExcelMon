using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SkillDatabase : MonoBehaviour
{
    public SkillDataSO skillDataSO;

    void Start()
    {
        LoadSkillData("Assets/CSV/MonsterSkillData.csv");
        LoadSkillEffectMapping("Assets/CSV/SkillEffectMapping.csv");

        PrintSkillEffects(301);
        PrintSkillEffects(302);
        PrintSkillEffects(303);
        PrintSkillEffects(304);
        PrintSkillEffects(305);
    }

    void LoadSkillData(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        List<SkillData> skills = new List<SkillData>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            if (values.Length < 6) continue;

            int id = int.Parse(values[0]);
            string name = values[1];
            string type = values[2];
            string monsterType = values[3];
            int manaCost = int.Parse(values[4]);
            string imageFile = values[5];

            SkillData skill = new SkillData(id, name, type, monsterType, manaCost, imageFile);
            skills.Add(skill);
        }

        skillDataSO.skills = skills;
        Debug.Log($"총 {skills.Count}개의 스킬 데이터를 로드했습니다.");
    }

    void LoadSkillEffectMapping(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        Dictionary<int, List<SkillEffectMapping>> effectMapping = new Dictionary<int, List<SkillEffectMapping>>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            if (values.Length < 5) continue;

            int skillId = int.Parse(values[0]);
            string effectType = values[1];
            float value1 = float.Parse(values[2]);
            int turnMinValue = int.Parse(values[3]);
            int turnMaxValue = int.Parse(values[4]);

            SkillEffectMapping effect = new SkillEffectMapping(skillId, effectType, value1, turnMinValue, turnMaxValue);

            if (!effectMapping.ContainsKey(skillId))
                effectMapping[skillId] = new List<SkillEffectMapping>();

            effectMapping[skillId].Add(effect);
        }

        skillDataSO.skillEffects = effectMapping;
        Debug.Log($"총 {effectMapping.Count}개의 스킬 효과 매핑 데이터를 로드했습니다.");
    }

    public List<SkillData> GetSkillsForMonster(string attribute, string type)
    {
        return skillDataSO.skills.FindAll(skill => skill.attribute == attribute && skill.monsterType == type);
    }

    public void PrintSkillEffects(int skillId)
    {
        if (skillDataSO.skillEffects.ContainsKey(skillId))
        {
            Debug.Log($"[스킬 ID {skillId}]의 효과 목록:");

            // skilleffects의 안에 있는 리스트, 그 리스트는 skillmapping 클래스이다. var effect는 해당 클래스 참조
            foreach (var effect in skillDataSO.skillEffects[skillId])
            {
                Debug.Log($"- 효과 타입: {effect.effectType}, Value1: {effect.value1}," +
                          $"최소 지속 턴: {effect.turnMinValue}, 최대 지속 턴: {effect.turnMaxValue}");
            }
        }
        else
        {
            Debug.Log($"[스킬 ID {skillId}]에 대한 효과 데이터가 없습니다.");
        }
    }
}

