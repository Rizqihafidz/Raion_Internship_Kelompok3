using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject optionPanel;


    void Update()
    {
        // testing
        if (GameObject.FindGameObjectsWithTag("Player") == null)
        {
            Restart();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Option();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuPlay()
    {
        SceneManager.LoadScene(2);
        animator.SetTrigger("FadeOut");
    }

    public void MenuQuit()
    {
        Application.Quit();
        animator.SetTrigger("FadeOut");
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void NextLevel()
    {
        animator.SetBool("Fadeout", true);
        Invoke("Next", 1);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        animator.SetBool("Fadeout", true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Option()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            optionPanel.SetActive(true);
        }
    }

    public void Resume()
    {
        optionPanel.SetActive(false);
    }

    public void Quit()
    {
        animator.SetBool("Fadeout", true);
        Application.Quit();
    }
}
