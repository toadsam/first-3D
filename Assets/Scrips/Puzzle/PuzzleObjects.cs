using UnityEngine;


public enum GameObjectType  //���⼭ �ʿ��� �������� �߰��ϸ� �˴ϴ� �ϴ��� ������ ������Ʈ�� ���� ������ ���ĺ����� �ο����ϴ�.
{
    No,
    Ice,
    Water,
    Nothing
}
public enum PuzzleType  //���⼭ �ʿ��� �������� �߰��ϸ� �˴ϴ� �ϴ��� ������ ������Ʈ�� ���� ������ ���ĺ����� �ο����ϴ�.
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
        for (int i = 0; i < transform.childCount; i++)  //���ϵ� ī��Ʈ�ϱ� ����ó���� ���� ������� ��
        {
            puzzleObjects[i] = transform.GetChild(i).gameObject;

        }
        SettingObject(startQuestion);
    }

    //ũ�Ⱑ 9�� �迭�� �Ű� ������ �޴´�.  �ε����� �ݺ����� �����鼭 Ȯ���Ѵ�.
    //�ݸ񹮾ȿ� ����ġ ���� ���� ����, ��, ��,�� Ȱ��ȭ �Ѵ�.

    public void SettingObject(int[] pattern)
    {
        
        for (int i = 0; i < pattern.Length; i++)
        {
            switch (pattern[i])
            {
                case (int)GameObjectType.No:
                    puzzleObjects[i].transform.GetChild(0).gameObject.SetActive(false);  //��ģ������ �ƿ��� ��ŸƮ���� �ְ� �����غ���.
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
