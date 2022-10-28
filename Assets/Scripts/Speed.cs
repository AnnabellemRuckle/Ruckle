using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
   public float BoostMultiplier = 2.0f;
    public float BoostSeconds = 5.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("SPEED BOOST!");

            PlayerController Player = collision.gameObject.GetComponent<PlayerController>();
            Player.BoostSpeed(BoostMultiplier,BoostSeconds);
        }
    }
}
