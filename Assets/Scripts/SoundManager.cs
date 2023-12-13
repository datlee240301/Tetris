using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource Sound;
    public AudioClip rotateSound;
    public AudioClip moveSound;
    public AudioClip score;
    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateSound() {
        Sound.PlayOneShot(rotateSound);
    }

    public void MoveSound() {
        Sound.PlayOneShot(moveSound);
    }

    public void Score() {
        Sound.PlayOneShot(score);
    }
}
