using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] tracks; // size 4

    int currentIndex = -1;

    void Awake()
    {
        if (source == null) source = GetComponent<AudioSource>();
    }

    public void PlayTrack(int index)
    {
        if (source == null || tracks == null) return;
        if (index < 0 || index >= tracks.Length) return;

        // se premi lo stesso bottone, riavvia (se vuoi invece toggle, dimmelo)
        currentIndex = index;

        source.Stop();
        source.clip = tracks[index];
        source.Play();
    }

    public void StopAll()
    {
        if (source == null) return;
        source.Stop();
        currentIndex = -1;
    }
}