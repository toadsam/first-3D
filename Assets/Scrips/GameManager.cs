using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject bear;
    public  int bearNum;  //������ ��
    public Transform bearRespwanPos;


    
    public Player player;
    float scale;

    public static GameManager Instance;  //�̱��� ����


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        bearNum = 0;
    }

    private void Start()
    {
        BearRespwan();
    }

    // Update is called once per frame
    void Update()
    {
        BearRespwan();
    }

    void BearRespwan()
    {
        if (bearNum < 1)
        {

            scale = Random.Range(1F, 3F);
            GameObject bears = Instantiate(bear, bearRespwanPos.position, Quaternion.identity);
            bears.GetComponent<NPC>().player = player;
            bears.transform.localScale = new Vector3(scale, scale, scale);
            bearNum++;

        }
    }

    public void BearDie()
    {
        
        bearNum--;
    }
   
    
}

//�̰� �����Ŵ����� �������� ��
//���� �޴��� �̱���ȭ �����ϰ� �����ũ�� �ִ°� �� �޼���� �ٲٰ�
// Ÿ���� �����ؼ� �� ���͸��� ��� �ؾ��ϴ��� �����ֱ�