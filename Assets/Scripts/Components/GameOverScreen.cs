using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {
    [SerializeField] Image image;
    [SerializeField] GameObject gameOverText;

    void Start() {
        MoneyManager.Instance.GameOverEvent += OnGameOver;
    }

    void OnGameOver() {
        StartCoroutine(GameOverTicking());
    }

    IEnumerator GameOverTicking() {

        int times = Mathf.RoundToInt(MoneyManager.Instance.GameOverTotalTickTime / MoneyManager.Instance.GameOverTickTime);

        float increasePerTick = 1f / (float)times;
        for (int i = times; i > 0; i--) {
            image.color += new Color(0, 0, 0, increasePerTick);
            yield return new WaitForSeconds(MoneyManager.Instance.GameOverTickTime);
        }

        yield return new WaitForSeconds(2f);

        gameOverText.SetActive(true);

        yield return new WaitForSeconds(5f);

        LoadMenu();
    }

    void LoadMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
