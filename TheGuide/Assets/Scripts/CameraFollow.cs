using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cmCam;
    private void Start()
    {
        SetConfiner();
    }
    void Update()
    {
        cmCam.Follow = GameObject.Find("Ella").gameObject.transform;
        SetConfiner();
    }
    private void SetConfiner()
    {
        foreach (PolygonCollider2D confiner in Object.FindObjectsOfType<PolygonCollider2D>())
        {
            if (confiner.gameObject.name == SceneManager.GetActiveScene().name + "Confiner")
            {
                //confiner.gameObject.SetActive(true);
                cmCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner.GetComponent<PolygonCollider2D>();
            }
            else if(confiner.gameObject.name != SceneManager.GetActiveScene().name + "Confiner")
            {
                //confiner.gameObject.SetActive(false);
                Destroy(confiner.gameObject);
            }
        }
    }
}
