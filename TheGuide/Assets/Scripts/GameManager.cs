using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager instance = new GameManager();
    private bool chavePorao = false;

    public bool ChavePorao
    {
        get { return chavePorao; }
        set { chavePorao = value; }
    }
    private GameManager()
    {
        
    }
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public void DesativaChavePorao()
    {
        GameObject.Find("ChavePorao").gameObject.SetActive(false);
    }
    public void KillDontDestroy()
    {
        DontDestroy[] objs = GameObject.FindObjectsOfType<DontDestroy>();
        foreach (DontDestroy obj in objs)
        {
            obj.Die();
        }
    }
    public GameObject Search(string name)
    {
        return GameObject.Find(name);
    }
}
