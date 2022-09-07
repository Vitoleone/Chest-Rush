using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text TapToPlay;
    [SerializeField] private GameObject HandImage;
    void Start()
    {
        TapToPlay.transform.DOScale(1.2f, 0.5f).SetLoops(10000,LoopType.Yoyo).SetEase(Ease.InOutFlash);
        HandImage.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-230f,-584f),1f).SetLoops(100000,LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }

    
}
