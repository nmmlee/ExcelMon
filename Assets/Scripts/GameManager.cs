using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterDatabase monsterDB;
    public SkillDatabase skillDB;

    private Dictionary<int, List<SkillData>> monsterSkills = new Dictionary<int, List<SkillData>>();

    void Start()
    {
        LoadMonsterSkills();
        ShowMonsterSkills(201);
        ShowMonsterSkills(202);
        ShowMonsterSkills(203);
        ShowMonsterSkills(204);
        ShowMonsterSkills(205);
    }

    void LoadMonsterSkills()
    {
        foreach(MonsterData monster in monsterDB.GetAllMonsters())
        {
            List<SkillData> availableSkills = skillDB.GetSkillsForMonster(monster.attribute, monster.type);
            monsterSkills[monster.id] = availableSkills;
        }

        Debug.Log($"�� {monsterSkills.Count}���� ���� ��ų ���� �����͸� �ε��߽��ϴ�.");
    }

    public void ShowMonsterSkills(int monsterId)
    {
        if (monsterSkills.TryGetValue(monsterId, out List<SkillData> skills))
        {
            Debug.Log($"���� ID {monsterId}�� ���� ��ų ����Ʈ:");
            foreach (SkillData skill in skills)
            {
                Debug.Log($"- {skill.name} (�Ӽ�: {skill.attribute}, �Һ� ����: {skill.manaCost})");
            }
        }
        else
        {
            Debug.Log($"���� ID {monsterId}�� ���� ��ų �����Ͱ� �����ϴ�.");
        }
    }
}
