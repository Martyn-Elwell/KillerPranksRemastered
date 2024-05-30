using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class ToobarSlot : MonoBehaviour
{
    private bool isSelected = false;
    public int positionIndex;
    [SerializeField] private Text description;
    private float moveDistance = 110f;
    private float moveTime = 0.5f;
    private float targetPos;
    private float targetScale = 0.8f;
    private float targetAlpha = 1f;

    public void Start()
    {
        // Save intial position as target
        targetPos = transform.position.y;

        // Hide text by default
        Color newColour = description.color;
        newColour.a = 0f;
        description.color = newColour;
    }
    public void AssignPostiion(int index)
    {
        positionIndex = index;
        // Selected Icon
        if (index == 2)
        {
            // Scale up for selected
            targetScale = 1f;
            transform.DOScale(targetScale, moveTime * 0.5f).SetEase(Ease.InOutCubic);
            isSelected = true;

            // Reveal text
            description.DOFade(targetAlpha, moveTime * 0.5f).SetEase(Ease.InOutCubic);
        }
        if (index >= 4)
        {
            // Hide Icon
            GetComponent<Image>().DOFade(0f, 0f);
        }
    }

    // Assign icon and description to icon
    public void AssignData(ItemData data)
    {
        Image image = GetComponent<Image>();
        image.sprite = data.Icon;
        image.color = data.IconColour;
        description.text = data.itemDescription;
    }

    // Move up and adjust depending on position
    public void MoveUp()
    {
        positionIndex++;

        // If 6 ignore, will be destroyed by UI handler
        if (positionIndex >= 5)
        {
            return;
        }

        // Move Up
        targetPos = transform.position.y + moveDistance;
        transform.DOMoveY(targetPos, moveTime, true).SetEase(Ease.InOutCubic);

        // Default icon vlaues
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
            description.DOFade(targetAlpha, moveTime).SetEase(Ease.InOutCubic);
            isSelected = true;
        }
        // Deselected previous tool
        if (positionIndex == 3)
        {
            transform.DOScale(targetScale, moveTime).SetEase(Ease.InOutCubic);
            description.DOFade(0f, moveTime).SetEase(Ease.InOutCubic);
            isSelected = false;
        }
        // Fade for invisible 5th slot
        else if (positionIndex == 4)
        {
            targetAlpha = 0f;
            gameObject.GetComponent<Image>().DOFade(targetAlpha, moveTime).SetEase(Ease.InOutCubic);
        }

    }

    // Move down and adjust depending on position
    public void MoveDown()
    {
        // Iterate index
        positionIndex--;

        // If -1 ignore, will be destroyed by UI handler
        if (positionIndex <= -1)
        {
            return;
        }

        // Move down
        float targetPos = transform.position.y - moveDistance;
        transform.DOMoveY(targetPos, moveTime, true).SetEase(Ease.InOutCubic);

        // Default icon vlaues
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
            description.DOFade(0f, moveTime).SetEase(Ease.InOutCubic);
            isSelected = false;
        }
        // Selected tool
        if (positionIndex == 2)
        {
            targetScale = 1f;
            transform.DOScale(targetScale, moveTime).SetEase(Ease.InOutCubic);
            description.DOFade(targetAlpha, moveTime).SetEase(Ease.InOutCubic);
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
        // Complete all animations
        transform.DOComplete();
        description.DOComplete();
        gameObject.GetComponent<Image>().DOComplete();
    }
}
