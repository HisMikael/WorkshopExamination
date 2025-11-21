using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    [SerializeField] int buildIndex;

    public void SwapToScene()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
