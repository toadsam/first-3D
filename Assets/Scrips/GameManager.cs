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

        bearNum = 2;
    }

    private void Start()
    {
         StartSetBearNum();
        
    }

    // Update is called once per frame
    void Update()
    {

        UpdateBearNum();
    }

    void BearRespwan()
    {      
            scale = Random.Range(1F, 2F);
            GameObject bears = Instantiate(bear, bearRespwanPos.position, Quaternion.identity);
            bears.GetComponent<NPC>().player = player;
            bears.transform.localScale = new Vector3(scale, scale, scale);
           // bearNum++;
      
    }

    public void BearDie()
    {
        
        bearNum--;
    }
    public void StartSetBearNum()
    {
        for(int i = 0; i < bearNum; i++)
        {
            BearRespwan();
        }
    }
    public void UpdateBearNum()
    {
        if (bearNum < 2)
        {
            bearNum++;
            Invoke("BearRespwan", 4);


        }
    }
   
    
}

//�̰� �����Ŵ����� �������� ��
//���� �޴��� �̱���ȭ �����ϰ� �����ũ�� �ִ°� �� �޼���� �ٲٰ�
// Ÿ���� �����ؼ� �� ���͸��� ��� �ؾ��ϴ��� �����ֱ�