using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game Play");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
