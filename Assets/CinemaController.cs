using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class CinemaController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Transform roomLightsParent;
    public float fadeDuration = 1.5f;

    Light[] roomLights;
    float[] startIntensities;
    bool started;

    void Awake()
    {
        roomLights = roomLightsParent.GetComponentsInChildren<Light>(true);
        startIntensities = new float[roomLights.Length];
        for (int i = 0; i < roomLights.Length; i++)
            startIntensities[i] = roomLights[i].intensity;
    }

    public void StartCinema()
    {
        Debug.Log("CLICK -> StartCinema chiamata");

        if (started) return;
        started = true;

        if (videoPlayer != null) videoPlayer.Play();
        else Debug.LogWarning("VideoPlayer NON assegnato");

        StartCoroutine(FadeLights(0f, fadeDuration));
    }

    IEnumerator FadeLights(float target, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float k = Mathf.Clamp01(t / duration);

            for (int i = 0; i < roomLights.Length; i++)
                roomLights[i].intensity = Mathf.Lerp(startIntensities[i], target, k);

            yield return null;
        }
    }
}