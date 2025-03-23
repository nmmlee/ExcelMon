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
            Debug.LogError("CSV ������ ã�� �� �����ϴ�: " + filePath);
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
        Debug.Log($"�� {skills.Count}���� ��ų �����͸� �ε��߽��ϴ�.");
    }

    void LoadSkillEffectMapping(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("CSV ������ ã�� �� �����ϴ�: " + filePath);
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
        Debug.Log($"�� {effectMapping.Count}���� ��ų ȿ�� ���� �����͸� �ε��߽��ϴ�.");
    }

    public List<SkillData> GetSkillsForMonster(string attribute, string type)
    {
        return skillDataSO.skills.FindAll(skill => skill.attribute == attribute && skill.monsterType == type);
    }

    public void PrintSkillEffects(int skillId)
    {
        if (skillDataSO.skillEffects.ContainsKey(skillId))
        {
            Debug.Log($"[��ų ID {skillId}]�� ȿ�� ���:");

            // skilleffects�� �ȿ� �ִ� ����Ʈ, �� ����Ʈ�� skillmapping Ŭ�����̴�. var effect�� �ش� Ŭ���� ����
            foreach (var effect in skillDataSO.skillEffects[skillId])
            {
                Debug.Log($"- ȿ�� Ÿ��: {effect.effectType}, Value1: {effect.value1}," +
                          $"�ּ� ���� ��: {effect.turnMinValue}, �ִ� ���� ��: {effect.turnMaxValue}");
            }
        }
        else
        {
            Debug.Log($"[��ų ID {skillId}]�� ���� ȿ�� �����Ͱ� �����ϴ�.");
        }
    }
}

