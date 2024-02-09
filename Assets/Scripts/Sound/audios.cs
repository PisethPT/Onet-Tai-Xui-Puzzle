using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audios : MonoBehaviour
{
    public AudioSource[] sources;
    bool isFrame = true;
    public Slider[] sliders;
   // public Animator animator;
    [SerializeField] private Image icon;
    public Sprite[] sprites;
    public GameObject AudioPanel;
    public void musicSlider(float value)
    {
       // float volumn = value * sliders[0].value;
       // sources[1].volume = volumn;
       // sources[2].volume = volumn;
       // print("volumn: " + volumn);
    }    
    public void soundSlider(float value)
    {
        float volumn = value * sliders[0].value;
        sources[0].volume = volumn;
        if (volumn > 0)
            icon.sprite = sprites[0];
        else if (volumn <= 0)
            icon.sprite = sprites[1];
    }

    public void closeSound()
    {
        isFrame = !isFrame;
        if (isFrame)
        {
           // animator.Play("soundIdle");
           AudioPanel.SetActive(false);
        }else if (!isFrame)
        {
            // animator.Play("soundAnimate");
            AudioPanel.SetActive(true);
        }
    }
}
