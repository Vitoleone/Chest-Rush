using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float distance;
    public List<Transform> coins = new List<Transform>();
    public static GameManager instance;
    [SerializeField] public GameObject newCoin;
    public bool isSubstracted = false;
    
    void Start()
    {
        instance = this;
        coins.Add(gameObject.transform);//Chest will be the first coin in list
    }

    // Update is called once per frame
    void Update()
    {
        if(coins.Count > 1)
        {
            for(int i = 1; i < coins.Count; i++)
            {
                var FirstCoin = coins.ElementAt(i-1);
                var SectCoin = coins.ElementAt(i);

                var DesireDistance = -Vector3.Distance(SectCoin.position, FirstCoin.position);
                Vector3 xDistance = new Vector3(Mathf.Lerp(SectCoin.position.x, FirstCoin.position.x, 8 * Time.deltaTime), 0, 0);
                Vector3 zDistance = new Vector3(0, 0, Mathf.Lerp(SectCoin.position.z, FirstCoin.position.z + 2f, 5 * Time.deltaTime));
                if(DesireDistance <= distance)
                {
                    
                    SectCoin.position = new Vector3(xDistance.x
                    , SectCoin.position.y, zDistance.z);
                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            other.transform.parent = null;
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackManager>();
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.tag = gameObject.tag;
            coins.Add(other.transform);
        }
        if(other.CompareTag("AddGate"))
        {
            
            var AddNumber = Int32.Parse(other.transform.GetChild(0).name);
            Debug.Log(AddNumber);
            for (int i = 0; i < AddNumber; i++)
            {
                if(coins.ElementAt(coins.Count -1).position.y == 0)
                {
                    GameObject Coin = Instantiate(newCoin, coins.ElementAt(coins.Count - 1).position + new Vector3(0, 0.884f, 2f), Quaternion.identity);
                    other.transform.parent = null;
                    other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.AddComponent<StackManager>();
                    other.gameObject.GetComponent<Collider>().isTrigger = true;
                    other.tag = gameObject.tag;
                    coins.Add(Coin.transform);
                }
                else
                {
                    GameObject Coin = Instantiate(newCoin, coins.ElementAt(coins.Count - 1).position + new Vector3(0,0, 2f), Quaternion.identity);
                    other.transform.parent = null;
                    other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.AddComponent<StackManager>();
                    other.gameObject.GetComponent<Collider>().isTrigger = true;
                    other.tag = gameObject.tag;
                    coins.Add(Coin.transform);
                }
              
                
            }
        }
        if (other.CompareTag("SubsGate") && coins.Count > 0 && isSubstracted == false)
        {
            coins.ElementAt(coins.Count - 1).gameObject.SetActive(false);
            coins.RemoveAt(coins.Count - 1);
            isSubstracted = true;
            Invoke("SetIsSubstractedFalse",2f);
         
        }
        if(coins.Count == 0)
        {
            //Gameover screen
            
        }
    }
    public void SetIsSubstractedFalse()
    {
        isSubstracted = false;
    }
}
