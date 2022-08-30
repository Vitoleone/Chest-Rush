using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (other.CompareTag("AddGate"))
        {

            var AddNumber = Int32.Parse(other.transform.GetChild(0).name);
            Debug.Log(AddNumber);
            for (int i = 0; i < AddNumber; i++)
            {
                if (GameManager.instance.coins.ElementAt(GameManager.instance.coins.Count - 1).position.y == 0)
                {
                    GameObject Coin = Instantiate(GameManager.instance.newCoin, GameManager.instance.coins.ElementAt(GameManager.instance.coins.Count - 1).position + new Vector3(0, 0.884f, 2f), Quaternion.identity);
                    Coin.transform.parent = null;
                    Coin.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                    Coin.gameObject.AddComponent<StackManager>();
                    Coin.gameObject.GetComponent<Collider>().isTrigger = true;
                    Coin.tag = gameObject.tag;
                    GameManager.instance.coins.Add(Coin.transform);
                }
                else
                {
                    GameObject Coin = Instantiate(GameManager.instance.newCoin, GameManager.instance.coins.ElementAt(GameManager.instance.coins.Count - 1).position + new Vector3(0, 0, 2f), Quaternion.identity);
                    Coin.transform.parent = null;
                    Coin.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                    Coin.gameObject.AddComponent<StackManager>();
                    Coin.gameObject.GetComponent<Collider>().isTrigger = true;
                    Coin.tag = gameObject.tag;
                    GameManager.instance.coins.Add(Coin.transform);
                }


            }
            other.GetComponent<Collider>().enabled = false;
        }
        if (other.CompareTag("SubsGate"))
        {
           var SubNumber = Int32.Parse(other.transform.GetChild(0).name);
            if(GameManager.instance.coins.Count > SubNumber)
            {
                for (int i = 0; i < SubNumber; i++)
                {
                    GameManager.instance.coins.ElementAt(GameManager.instance.coins.Count - 1).gameObject.SetActive(false);
                    GameManager.instance.coins.RemoveAt(GameManager.instance.coins.Count - 1);
                }
                
            }
           
        }
        if (GameManager.instance.coins.Count == 0)
        {
            //gameOver screen
            Debug.Log("Bitti");
        }
    }

}
