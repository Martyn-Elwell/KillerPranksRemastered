using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private float targetPos;
    public bool shrink;
    public bool disapear;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position.y + 110f;
        transform.DOMoveY(targetPos, 1, true).SetEase(Ease.InOutCubic);
        if (disapear )
        {
            gameObject.GetComponent<Image>().DOFade(0f, 1f).SetEase(Ease.InOutCubic);
        }
        else if ( shrink && !disapear)
        {
            transform.DOScale(0.8f, 1f).SetEase(Ease.InOutCubic);
        }
        else
        {
            transform.DOScale(1f, 1f).SetEase(Ease.InOutCubic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
