using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoading: MonoBehaviour
{
    float speed = 1000;
    [SerializeField] private float loadings;
    [SerializeField] private Transform loadingLogo;
    [SerializeField] private GameObject loading, tittle;
    public Animator cloud;
    private bool isPlay;
    public int buttonIndex = 0, index;
    public List<Sprite> spritesBackground = new List<Sprite>();
    public Image gameBackground;
    public bool gameUpdate;
    public AudioSource levelAudio, clouds;

    private void Update()
    {
        Loading();
    }

    public void SetUpGame()
    {
        buttonIndex = 0;
        for (int i = 0; i < 3; i++)
        {
            FindObjectOfType<ChoiseOptions>().Options_Game[i].enabled = true;
            FindObjectOfType<ChoiseOptions>().GameLevels[i].SetActive(false);
            FindObjectOfType<ChoiseOptions>().LevelsScript[i].SetActive(false); 

        }  
    }

    public void PlayGame(int n)
    {
        levelAudio.Play();
        StartCoroutine(wait());
        IEnumerator wait()
        {
            cloud.Play("clouds");
            clouds.Play();
            yield return new WaitForSeconds(2f);
            loading.SetActive(true);
            index = n;
            isPlay = true;
            gameUpdate = true;
        }
    }

    private void ChangeGameBackground(int n)
    {
        switch (n)
        {
            case 0:
                
                gameBackground.sprite = spritesBackground[n];
                break;
            case 1:
                
                gameBackground.sprite = spritesBackground[n];
                break; 
            case 2:
                
                gameBackground.sprite = spritesBackground[n];
                break;
        }
    }

    void Loading()
    {
        if (isPlay)
        {
            loadingLogo.Rotate(0f, 0f, speed * Time.deltaTime);
            speed = (speed - loadings);
            if (speed<=0)
            {
                tittle.SetActive(false);
                loading.SetActive(false);
                buttonIndex = index;
                ChangeGameBackground(buttonIndex);
                isPlay = false;
                FindObjectOfType<ChoiseOptions>().Options();
                cloud.Play("cloudsOut");
                clouds.Play();
            }
        }
    }

}
