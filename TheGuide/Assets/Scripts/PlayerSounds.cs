using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource att1, att2;
    private int attSound;
    public void JumpSound()
    {
        jump.Play();
    }
    public void AttackSound()
    {
        attSound = UnityEngine.Random.Range(0,2);
        switch (attSound)
        {
            case 0:
                att1.Play();
                break;
            case 1:
                att2.Play();
                break;
        }
    }
}
