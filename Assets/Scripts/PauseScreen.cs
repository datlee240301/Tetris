using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public static PauseScreen instance;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
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
