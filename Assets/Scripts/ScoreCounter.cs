using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public int score = 0;
    public TMP_Text tMP_Text;
    public AudioSource audioSource;
    public ParticleSystem particleSystem;

    public void Start()
    {
        tMP_Text.text = "Score: " + score;
    }

    public void OnTriggerEnter(Collider other)
    {
        score++;
        Debug.Log("Score: " + score);
        tMP_Text.text = "Score: " + score;
        audioSource.PlayOneShot(audioSource.clip);
        Destroy(other.gameObject);
        particleSystem.Emit(1);
    }
}
