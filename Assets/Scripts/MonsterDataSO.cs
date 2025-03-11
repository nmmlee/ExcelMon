using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterDatabaseSO", menuName = "GameData/MonsterDatabase")]
public class MonsterDataSO : ScriptableObject
{
    public List<MonsterData> monsters = new List<MonsterData>();
}
