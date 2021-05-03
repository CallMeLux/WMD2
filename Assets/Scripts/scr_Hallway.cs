using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_Hallway : MonoBehaviour
{
    public Text blobfishCaughtText;
    public GameObject enemy;
    public static int lives = 3;
    void Start()
    {
        SetLivesText();
    }
    void Update()
    {
        if (this.transform.position.y <= -2)
        {
        if (lives <= 1)
        {
        SceneManager.LoadScene(sceneName:"S_HubWorld");
        lives = 3;
        }
        else
        {
            SceneManager.LoadScene(sceneName:"S_WMD");
            lives = lives-1;
            SetLivesText();
        }
        }
    }
        void OnTriggerEnter (Collider other)
        {
            if (other.tag == "BlobFish")
            {
            if (lives <= 1)
            {
            SceneManager.LoadScene(sceneName:"S_HubWorld");
            }
            else
            {
            SceneManager.LoadScene(sceneName:"S_WMD");
            lives = lives-1;
            SetLivesText();
            }
            }
            if (other.tag == "Cup")
            {
            SceneManager.LoadScene(sceneName:"S_Win");
            }
        }
        void OnTriggerStay (Collider other)
    {
        scr_MrGrabs mrGrabs = enemy.GetComponent<scr_MrGrabs>();
        if (other.tag == "Wall")
        {
           Debug.Log("working");
           mrGrabs.chase = true; 
        }
    }
        void OnTriggerExit(Collider other)
        {
            scr_MrGrabs mrGrabs = enemy.GetComponent<scr_MrGrabs>();
            if (other.tag == "Wall")
            {
              mrGrabs.chase = false;
            }
        }
        
    public void SetLivesText()
    {
                blobfishCaughtText.text = "Lives: " + lives.ToString();
    }
}
