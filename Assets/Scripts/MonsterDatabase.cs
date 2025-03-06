using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterDatabase : MonoBehaviour
{
    public List<MonsterData> monsters = new List<MonsterData>();

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

        for (int i = 1; i < lines.Length; i++) // ù ��° ���� ����� �ǳʶ�
        {
            string[] values = lines[i].Split(',');

            if (values.Length < 6) continue; // ������ �����ϸ� ��ŵ

            int id = int.Parse(values[0]);
            string name = values[1];
            string attribute = values[2];
            string type = values[3];
            int minLevel = int.Parse(values[4]);
            int maxLevel = int.Parse(values[5]);
            string imageFile = values[6];

            MonsterData monster = new MonsterData(id, name, attribute, type, minLevel, maxLevel, imageFile);
            monsters.Add(monster);
        }

        Debug.Log($"�� {monsters.Count}���� ���� �����͸� �ε��߽��ϴ�.");
    }
}