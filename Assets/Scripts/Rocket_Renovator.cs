using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket_Renovator : MonoBehaviour
{
    public Sprite[] headImages;
    public Sprite[] bodyImages;
    public Sprite[] wingImages;

    public SpriteRenderer headSprite;
    public SpriteRenderer bodySprite;
    public SpriteRenderer wingsSprite;

    public int headIndex;
    public int bodyIndex;
    public int wingsIndex;

    public GameObject headRightButton;
    public GameObject headLeftButton;
    public GameObject bodyRightButton;
    public GameObject bodyLeftButton;
    public GameObject wingsRightButton;
    public GameObject wingsLeftButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void CycleHeadSpritesRight()
    {
        if(headIndex < headImages.Length)
        {
            headIndex++;
            headRightButton.SetActive(true);
            headSprite.sprite = headImages[headIndex];
            
            if(headIndex == headImages.Length - 1)
            {
                headLeftButton.SetActive(true);
                headRightButton.SetActive(false);
            }
        }
    }


    public void CycleHeadSpritesLeft()
    {
        if (headIndex > 0)
        {
            headIndex--;
            headLeftButton.SetActive(true);
            headSprite.sprite = headImages[headIndex];

            if (headIndex <= 0)
            {
                headRightButton.SetActive(true);
                headLeftButton.SetActive(false);
            }
        }
    }


    public void CycleBodySpritesRight()
    {
        if (bodyIndex < bodyImages.Length)
        {
            bodyIndex++;
            bodyRightButton.SetActive(true);
            bodySprite.sprite = bodyImages[bodyIndex];

            if (bodyIndex == bodyImages.Length - 1)
            {
                bodyLeftButton.SetActive(true);
                bodyRightButton.SetActive(false);
            }
        }
    }


    public void CycleBodySpritesLeft()
    {
        if (bodyIndex > 0)
        {
            bodyIndex--;
            bodyLeftButton.SetActive(true);
            bodySprite.sprite = bodyImages[bodyIndex];

            if (bodyIndex <= 0)
            {
                bodyRightButton.SetActive(true);
                bodyLeftButton.SetActive(false);
            }
        }
    }


    public void CycleWingsSpritesRight()
    {
        if (wingsIndex < wingImages.Length)
        {
            wingsIndex++;
            wingsRightButton.SetActive(true);
            wingsSprite.sprite = wingImages[wingsIndex];

            if (wingsIndex == wingImages.Length - 1)
            {
                wingsLeftButton.SetActive(true);
                wingsRightButton.SetActive(false);
            }
        }
    }


    public void CycleWingsSpritesLeft()
    {
        if (wingsIndex > 0)
        {
            wingsIndex--;
            wingsLeftButton.SetActive(true);
            wingsSprite.sprite = wingImages[wingsIndex];

            if (wingsIndex <= 0)
            {
                wingsRightButton.SetActive(true);
                wingsLeftButton.SetActive(false);
            }
        }
    }
}
