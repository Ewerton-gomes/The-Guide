using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SotaoManager : MonoBehaviour
{
    [SerializeField] GameObject chave;
    [SerializeField] GameObject chavecol;
    private void Start()
    {
        if (GameManager.Instance.ChavePorao == true)
        {
            chave.SetActive(false);
            chavecol.SetActive(false);
        }
    }
    void Update()
    {
        
    }
}
