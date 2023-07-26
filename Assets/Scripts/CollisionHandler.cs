using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    bool playerIsAlive = true;

    [SerializeField] float invokeTime = 1f;

    void OnCollisionEnter(Collision other)
        {
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("It's a friendly obsatcle!");
                    break;
                case "Finish":
                    //Debug.Log("Yo, you got to the finish!");
                    if (playerIsAlive == true)
                        {
                            LoadNextLevel();
                        }
                    break;
                default:
                    playerIsAlive = false;
                    StartCrashSequence();
                    break;
            }
        }

    void StartCrashSequence()
    {
        // todo SFX lejátszása becsapódásnál
        // todo particle effect becsapódásnál
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();

        Invoke("ReloadLevel", invokeTime);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(currentSceneIndex());
    }

    void LoadNextLevel()
    {
        // todo SFX lejátszása becsapódásnál
        // todo particle effect becsapódásnál
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();

        Invoke("SceneLoader", invokeTime);
    }

    void SceneLoader()
    {
        int nextSceneIndex = currentSceneIndex() + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    static int currentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex; //az éppen aktív szint számát kéri be és ezt adja vissza mikor meghívjuk valahol
    }
}
