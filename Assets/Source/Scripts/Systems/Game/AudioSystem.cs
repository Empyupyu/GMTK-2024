using GarbageScaler.GameSignals;
using Kuhpik;
using Supyrb;
using UnityEngine;
using UnityEngine.Audio;

namespace GarbageScaler.Systems.Game
{
    public class AudioSystem : GameSystem
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioMixer audioMixer;

        public override void OnInit()
        {
            Signals.Get<ChangeMusicVolumeSignal>().AddListener(SetMusicVolume);
            Signals.Get<ChangeSoundsVolumeSignal>().AddListener(SetSoundsVolume);
            
            SetMusicVolume(0.3f);
            SetSoundsVolume(0.3f);
        }
        
        private void SetMusicVolume(float value)
        {
            game.MusicVolume = value;
            audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
        }
        
        private void SetSoundsVolume(float value)
        {
            game.SoundsVolume = value;
            audioMixer.SetFloat("Sounds", Mathf.Log10(value) * 20);
        }
    }
}