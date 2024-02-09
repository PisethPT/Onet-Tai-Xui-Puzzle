using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseOptions : MonoBehaviour
{
    public Button[] Options_Game;
    public GameObject[] GameLevels;
    public GameObject[] LevelsScript;
    public GameObject OptionPanel;
    private int optionIs;
    int n;
    public void Options()
    {
         n = FindObjectOfType<LevelLoading>().buttonIndex;
        switch (n)
        {
            case 0:

                Options_Game[0].enabled = true;
                Options_Game[1].enabled = false;
                Options_Game[2].enabled = false;
                optionIs = n;
                StartCoroutine(LoadingGotoGameOptions(optionIs));
                break;
            case 1:

                Options_Game[0].enabled = false;
                Options_Game[1].enabled = true;
                Options_Game[2].enabled = false;
                optionIs = n;
                StartCoroutine(LoadingGotoGameOptions(optionIs));
                break;
            case 2:

                Options_Game[0].enabled = false;
                Options_Game[1].enabled = false;
                Options_Game[2].enabled = true;
                optionIs= n;
                StartCoroutine(LoadingGotoGameOptions(optionIs));
                break;
        }
    }

        IEnumerator LoadingGotoGameOptions(int optionIs)
        {
            yield return new WaitForSeconds(2f);

            if (optionIs.Equals(0))
            {
                GameLevels[optionIs].SetActive(true);
                LevelsScript[optionIs].SetActive(true);
                OptionPanel.SetActive(false);
                FindObjectOfType<GameManager>().GetValueRandom();
                n = 0;
            }
            else if (optionIs.Equals(1))
            {
                GameLevels[optionIs].SetActive(true);
                LevelsScript[optionIs].SetActive(true);
                OptionPanel.SetActive(false);
                FindObjectOfType<Level1>().GetValueRandom();
                n = 0;
        }
            else if (optionIs.Equals(2))
            {
                GameLevels[optionIs].SetActive(true);
                LevelsScript[optionIs].SetActive(true);
                OptionPanel.SetActive(false);
                FindObjectOfType<Level3>().GetValueRandom();
                n = 0;
        }
        }
}
