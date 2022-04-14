using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI nome;
    public Dialogue[] nextDialogue;
    [SerializeField] GameObject dialogueBG;
    [SerializeField] int index = 0;
    [SerializeField] int maxIndex;
    bool escrevendo = false;
    public bool Escrevendo
    {
        get { return escrevendo; }
        set { escrevendo = value; }
    }
    private void Update()
    {
    }
    public void Dialogue()
    {
        if (index >= maxIndex)
        {
            GameObject.Find("Ella").GetComponent<Movement>().PodeAndar = true;
            dialogueBG.SetActive(false);
        }
        else { dialogueBG.SetActive(true); }

        NextDialogue();
    }
    private void NextDialogue()
    {
        if (index < maxIndex && escrevendo == false)
        {
            GameObject.Find("Ella").GetComponent<Movement>().PodeAndar = false;
            escrevendo = true;
            StartCoroutine(PrintDialogue());
            nome.text = nextDialogue[index].nome;            
        }     
        else 
        {
            return; 
        }       
    }
    IEnumerator PrintDialogue()
    {
        text.text = "";
        for (int i = 0;i < nextDialogue[index].texto.Length;i++)
        {
            
            text.text += nextDialogue[index].texto[i];
            yield return new WaitForSeconds(0.05f);
        }
        if (index < maxIndex)
        {
            index++;
        }
        escrevendo = false;
    }
}
