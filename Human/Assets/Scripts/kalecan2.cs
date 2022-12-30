
using UnityEngine;

public class kalecan2 : MonoBehaviour
{
    [SerializeField] private GameObject losetext;
    [SerializeField] private GameObject kaleParticle;
    [SerializeField] private GameObject kalepart;
    [SerializeField] private GameObject kalepart2;
    private GameObject baseb;

    private int kaletextint;
    public static float can;
 
    void Start()
    {
        kaletextint = 10;
        losetext.SetActive(false);
        baseb = GameObject.Find("BaseB");      
        can = 10;
        Time.timeScale = 1;
    }

  
    void Update()
    {
        kalecan22();     
        kalecann();      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            kaletextint--;                 
            Destroy(collision.gameObject);          
        }
    }   

    void kalecan22()
    {
        UISıngl.Instance.armysayıtext.text = GameManager.armysayısı.ToString();
        UISıngl.Instance.goldtext.text = GameManager.gold.ToString();
        UISıngl.Instance.kaletext.text = kaletextint.ToString();


        if (kaletextint == 0)
        {
            GameObject yenıpart = Instantiate(kalepart, transform.position, Quaternion.identity);
            Destroy(yenıpart, 0.2f);
            Destroy(gameObject);
            Time.timeScale = 0;
            losetext.SetActive(true);
        }
    }

    void kalecann()
    {
        UISıngl.Instance.kaletext2.text = can.ToString();

        if (can == 0)
        {
            GameObject yenıpart = Instantiate(kalepart2, baseb.transform.position, Quaternion.identity);
            Destroy(yenıpart, 0.2f);
            Destroy(gameObject);
            Time.timeScale = 0f;
            losetext.SetActive(true);

        }
    }  
}

