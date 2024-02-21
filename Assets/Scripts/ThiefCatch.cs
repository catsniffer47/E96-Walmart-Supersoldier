using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCatch : MonoBehaviour
{
    int thievesCaught;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Thief"))
        {
            thievesCaught++;
            Debug.Log("Caught a thief! Caught " + thievesCaught + " !");
        }
        else
        {
            Debug.Log("Not a thief!");
        }
    }
}
