using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{

     public const int maxHealth = 100;
     [SyncVar(hook = "OnChangeHealth")]
     public int currentHealth = maxHealth;

     public RectTransform healthBar;
     public bool destoryOnDeath;

     public void TakeDamage(int amount)
     {
          if (!isServer)
          {
               return;
          }
          currentHealth -= amount;
          if (currentHealth <= 0)
          {
               if (destoryOnDeath)
               {
                    Destroy(gameObject);
               }
               else
               {
                    currentHealth = maxHealth;
                    RpcRespwan();
               }

          }


     }

     void OnChangeHealth(int health)
     {
          healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
     }

     [ClientRpc]
     void RpcRespwan()
     {
          if (!isLocalPlayer)
          {
               transform.position = Vector3.zero;
          }
     }
}
