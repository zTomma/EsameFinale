using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBacker : MonoBehaviour
{
    public void GoBackToAspoc()
    {
        SceneManager.LoadScene("Aspoc");
    }
}