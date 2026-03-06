using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioClip backgroundSound;
    public AudioClip winSound;
    public AudioClip deathSound;
    public AudioClip collectableSound;

    private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    private void Play(AudioClip audio){
        AudioSource.PlayClipAtPoint(
            audio,
            Camera.main.transform.position, 
            0.5f
        );
    }
    public void PlayCollectableSound(){
       Play(collectableSound);
    }
    public void PlayWinSound(){
        Play(winSound);
    }
    public void PlayDeathSound(){
        Play(deathSound);
    }
    public void PlayBackgroundSound(){
        audioSource.clip = backgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
