using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class trashSlow : MonoBehaviour
{
    // Start is called before the first frame update
            Rigidbody2D playerRB;
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(!playerRB)
            {
             playerRB = collider.gameObject.GetComponent<Rigidbody2D>();
            }
            var slowForce = -(playerRB.velocity)*.7f;
            playerRB.AddForce(slowForce, ForceMode2D.Force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
