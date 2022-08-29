using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float distance;
    public List<Transform> coins = new List<Transform>();
    void Start()
    {
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
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.tag = gameObject.tag;
            coins.Add(other.transform);
        }
    }
}
