using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public static bool paused = false;
    [SerializeField] Animator animCont,animQuit,animOp;
    [SerializeField] GameObject PauseUI;
    int index = 0;
    [SerializeField] int max;
    bool keydown;
   
    void Update()
    {
        
        if (paused)
        {
            Anim();
            Select();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
                Anim();
                Select();
            }
        }        
    }
    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    void Anim()
    {
        switch (index)
        {
            case 0:
                //animCont.SetBool("Selected", false);
                animQuit.SetBool("Selected", true);
                //animOp.SetBool("Selected", false);
                if (Input.GetButtonDown("Submit"))
                {
                    Application.Quit();
                }
                break;
                /*
            case 1:
                animCont.SetBool("Selected", false);
                animQuit.SetBool("Selected", false);
                animOp.SetBool("Selected", true);
                break;
            case 2:
                animCont.SetBool("Selected", false);
                animQuit.SetBool("Selected", true);
                animOp.SetBool("Selected", false);
                break;
                */
        }
    }
    void Select()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keydown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < max)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = max;
                    }
                }
            }
            keydown = true;
        }
        else
        {
            keydown = false;
        }
    }
}
