using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToobarSlot : MonoBehaviour
{
    private bool isSelected = false;
    public int positionIndex;
    private float moveDistance = 110f;
    private float moveTime = 0.5f;
    private float targetPos;
    private float targetScale;
    private float targetAlpha;

    public void Start()
    {
        targetPos = transform.position.y;
        targetScale = 0.8f;
        targetAlpha = 1f;
    }
    public void AssignPostiion(int index)
    {
        positionIndex = index;
        if (index == 2)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isSelected = true;
        }
        if (index >= 4)
        {
            Color newColour = GetComponent<Image>().color;
            newColour.a = 0f;
            GetComponent<Image>().color = newColour;
        }
    }

    public void AssignIcon(Sprite icon)
    {

    }

    public void MoveUp()
    {
        positionIndex++;
        if (positionIndex >= 5)
        {
            return;
        }

        targetPos = transform.position.y + moveDistance;
        transform.DOMoveY(targetPos, moveTime, true).SetEase(Ease.InOutCubic);

        targetScale = 0.8f;
        targetAlpha = 1f;

        // If not selcted switch bool
        if (positionIndex != 2)
        {
            isSelected = false;
        }
        // Selected tool
        if (positionIndex == 2)
        {
            targetScale = 1f;
            transform.DOScale(targetScale, moveTime).SetEase(Ease.InOutCubic);
            isSelected = true;
        }
        // Deselected previous tool
        if (positionIndex == 3)
        {
            transform.DOScale(targetScale, moveTime).SetEase(Ease.InOutCubic);
            isSelected = false;
        }
        // Fade for invisible 5th slot
        else if (positionIndex == 4)
        {
            targetAlpha = 0f;
            gameObject.GetComponent<Image>().DOFade(targetAlpha, moveTime).SetEase(Ease.InOutCubic);
        }

    }

    public void MoveDown()
    {
        positionIndex--;
        if (positionIndex <= -1)
        {
            return;
        }
        float targetPos = transform.position.y - moveDistance;
        transform.DOMoveY(targetPos, moveTime, true).SetEase(Ease.InOutCubic);

        targetScale = 0.8f;
        targetAlpha = 1f;

        // If not selcted switch bool
        if (positionIndex != 2)
        {
            isSelected = false;
        }
        // Deselected previous tool
        if (positionIndex == 1)
        {
            transform.DOScale(targetScale, moveTime).SetEase(Ease.InOutCubic);
            isSelected = false;
        }
        // Selected tool
        if (positionIndex == 2)
        {
            targetScale = 1f;
            transform.DOScale(targetScale, moveTime).SetEase(Ease.InOutCubic);
            isSelected = true;
        }
        // Fade in for 3rd slot
        else if (positionIndex == 3)
        {
            gameObject.GetComponent<Image>().DOFade(targetAlpha, moveTime).SetEase(Ease.InOutCubic);
        }
    }

    public void InteruptAnimation()
    {
        
        transform.DOComplete();
        gameObject.GetComponent<Image>().DOComplete();
    }
}
