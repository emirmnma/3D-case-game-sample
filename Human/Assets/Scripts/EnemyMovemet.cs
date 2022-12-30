
using UnityEngine;


public class EnemyMovemet : MonoBehaviour
{
    private GameObject playerCastle;
    [SerializeField] private GameObject partıcle;

     private Vector3 targetPos;

    [SerializeField] private float enemySpeed;
   
    private void Start()
    {      
        playerCastle = GameObject.Find("BaseA");
    }
    private void Update()
    {
        CheckForOtherEnemies();
        transform.position = Vector3.MoveTowards(transform.position, targetPos, enemySpeed * Time.deltaTime);
        transform.LookAt(targetPos);
      
    }

    private void OnCollisionEnter(Collision collision)
    {       
        if (!collision.gameObject.CompareTag("Player")) return;       
        AfterDead();          
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("kale")) return;       
        Destroy(gameObject);
    }

    
    private void CheckForOtherEnemies()
    {
        var collider = Physics.OverlapSphere(transform.position, 20f, 1<<6);
        targetPos = collider.Length > 0 ? collider[0].gameObject.transform.position : playerCastle.transform.position;
    }
    
    private void AfterDead()
    {       
        GameObject yenipart = Instantiate(partıcle, transform.position, Quaternion.identity);
        Destroy(yenipart, 1f);            
    }


  
}
