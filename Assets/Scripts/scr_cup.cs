using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_cup : MonoBehaviour
{
    void OntriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName:"S_Win");
        }
    }
}
