using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(string sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public static void LoadSceneAddictice(string sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        }
    }
}
