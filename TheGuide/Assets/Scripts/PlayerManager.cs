using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public bool corredor = false;
    bool pintou;
    bool chavePorao = false;
    private Vector2 nextPos;
    RaycastHit2D hit;
    public bool Pintou
    {
        get { return pintou; }
        set { pintou = value; }
    }
    public bool ChavePorao
    {
        get
        {
            return chavePorao;
        }
        set { chavePorao = value; }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Corredor") // NÃO IMPORTANTE
        {
            corredor = true;
        }
        if (SceneManager.GetActiveScene().name == "Quarto" && corredor) // NÃO IMPORTANTE
        {
           // Debug.Log("Já esteve no corredor");
        }
        /*
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.activeSceneChanged -= SetPosition;
            SceneManager.activeSceneChanged -= PlayerSortOrder;
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Menu");
        }
        */
    }
    private void Start()
    {
        SceneManager.activeSceneChanged += SetPosition;
        SceneManager.activeSceneChanged += PlayerSortOrder;
    }
    private void SetPosition(Scene atual, Scene proxima)
    {
        transform.position = nextPos;
    }
    private void PlayerSortOrder(Scene cena1,Scene cena2)
    {
        if (SceneManager.GetActiveScene().name == "Quarto")
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 16;
        }
        if (SceneManager.GetActiveScene().name == "Corredor")
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 8;
        }
        if (SceneManager.GetActiveScene().name == "Banheiro")
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 8;
        }
        if (SceneManager.GetActiveScene().name == "Sotao")
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 16;
        }
        if (SceneManager.GetActiveScene().name == "Sala")
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 7;
        }
        if (SceneManager.GetActiveScene().name == "Cozinha")
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 8;
        }
    }

    private void GetNextPosition(Collider2D collision)
    {
        nextPos = collision.GetComponent<DoorPosition>().position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        try
        {
            GetNextPosition(collision);
        }
        catch { }
    }
}
