
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UISıngl : MonoBehaviour
{
    public static UISıngl Instance;

    [Header("Butonlar")] 

    public Button armysizebutton;
    public Button goldupgradebutton;
    public Button armorupgradebutton;



    [Header("Text'ler")]

    public TextMeshProUGUI armysayıtext;
    public TextMeshProUGUI goldtext;
    public TextMeshPro kaletext;
    public TextMeshPro kaletext2;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
          
        }
    }

   
}
