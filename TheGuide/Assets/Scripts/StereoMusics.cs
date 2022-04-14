using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereoMusics : MonoBehaviour
{
    private int musicsCount = 0;
    [SerializeField] private GameObject ligh;
    [SerializeField] private AudioSource[] musics;
    public void PlayNext()
    {
        this.GetComponent<InteractTxt>().texto = "Próxima música";
        ligh.SetActive(true);
        if (musicsCount >= 5)
        {
            musics[musicsCount-1].Stop();
            musicsCount = 0;
        }
        musics[musicsCount].Play();
        musicsCount++;
        if (musics[musicsCount-2].isPlaying)
        {
            musics[musicsCount - 2].Stop();
        }        
    }
    public void StopMusic()
    {
        this.GetComponent<InteractTxt>().texto = "Ligar";
        ligh.SetActive(false);
        foreach (var music in musics)
        {
            music.Stop();
        }
    }
}
