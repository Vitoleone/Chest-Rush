using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject TapToPlay;
    [SerializeField] private GameObject HandImage;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject TapLine;
    void Start()
    {
        TapToPlay.transform.DOScale(1.2f, 0.5f).SetLoops(10000,LoopType.Yoyo).SetEase(Ease.InOutFlash);
        HandImage.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-230f,-584f),1f).SetLoops(100000,LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TapToPlay.SetActive(false);
            HandImage.SetActive(false);
            Panel.SetActive(false);
            TapLine.SetActive(false);
            GameManager.instance.hasGameStarted = true;
        }
    }


}
