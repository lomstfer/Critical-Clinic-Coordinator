using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {
    [SerializeField] Image image;
    [SerializeField] GameObject gameOverText;

    float alphaWant = 0;

    void Start() {
        MoneyManager.Instance.GameOverEvent += OnGameOver;
    }

    void Update() {
        if (MoneyManager.Instance.GameOver) {
            image.color = new Color(0, 0, 0, Mathf.Lerp(image.color.a, alphaWant, Time.deltaTime));
        }
    }

    void OnGameOver() {
        StartCoroutine(GameOverTicking());
    }

    IEnumerator GameOverTicking() {

        int times = Mathf.RoundToInt(MoneyManager.Instance.GameOverTotalTickTime / MoneyManager.Instance.GameOverTickTime);

        float increasePerTick = 1f / (float)times;
        for (int i = times; i > 0; i--) {
            alphaWant += increasePerTick;
            yield return new WaitForSeconds(MoneyManager.Instance.GameOverTickTime);
        }

        yield return new WaitForSeconds(2f);

        gameOverText.SetActive(true);

        yield return new WaitForSeconds(8f);

        LoadMenu();
    }

    void LoadMenu() {
        SceneChangeManager.Instance.LoadScene("Menu");
    }
}
