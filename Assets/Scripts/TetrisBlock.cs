using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisBlock : MonoBehaviour {
    public float previousTime;
    public float fallTime = 0.9f;
    public static int height = 20;
    public static int width = 10;
    public Vector3 rotationPoint;
    private static Transform[,] grid = new Transform[width, height];
    float isPressHorizontal = 0.1f;
    float isPressDown = 0.0005f;
    float timeToRepeatPress = 0.2f;
    float timeToMoveHorizontal = 0f;
    float timeToMoveDown = 0f;
    float timeToPress = 0;
    bool isMoveHorizontal = false;
    bool isMoveDown = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ControlBlock();
        if(CheckForEndGame()) {
            EndGame();
        }
    }

    public void ControlBlock() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (isMoveHorizontal) {
                if (timeToPress < timeToRepeatPress) {
                    timeToPress += Time.deltaTime;
                    return;
                }
                if (timeToMoveHorizontal < isPressHorizontal) {
                    timeToMoveHorizontal += Time.deltaTime;
                    return;
                }
            } else {
                isMoveHorizontal = true;
            }
            timeToMoveHorizontal = 0;
            transform.position += new Vector3(1, 0, 0);
            FindObjectOfType<SoundManager>().MoveSound();
            if (!ValidMove()) transform.position -= new Vector3(1, 0, 0);
        } 
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            if(isMoveHorizontal) {
                if(timeToPress < timeToRepeatPress) {
                    timeToPress += Time.deltaTime;
                    return;
                }
                if (timeToMoveHorizontal < isPressHorizontal) {
                    timeToMoveHorizontal += Time.deltaTime;
                    return;  
                }
            } else {
                isMoveHorizontal = true;
            }
            timeToMoveHorizontal = 0;
            transform.position -= new Vector3(1, 0, 0);
            FindObjectOfType<SoundManager>().MoveSound();
            if (!ValidMove()) transform.position -= new Vector3(-1, 0, 0);
        } 
        else if (Input.GetKey(KeyCode.DownArrow) || Time.time - previousTime > fallTime) {
            if (isMoveDown) {
                if (timeToPress < timeToRepeatPress) {
                    timeToPress += Time.deltaTime;
                    return;
                }
                if (timeToMoveDown < isPressDown) {
                    timeToMoveDown += Time.deltaTime;
                    return;
                }
            } else {
                isMoveDown = true;
            }
            timeToMoveHorizontal = 0;
            transform.position += new Vector3(0, -1, 0);
            FindObjectOfType<SoundManager>().MoveSound();
            if (!ValidMove()) {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                SpawnBlockManager.instance.IntBlocks();
            }
            previousTime = Time.time;
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            FindObjectOfType<SoundManager>().RotateSound();
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove()) {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow) ||
                Input.GetKeyUp(KeyCode.DownArrow)) {
            isMoveHorizontal = false;
            isMoveDown = false;
            timeToMoveHorizontal = 0;
            timeToMoveDown = 0;
            timeToPress = 0;
        }
    }

    void CheckForLines() {
        for (int i = height - 1; i >= 0; i--) {
            if (FullLines(i)) {
                StartCoroutine(WaitForDeleteLine(i));
            }
        }
    }

    bool FullLines(int i) {
        for (int j = 0; j < width; j++) {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i) {
        for (int j = 0; j < width; j++) {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        FindObjectOfType<ScoreManager>().SetScore();
        FindObjectOfType<SoundManager>().Score();  
    }

    IEnumerator WaitForDeleteLine(int i) {
        yield return new WaitForSeconds(1f);
        DeleteLine(i);
        RowDown(i);
    }

    void RowDown(int i) {
        for (int y = i; y < height; y++) {
            for (int j = 0; j < width; j++) {
                if (grid[j, y] != null) {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid() {
        foreach (Transform children in transform) {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove() {
        foreach (Transform children in transform) {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height) {
                return false;
            }
            if (grid[roundedX, roundedY] != null) {
                return false;
            }
        }
        return true;
    }

    public bool CheckForEndGame() {
        for (int x = 0; x < width; x++) {
            if (grid[x, height - 2] != null) {
                return true;
            }
        }
        return false;
    }

    public void EndGame() {
        SceneManager.LoadScene("EndGame");
    }
}
