using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerRaycastManager : MonoBehaviour
{
    RaycastHit2D hit;
    GameObject enemy;
    [SerializeField] Animator crossfade;
    [SerializeField] private GameObject quadro, pintura;
    [SerializeField] private string[] names;
    private void Start()
    {
        enemy = GameManager.Instance.Search("EnemyTest").gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (SceneManager.GetActiveScene().name == "Quarto")
            {
                if (enemy != null)
                {
                    enemy.SetActive(!enemy.activeSelf);
                }
            }
        }
        Interacts();
        if (SceneManager.GetActiveScene().name == "Quarto")
        {
            StereoRaycast();
            BedRaycast();
            DialogueCat();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("Porta"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Corredor");
                }               
            }
        }
        if (SceneManager.GetActiveScene().name == "Corredor")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("PortaBanheiro"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Banheiro");
                }
                else if (ReturnCastName("PortaQuarto"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Quarto");
                }
                else if (ReturnCastName("EscadaSala"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Sala");
                }
                else if (ReturnCastName("EscadaSotao"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Sotao");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Banheiro")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("Porta"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Corredor");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Sotao")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("EscadaCorredor"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Corredor");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Sala")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("EscadaCorredor"))
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Corredor");
                }
                if (ReturnCastName("Porta") && this.GetComponent<PlayerManager>().ChavePorao)
                {
                    GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadLevel("Porao");
                }
            }
        }
    }
    private void StereoRaycast()
    {
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.E))
        {
            try
            {
                if (ReturnCastName("StereoON"))
                {
                    GameObject.Find("StereoON").GetComponent<StereoMusics>().PlayNext();
                }
                if (ReturnCastName("StereoOFF"))
                {
                    GameObject.Find("StereoON").GetComponent<StereoMusics>().StopMusic();
                }
            }
            catch { }
        }
    }
    private void BedRaycast()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 4.5f);
        try
        {
            if (hit.collider.CompareTag("Bed"))
            {
                if (Mathf.Abs(ReturnPlayerRB().velocity.y) < 0.001f)
                {
                    ReturnPlayerRB().AddForce(new Vector2(0,ReturnPlayer().GetComponent<PlayerControler>().JumpForce),ForceMode2D.Impulse);
                }
            }
            else {  }
        }
        catch { }
    }
    private void DialogueCat()
    {       
        if (Input.GetKeyDown(KeyCode.E))
        {
            hit = Physics2D.Raycast(transform.position, -Vector2.up, 4.5f);
            if (ReturnCastName("Gato"))
            {
                hit.collider.GetComponent<DialogueSystem>().Dialogue();
            }
        }
        else { return; }
    }
    private bool ReturnCastName(string name)
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, -Vector2.up, 4.5f);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_hit.collider.GetComponent<Transform>().name == name)
            {
                return true;
            }
        }       
        return false;
    }
    private Rigidbody2D ReturnPlayerRB()
    {
        return GameObject.Find("Ella").GetComponent<Rigidbody2D>();
    }
    private GameObject ReturnPlayer()
    {
        return GameObject.Find("Ella");
    }
    private void Interacts()
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, -Vector2.up, 4.5f);
        try
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_hit.collider.GetComponent<ObjectSound>())
                {
                    _hit.collider.GetComponent<ObjectSound>().objSound.Play();
                }
            }
        }catch{ }

        try
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("Pintura") && this.GetComponent<PlayerManager>().Pintou == false)
                {
                    StartCoroutine(Crossfade());
                }
            }
        }catch { }
        /*
        try
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ReturnCastName("ChaveCol"))
                {
                    this.GetComponent<PlayerManager>().ChavePorao = true;
                    GameManager.Instance.ChavePorao = true;
                    GameManager.Instance.DesativaChavePorao();
                }
            }
        }catch { }
        */
    }
    IEnumerator Crossfade()
    {
        this.GetComponent<PlayerManager>().Pintou = true;
        crossfade.SetBool("Start",true);
        yield return new WaitForSeconds(0.5f);
        quadro.SetActive(false);
        pintura.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        crossfade.SetBool("Start", false);
        
    }
}
