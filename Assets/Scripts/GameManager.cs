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

        Debug.Log($"총 {monsterSkills.Count}개의 몬스터 스킬 매핑 데이터를 로드했습니다.");
    }

    public void ShowMonsterSkills(int monsterId)
    {
        if (monsterSkills.TryGetValue(monsterId, out List<SkillData> skills))
        {
            Debug.Log($"몬스터 ID {monsterId}의 보유 스킬 리스트:");
            foreach (SkillData skill in skills)
            {
                Debug.Log($"- {skill.name} (속성: {skill.attribute}, 소비 마나: {skill.manaCost})");
            }
        }
        else
        {
            Debug.Log($"몬스터 ID {monsterId}에 대한 스킬 데이터가 없습니다.");
        }
    }
}
