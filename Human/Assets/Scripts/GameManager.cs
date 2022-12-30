using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
     private Camera Cam;
    [SerializeField] private GameObject prefab;
   
    public static int armysayısı;   
    public static int gold;
    public static int goldsayı=1;


    private int Maxplayer;
    private int fıngerID = -1;
  
    public static bool gec;
    
    private void Start()
    {

       


        gold = 0;              
        Maxplayer = 4;                  
        armysayısı = 0;
        
       
        Cam = Camera.main;
        fıngerID = 0;
        prefab.transform.GetChild(1).gameObject.SetActive(false);

        goldsayı = PlayerPrefs.GetInt(nameof(goldsayı), goldsayı);
        Maxplayer = PlayerPrefs.GetInt(nameof(Maxplayer), Maxplayer);
        Movement.maxHealth = PlayerPrefs.GetInt(nameof(Movement.maxHealth), Movement.maxHealth);

    }

    private void Awake()
    {
        UISıngl.Instance.armysizebutton.onClick.AddListener(ArmyCount);
        UISıngl.Instance.goldupgradebutton.onClick.AddListener(GoldUpgrade);
        UISıngl.Instance.armorupgradebutton.onClick.AddListener(HealthBoost);


       


    }
    private void Update()
    {         
        SpawnAtMousePos();                         
    }
    private void SpawnAtMousePos()
    {
        if (EventSystem.current.IsPointerOverGameObject(fıngerID)==false) // Burda şunu demek istiyorum.GUI lara dokunmuyorsak aşağıdaki ray leri çalıştır.Bu sayede GUI a tıklarken oluşan bug engelleniyor.FıngerID olayını anlamadım ben de ona tekrar bakmam lazım.
        {
            if (armysayısı > Maxplayer)
            {
                return;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                Movement.maxHealth = 1;
                if (gec)
                {
                    Movement.maxHealth = 2;
                }
                if (Physics.Raycast(ray, out hit))
                {                   
                    Instantiate(prefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);                                    
                        armysayısı++;                                               
                }
            }
        }      
    }


    private void GoldUpgrade()
    {
        if (gold >= 15)
        {
            goldsayı = 2;
            PlayerPrefs.SetInt(nameof(goldsayı),goldsayı);
            gold = gold - 15;

        }
    }

    public void ArmyCount()
    {
        if (gold >= 30)
        {         
            Maxplayer = 9;
            PlayerPrefs.SetInt(nameof(Maxplayer), Maxplayer);

            gold = gold - 30;
        }
       
    }

    public void HealthBoost()
    {
        if (gold >= 20)
        {
            gec = true;
            prefab.transform.GetChild(1).gameObject.SetActive(true);
            Movement.maxHealth = 2;
            PlayerPrefs.SetInt(nameof(Movement.maxHealth),Movement.maxHealth);
            
            gold = gold - 20;
            //bunun playerprefini nasıl alıcaz anlayamadım.
        }
       
    }
    public void Playagainn()
    {
        SceneManager.LoadScene(0);
    }

   
}


