using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_TargetSpawner : MonoBehaviour
{
    public GameObject Target; // enemy
    void Start()
    {
        int childCount = transform.childCount;
        print("chidren:" + childCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-5, 5),
                0,
                Random.Range(-5, 5)
            );

            Vector3 spawnPosition = transform.position + randomPos;
            Quaternion spawnRotation = Quaternion.LookRotation(Vector3.back);
            GameObject Clone = Instantiate(Target, spawnPosition, spawnRotation);
            Clone.transform.SetParent(transform);
        }
    }
}
