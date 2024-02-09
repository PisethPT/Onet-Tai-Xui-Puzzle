using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viewLevel : MonoBehaviour
{
    public GameObject scrollBar;
    float scrollPosition;
    float[] position;
    void Update()
    {
        position = new float[transform.childCount];
        float dis = 1f/(position.Length-1f);
        for(int i = 0; i < position.Length; i++)
        {
            position[i] = dis * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPosition = scrollBar.GetComponent<Scrollbar>().value;
        }else
        {
            for(int i = 0;i < position.Length; i++)
            {
                if(scrollPosition < position[i] + (dis/2) && scrollPosition> position[i] - (dis/2))
                {
                    scrollBar.GetComponent <Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, position[i], 0.1f);
                }
            }
        }


        for(int i = 0; i<position.Length; i++)
        {
            if (scrollPosition < position[i] +(dis/2) && scrollPosition > position[i] - (dis/2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.3f);
                for(int j = 0; j < position.Length; j++)
                {
                    if(j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.5f, 0.5f), 0.4f);
                    }
                }
            }
        }
    }



}
