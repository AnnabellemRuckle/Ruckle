using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            
            
            //ameManager.gold += 1;
           // gameManager.PrintLootReport();
            //Debug.Log(gameManager.gold);
            
            
      
        }
        
    }

    
}
