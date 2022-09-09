using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellingCoins : MonoBehaviour
{
    public bool isSelled = false;
    private void Update()
    {
        if(isSelled)
        {
            Vector3 targetPos = GameManager.instance.GetIconPosition(transform.position);
            if (Vector2.Distance(transform.position, targetPos) > 2f)
            {
                
            }
            else
            {
                GameManager.instance.AddCoin(50);
                transform.DOKill();
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SellingArea"))
        {
            isSelled = true;
            GameManager.instance.coins.Remove(gameObject.transform);
            Vector3 targetPos = GameManager.instance.GetIconPosition(transform.position);
            transform.DOLocalMoveX(-(transform.position - targetPos).x, 0.75f);
            transform.DOLocalMoveY(-(transform.position - targetPos).y, 0.75f);
            transform.DOScaleX(0.2f, 0.75f);
            transform.DOScaleY(0.2f, 0.75f);
        }
    }
}
