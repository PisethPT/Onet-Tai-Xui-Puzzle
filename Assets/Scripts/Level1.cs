using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    public List<Image> imagesTabale;
    public List<int> intValues;
    public List<int> valueShuffleButton;
    public int[] valueStorage;
    public List<Sprite> spritesTabale;
    public Button[] buttonsTabale;
    public List<int> valueOfButtons;
    public GameObject[] level1;
    public GameObject[] levelScripts;
    public int elements, values;
    public GameObject optionOject;
    [SerializeField] Animator cloudAnimation;
    [SerializeField] GameObject levelPanel, congrate;
    [SerializeField] Image optionPanel;
    [SerializeField] Sprite optionSprite;
    public AudioSource onclick,cloud, congrates;
    void Start()
    {
        level1[0].SetActive(false);
        level1[1].SetActive(true);
        level1[2].SetActive(false);
        levelScripts[0].SetActive(false);
        levelScripts[1].SetActive(true);
        levelScripts[2].SetActive(false);
        //GetValueRandom();
    }

    void Update()
    {

    }

    public void GetValueRandom()
    {
        for (int i = 0; i < values; i++)
        {
            int value = Random.Range(0, values);
            while (intValues.Contains(value))
                value = Random.Range(0, values);
            intValues.Add(value);
        }
        for (int i = 0; i < intValues.Count; i++)
        {
            valueStorage[i] = intValues[i];
            valueStorage[values + i] = intValues[i];
        }
        ChangeSpriteIntoImages();
    }

    private void ChangeSpriteIntoImages()
    {
        for (int i = 0; i < elements; i++)
        {
            int r = Random.Range(0, elements);
            while (valueShuffleButton.Contains(r))
                r = Random.Range(0, elements);
            valueShuffleButton.Add(r);
        }
        for (int i = 0; i < valueStorage.Length; i++)
        {
            for (int j = 0; j < spritesTabale.Count; j++)
            {
                if (valueStorage[i] == j)
                {
                    imagesTabale[valueShuffleButton[i]].color = new Color(255, 255, 255, 255);
                    imagesTabale[valueShuffleButton[i]].sprite = spritesTabale[j];
                }
            }
        }
    }
    bool isON = true;
    int a, b, countTrueValue = 0;
    public void ButtonsClick(int n)
    {
        onclick.Play();
        for (int i = 0; i < valueShuffleButton.Count; i++)
        {
            if (n == valueShuffleButton[i])
            {
                isON = !isON;
               // print(valueStorage[i]);
                buttonsTabale[n].image.color = new Color(227, 114, 66, 0.4f);
                buttonsTabale[n].enabled = false;
                valueOfButtons.Add(valueStorage[i]);
                if (isON)
                {
                    b = valueShuffleButton[i];
                    isON = true;
                    CheckTrueImage();
                    ClearAndResetButtonValueList();
                }
                else
                    a = valueShuffleButton[i];
            }
        }
    }
    public List<int> buttonIndexEnables = new List<int>();
    void ClearAndResetButtonValueList()
    {
        if (valueOfButtons.Count >= 2)
        {
            valueOfButtons.Clear();

            for (int i = 0; i < buttonIndexEnables.Count; i++)
            {
                for (int j = 0; j < buttonsTabale.Length; j++)
                {
                    if (buttonIndexEnables[i] == j)
                    {
                       // print("i: " + i);
                        buttonsTabale[buttonIndexEnables[i]].enabled = false;
                        buttonsTabale[j].image.color = new Color(227, 114, 66, 0.4f);
                        break;
                    }
                }
            }
            a = b = 0;
        }
    }

    void CheckTrueImage()
    {
        if (valueOfButtons[0].Equals(valueOfButtons[1]))
        {
            // print("win!!");
            buttonsTabale[a].transform.GetChild(0).gameObject.SetActive(false);
            buttonsTabale[b].transform.GetChild(0).gameObject.SetActive(false);
            buttonIndexEnables.Add(a);
            buttonIndexEnables.Add(b);
            countTrueValue++;
            CompletedMission(countTrueValue);
        }
        else
        {
            buttonsTabale[a].enabled = true;
            buttonsTabale[b].enabled = true;
            buttonsTabale[a].image.color = new Color(255, 255, 255, 255);
            buttonsTabale[b].image.color = new Color(255, 255, 255, 255);
            a = b = 0;

        }
    }

    private void ClearAllItems()
    {
        for (int i = 0; i < imagesTabale.Count; i++)
        {
            buttonsTabale[i].image.color = new Color(255, 255, 255, 255);
            buttonsTabale[i].enabled = true;
            valueStorage[i] = 0;
            buttonsTabale[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        intValues.Clear();
        valueShuffleButton.Clear();
        valueOfButtons.Clear();
        countTrueValue = 0;
    }

    void CompletedMission(int countTrueValue)
    {
        if ((countTrueValue * 2).Equals(buttonsTabale.Length))
        {
            //  print("COMPLETED MISSION.");
            congrates.Play();
            congrate.SetActive(true);
            buttonIndexEnables.Clear();
            StartCoroutine(waitAnimate());
            IEnumerator waitAnimate()
            {
                cloudAnimation.Play("clouds");
                cloud.Play();
                yield return new WaitForSeconds(2f);
                FindObjectOfType<LevelLoading>().SetUpGame();
                levelPanel.SetActive(true);
                optionPanel.sprite = optionSprite;
                optionOject.SetActive(true);
                level1[1].SetActive(false);
                levelScripts[1].SetActive(false);
                ClearAllItems();
                congrate.SetActive(false);
                cloudAnimation.Play("cloudsOut");
                cloud.Play();
            }
        }
    }
}
