using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpwanner : NetworkBehaviour
{

     public GameObject EnemyPrefab;
     public int numberOfEnemy;
     public override void OnStartServer()
     {
          for (int i = 0; i < numberOfEnemy; i++)
          {
               Vector3 spwanPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0f, Random.Range(-8.0f, 8.0f));
               Quaternion spwanRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0.0f);
               GameObject enemy = (GameObject)Instantiate(EnemyPrefab, spwanPosition, spwanRotation);
               NetworkServer.Spawn(enemy);
          }
     }
}
