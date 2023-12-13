using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PlayAgain() {
        SceneManager.LoadScene("MainScreen");
    }

    public void PauseGame() {
        MovemenOfObjectsOfMainScene.instance.PauseScreenMove();
        StartCoroutine(WaitForAppear(0.5f));
        StartCoroutine(PauseAfterDelay(0.5f));
    }

    IEnumerator PauseAfterDelay(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 0f;
    }

    IEnumerator WaitForAppear(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        ButtonMovement.instance.ContinueAndQuit.SetActive(true);
    }

    public void Continue() {
        MovemenOfObjectsOfMainScene.instance.PauseScreenMoveAfter();
        ButtonMovement.instance.ContinueAndQuit.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainScene() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
