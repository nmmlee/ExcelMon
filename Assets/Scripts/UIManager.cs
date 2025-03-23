using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    // UI 요소들
    public RectTransform monsterListParent; // 몬스터 버튼이 들어갈 Content
    public RectTransform skillListParent;   // 스킬 리스트가 들어갈 Content

    // 몬스터를 클릭했을 때 나오는 UI들
    public GameObject monsterDetailUI;
    public Text monsterNameTextInUI;
    public Text monsterNameImageInUI;
    public Text monsterTypeTextInUI;
    public Text monsterAttributeTextInUI;

    public Text monsterAttackRate;
    public Text monsterHpRate;
    public Text monsterSpeedRate;

    public Image monsterImage;

    public GameObject monsterButtonPrefab; // 버튼 프리팹
    public GameObject skillTextPrefab;     // 스킬 텍스트 프리팹

    void Start()
    {
        PopulateMonsterList();
    }

    // 🟢 몬스터 목록 생성
    void PopulateMonsterList()
    {
        foreach (Transform child in monsterListParent)
        {
            Destroy(child.gameObject);
        }

        foreach (MonsterData monster in gameManager.monsterDB.GetAllMonsters())
        {
            GameObject buttonObj = Instantiate(monsterButtonPrefab, monsterListParent);
            Button button = buttonObj.GetComponent<Button>();

            button.GetComponentsInChildren<Text>()[0].text = monster.imageFile;
            button.GetComponentsInChildren<Text>()[1].text = monster.name;
            button.onClick.AddListener(() => InspectMonster(monster));
        }
    }

    // 몬스터 버튼 클릭 후 해당 몬스터 데이터 불러오기
    void InspectMonster(MonsterData monster)
    {
        monsterDetailUI.SetActive(true);
        monsterNameTextInUI.text = monster.name;
        monsterNameImageInUI.text = monster.imageFile;
        monsterTypeTextInUI.text=monster.type;
        monsterAttributeTextInUI.text = monster.attribute;
        monsterAttackRate.text = monster.attack.ToString();
        monsterHpRate.text = monster.health.ToString();
        monsterSpeedRate.text = monster.speed.ToString(); 
}
}
