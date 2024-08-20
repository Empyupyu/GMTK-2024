using System.Collections;
using Kuhpik;
using UnityEngine;

namespace GarbageScaler.Systems.Game
{
    public class AudioSystem : GameSystem
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioClip _drive;
        [SerializeField] private AudioClip _back;
        [SerializeField] private AudioClip _idle;

        private CarControl _carControl;
        
        public override void OnInit()
        {
            _carControl = FindObjectOfType<CarControl>();
            _carControl.OnMove += DriveSound;
            _carControl.OnMoveBack += BackDriveSound;
            _carControl.OnIdle += IdleDriveSound;
        }

        private void IdleDriveSound()
        {
            if (musicSource.clip != null && musicSource.clip.Equals(_idle)) return;
            
            musicSource.clip = _idle;
            musicSource.loop = true;
            musicSource.Play();
        }

        private void BackDriveSound()
        {
            if (_isBackSoundPlay) return;
            if (musicSource.clip != null && musicSource.clip.Equals(_back)) return;
            
            // musicSource.clip = _back;
            // musicSource.loop = true;
            // musicSource.Play();
            StartCoroutine(BackSound());
        }

        private bool _isBackSoundPlay;
        
        private IEnumerator BackSound()
        {
            _isBackSoundPlay = true;
            AudioSource.PlayClipAtPoint(_back, _carControl.transform.position);

            yield return new WaitForSeconds(_back.length);
            _isBackSoundPlay = false;
        }

        private void DriveSound()
        {
            if (musicSource.clip != null && musicSource.clip.Equals(_drive)) return;
            
            musicSource.clip = _drive;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}