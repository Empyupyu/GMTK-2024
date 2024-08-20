using GarbageScaler.GameSignals;
using Kuhpik;
using Supyrb;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GarbageScaler.UIScreens
{
    public class PauseMenuUIScreen : UIScreen
    {
        [SerializeField] private Slider musicSlider;
        [FormerlySerializedAs("volumeSlider")] [SerializeField] private Slider soundsSlider;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;

        public bool IsOpened { get; set; }
        
        public override void Subscribe()
        {
            base.Subscribe();
            musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
            soundsSlider.onValueChanged.AddListener(OnSoundsVolumeValueChanged);
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        public override void Open()
        {
            IsOpened = true;
            musicSlider.value = Bootstrap.Instance.GameData.MusicVolume;
            soundsSlider.value = Bootstrap.Instance.GameData.SoundsVolume;
            base.Open();
        }

        public override void Close()
        {
            IsOpened = false;
            base.Close();
        }

        private void OnMusicValueChanged(float value)
        {
            Signals.Get<ChangeMusicVolumeSignal>().Dispatch(value);
        }
        
        private void OnSoundsVolumeValueChanged(float value)
        {
            Signals.Get<ChangeSoundsVolumeSignal>().Dispatch(value);
        }
        
        private void OnResumeButtonClicked()
        {
            Close();
        }
        
        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}