using YTGameSDK; // Пространство имен из YouTube SDK Wrapper

public class GameStateController : MonoBehaviour {
    public YTGameWrapper ytGameWrapper;

    void Start() {
        // 1. Сигнал о готовности первого кадра (загрузочный экран)
        ytGameWrapper.FirstFrameReady(); 

        // 2. Сигнал о полной готовности игры к взаимодействию
        ytGameWrapper.GameReady();
    }
}
void Awake() {
    // Подписываемся на системные события YouTube
    ytGameWrapper.SetOnPauseCallback(PauseGame);
    ytGameWrapper.SetOnResumeCallback(ResumeGame);
}

public void PauseGame() {
    Time.timeScale = 0f; // Останавливает физику и Update (дельту времени)
    AudioListener.pause = true; // Выключает весь звук в игре
    Debug.Log("YouTube поставил игру на паузу");
}

public void ResumeGame() {
    Time.timeScale = 1f; // Возвращает игру в нормальный режим
    AudioListener.pause = false; // Включает звук обратно
    Debug.Log("Игра возобновлена");
}

