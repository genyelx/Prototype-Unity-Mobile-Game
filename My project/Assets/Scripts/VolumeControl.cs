using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSfx;

    void Start()
    {
        sliderMusic.value = music.volume;
        sliderSfx.value = sfx.volume;
    }
    
    public void ChangeVolumeMusic(float v)
    {
        music.volume = v;
    }
    
    public void ChangeVolumeSfx(float v)
    {
        sfx.volume = v;
    }
}
