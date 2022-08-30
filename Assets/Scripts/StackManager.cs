using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            other.transform.parent = null;
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackManager>();
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.tag = gameObject.tag;
            GameManager.instance.coins.Add(other.transform);
        }
    }

}
