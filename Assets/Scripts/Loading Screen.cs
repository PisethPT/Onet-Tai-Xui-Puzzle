using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject scroll;
    bool isLoad = true;
    float time = 0;

    private void Update()
    {
        if (isLoad)
        {
            time += 0.1f;
            scroll.transform.GetChild(0).GetComponent<Image>().fillAmount += time;
            
            if(time >= 1)
            {
                gameObject.SetActive(false);

            }
            isLoad = false;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        isLoad = true;
        
    }
}
