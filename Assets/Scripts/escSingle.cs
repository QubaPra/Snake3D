using UnityEngine;
using UnityEngine.SceneManagement;

public class escSingle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Return()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    


}