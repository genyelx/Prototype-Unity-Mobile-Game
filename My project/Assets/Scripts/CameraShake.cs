using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float time)
    {
        Vector3 positionOriginal = transform.localPosition;

        float timePassed = 0.0f;

        float randomX = Random.Range(0f, 100f);
        float randomY = Random.Range(0f, 100f); 

        float shakeVelocity = 25f;

        while(timePassed < time)
        {
            float porcentFinished = timePassed / time;

            float NoiseX = Mathf.PerlinNoise(randomX + Time.time * shakeVelocity, 0f);
            float NoiseY = Mathf.PerlinNoise(0f, randomY + Time.time * shakeVelocity);

            float xBase = Mathf.Lerp(0.35f, 0.4f, NoiseX);
            float yBase = Mathf.Lerp(0.8f, 1.2f, NoiseY);

            float x = xBase;
            float y = yBase;


            transform.localPosition = new Vector3(x, y, positionOriginal.z);

            timePassed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = positionOriginal;
    }
}
