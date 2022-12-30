
using UnityEngine;




public class Movement : MonoBehaviour
{
     private GameObject enemyCastle;

    [SerializeField] private float Speed2;

    public static int maxHealth = 1;
    void Start()
    {       
       transform.rotation = Quaternion.Euler(0f, 180f, 0f);
       if (!enemyCastle)
       {   
            enemyCastle = GameObject.Find("BaseB");
       }     
    }

   

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyCastle.transform.position,Speed2 * Time.deltaTime);
        transform.LookAt(enemyCastle.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            
            maxHealth--;
           
            GameManager.gold += GameManager.goldsayı;
           
            Destroy(collision.gameObject);
             
            if (maxHealth == 0)
            {
                Destroy(this.gameObject);
                GameManager.armysayısı--;
                maxHealth = 1;
                if (GameManager.gec)
                {
                    maxHealth = 2;
                }
            }

        }
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("kale")) return;
        kalecan2.can--;
        Destroy(gameObject, 0.1f);
        GameManager.armysayısı--;
    }


}
