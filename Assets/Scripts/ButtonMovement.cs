using UnityEngine;
using DG.Tweening;
public class ButtonMovement : MonoBehaviour
{
    public static ButtonMovement instance;
    public GameObject ContinueAndQuit;
    // Start is called before the first frame update
    void Start()
    {
        ContinueAndQuit.SetActive(false);
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
}
