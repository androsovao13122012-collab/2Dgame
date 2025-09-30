using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartBT()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitBT()
    {
        Application.Quit();
    }
}
