using UnityEngine;


public enum GameObjectType  //여기서 필요한 아이템을 추가하면 됩니다 일단은 정해진 오브젝트가 없기 때문에 알파벳으로 두웠습니다.
{
    No,
    Ice,
    Water,
    Nothing
}
public enum PuzzleType  //여기서 필요한 아이템을 추가하면 됩니다 일단은 정해진 오브젝트가 없기 때문에 알파벳으로 두웠습니다.
{
    Answer,
    Question

}

public class PuzzleObjects : MonoBehaviour
{
    private GameObjectType _gameObjectType;

    [SerializeField] private PuzzleType _puzzleType;

    private GameObject[] puzzleObjects = new GameObject[9];

    [Header("puzzleObject")]

    int[] startQuestion = { 2, 2, 2,
                            2, 2, 2, 
                            2, 2, 2 };
    int[] curPattern = new int[9];
    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartSetting()
    {
        for (int i = 0; i < transform.childCount; i++)  //차일드 카운트니깐 예외처리는 딱히 상관없을 듯
        {
            puzzleObjects[i] = transform.GetChild(i).gameObject;

        }
        SettingObject(startQuestion);
    }

    //크기가 9인 배열을 매게 변수로 받는다.  인덱스의 반복문을 돌리면서 확인한다.
    //반목문안에 스위치 문을 만들어서 얼음, 물, 불,을 활성화 한다.

    public void SettingObject(int[] pattern)
    {
        
        for (int i = 0; i < pattern.Length; i++)
        {
            switch (pattern[i])
            {
                case (int)GameObjectType.No:
                    puzzleObjects[i].transform.GetChild(0).gameObject.SetActive(false);  //이친구들을 아예다 스타트에서 넣고 시작해보자.
                    puzzleObjects[i].transform.GetChild(1).gameObject.SetActive(false);
                    curPattern[i] = (int)GameObjectType.No;
                    break;
                case (int)GameObjectType.Ice:
                    puzzleObjects[i].transform.GetChild(0).gameObject.SetActive(true);
                    puzzleObjects[i].transform.GetChild(1).gameObject.SetActive(false);
                    curPattern[i] = (int)GameObjectType.Ice;
                    break;
                case (int)GameObjectType.Water:
                    puzzleObjects[i].transform.GetChild(0).gameObject.SetActive(false);
                    puzzleObjects[i].transform.GetChild(1).gameObject.SetActive(true);
                    curPattern[i] = (int)GameObjectType.Water;
                    break;
                case (int)GameObjectType.Nothing:
                    break;
                default:
                    break;
            }
        }
        QuestionPattern();
    }

    public int[] QuestionPattern()
    {
        return curPattern;
    }
}
