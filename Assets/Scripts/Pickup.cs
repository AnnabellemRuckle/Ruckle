using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum PickupType
{
    Gold,
    Health
}

public class Pickup : MonoBehaviourPun
{
    public PickupType type;
    public int value;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (type == PickupType.Gold)
                player.photonView.RPC("GiveGold", player.photonPlayer, value);
            else if (type == PickupType.Health)
                player.photonView.RPC("Heal", player.photonPlayer, value);

            
            photonView.RPC("DestroyPickup", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void DestroyPickup()
    {
        Destroy(gameObject);
    }

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