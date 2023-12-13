using DG.Tweening;
using UnityEngine;

public class MovemenOfObjectsOfMainScene : MonoBehaviour
{
    public static MovemenOfObjectsOfMainScene instance;
    public GameObject PauseScreen;
    public Vector3 pauseScreenPos;
    public Vector3 pauseScreenPosAfter;
    //public GameObject ContinueAndQuit;
    // Start is called before the first frame update
    void Start()
    {
        //ContinueAndQuit.gameObject.SetActive(false);
        //  PauseScreen.gameObject.SetActive(false);    
    }

    private void Awake() {
        if (instance == null) {
            instance = this;    
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseScreenMove() {
        PauseScreen.transform.DOMove(pauseScreenPos, 0.5f);
    }

    public void PauseScreenMoveAfter() {
        PauseScreen.transform.DOMove(pauseScreenPosAfter, 0.5f);
    }
}
