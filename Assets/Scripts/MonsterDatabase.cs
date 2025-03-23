using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterDatabase : MonoBehaviour
{
    // SO ������ �����ϴ� ����
    public MonsterDataSO monsterDataSO;

    void Start()
    {
        LoadMonsterData("Assets/CSV/MonsterData.csv");
    }

    void LoadMonsterData(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("CSV ������ ã�� �� �����ϴ�: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        List<MonsterData> monsters = new List<MonsterData>();

        for (int i = 1; i < lines.Length; i++) // ù ��° ���� ����� �ǳʶ�
        {
            string[] values = lines[i].Split(',');

            if (values.Length < 10) continue; // ������ �����ϸ� ��ŵ

            int id = int.Parse(values[0]);
            string name = values[1];
            string attribute = values[2];
            string type = values[3];
            int attack = int.Parse(values[4]);
            int health = int.Parse(values[5]);
            int speed = int.Parse(values[6]);
            int minLevel = int.Parse(values[7]);
            int maxLevel = int.Parse(values[8]);
            string imageFile = values[9];

            MonsterData monster = new MonsterData(id, name, attribute, type, attack, health, speed, minLevel, maxLevel, imageFile);
            monsters.Add(monster);
        }

        monsterDataSO.monsters = monsters;

        Debug.Log($"�� {monsters.Count}���� ���� �����͸� �ε��߽��ϴ�.");
    }

    public List<MonsterData> GetAllMonsters()
    {
        return monsterDataSO.monsters;
    }
}