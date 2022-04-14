using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //int selectNum = 0;
    [SerializeField] Animator animPlay;
    [SerializeField] Animator animQuit;
    [SerializeField] Animator animTuto;
    [SerializeField] AudioSource start;
    bool tutori = false;
    [SerializeField] GameObject tutorialImage;
    [SerializeField] int index = -1;
    [SerializeField] int max;
    bool keydown;
    void Start()
    {
        Cursor.visible = false;
        GameManager.Instance.KillDontDestroy();
    }

    // Update is called once per frame
    void Update()
    {
        Select();
        anim();
    }
    void anim()
    {
        switch (index)
        {
            case 0:
                animPlay.SetBool("Selected",true);
                animQuit.SetBool("Selected", false);
                animTuto.SetBool("Selected", false);
                if (Input.GetButtonDown("Submit"))
                {
                    start.Play();
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Quarto");
                }
                break;
            case 1:
                animQuit.SetBool("Selected", true);
                animPlay.SetBool("Selected", false);
                animTuto.SetBool("Selected", false);
                if (Input.GetButtonDown("Submit"))
                {
                    start.Play();
                    Application.Quit();
                }
                break;
            case 2:
                animTuto.SetBool("Selected", true);
                animPlay.SetBool("Selected", false);
                animQuit.SetBool("Selected", false);
                if (Input.GetButtonDown("Submit"))
                {
                    start.Play();
                    tutorialImage.SetActive(true);
                    tutori = true;
                }
                if (Input.GetButtonDown("Cancel"))
                {
                    start.Play();
                    tutorialImage.SetActive(false);
                    tutori = false;
                }
                break;
        }
    }
    void Select()
    {
        if (tutori == false)
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
                        else { index = 0; }
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        if (index > 0)
                        {
                            index--;
                        }
                        else { index = max; }
                    }
                }
                keydown = true;

            }
            else { keydown = false; }
        }
        
    }
}
