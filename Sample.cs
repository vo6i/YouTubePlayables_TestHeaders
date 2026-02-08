using UnityEngine;
using YTGameSDK; // Тянем базовое SDK YouTube

namespace DCLXVICLAN.Games.Playables 
{
    public class YTHandler : MonoBehaviour 
    {
        public YTGameWrapper wrapper;

        private void Awake() 
        {
            // Подписка на системные колбэки
            wrapper.SetOnPauseCallback(OnPauseReceived);
            wrapper.SetOnResumeCallback(OnResumeReceived);
        }

        public void SendReady() 
        {
            wrapper.FirstFrameReady();
            wrapper.GameReady();
        }

        private void OnPauseReceived() 
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }

        private void OnResumeReceived() 
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }
}


using UnityEngine;
using DCLXVICLAN.Games.Playables; // Твоё пространство имен

public class PlayerController : MonoBehaviour 
{
    private YTHandler _ytHandler;

    void Start() 
    {
        _ytHandler = FindObjectOfType<YTHandler>();
        
        // Теперь функции из твоего пространства имен доступны
        _ytHandler.SendReady();
    }
}

