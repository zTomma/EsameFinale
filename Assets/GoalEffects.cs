using UnityEngine;

public class GoalEffects : MonoBehaviour
{
    [Header("Refs")]
    public AudioSource audioSource;
    public ParticleSystem confetti;

    [Header("Settings")]
    public string ballTag = "Ball";
    public float cooldown = 0.5f; // evita doppie attivazioni

    private float lastTimePlayed = -999f;

    private void Reset()
    {
        // Auto-piglia l'AudioSource se sta sullo stesso oggetto
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ballTag)) return;

        if (Time.time - lastTimePlayed < cooldown) return;
        lastTimePlayed = Time.time;

        // Suono
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.Play();
        }

        // Coriandoli
        if (confetti != null)
        {
            confetti.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            confetti.Play();
        }
    }
}
