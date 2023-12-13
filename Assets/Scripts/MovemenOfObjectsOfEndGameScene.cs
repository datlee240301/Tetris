using UnityEngine;
using DG.Tweening;
public class MovemenOfObjectsOfEndGameScene : MonoBehaviour
{
    public Vector3 sizeToTrans;
    public Vector3 posToMove;
    public GameObject GameOver;
    public GameObject Green;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.transform.DOScale(sizeToTrans, 5f);
        Green.transform.DOMove(posToMove, 3f);
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
