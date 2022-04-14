using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunciontionMenu : MonoBehaviour
{
    [SerializeField] AudioSource selectSound;
    private bool clicou = false;
    private void Update()
    {
        if (clicou == false && Input.GetAxis("Vertical") != 0)
        {
            clicou = true;
        }
    }
    public void EventPlaySound(AudioClip whichSound)
    {
        if (clicou)
        {
            selectSound.PlayOneShot(whichSound);
        }
        else { }
        
    }
}
