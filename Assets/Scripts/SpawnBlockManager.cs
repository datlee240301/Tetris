using UnityEngine;

public class SpawnBlockManager : MonoBehaviour
{
    public static SpawnBlockManager instance;
    public GameObject[] BlockPrefabs;
    private bool isStart = false;
    private Vector2 nextBlockPos = new Vector2(16.5f, 13.5f);
    private GameObject CurrentBlock, NextBlock;
    // Start is called before the first frame update
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    void Start()
    {
        IntBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IntBlocks() {
        if (!isStart) {
            isStart = true;
            CurrentBlock = Instantiate(BlockPrefabs[Random.Range(0, BlockPrefabs.Length)], transform.position, Quaternion.identity);
            NextBlock = Instantiate(BlockPrefabs[Random.Range(0, BlockPrefabs.Length)], nextBlockPos, Quaternion.identity);
            NextBlock.GetComponent<TetrisBlock>().enabled = false;
        } 
        else {
            NextBlock.transform.localPosition = transform.position;
            CurrentBlock = NextBlock;
            NextBlock.GetComponent <TetrisBlock>().enabled = true;
            NextBlock = Instantiate(BlockPrefabs[Random.Range(0, BlockPrefabs.Length)], nextBlockPos, Quaternion.identity);
            NextBlock.GetComponent<TetrisBlock>().enabled = false;
        }
        
    }
}
