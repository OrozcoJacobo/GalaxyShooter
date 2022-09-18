using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    private int _playerScore;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private Image _livesImage;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Button _restartLevel;
    [SerializeField] private Button _mainMenu;
    

    private void Start()
    {
        _scoreText.text = "SCORE 0";
        _gameOverText.gameObject.SetActive(false);
        _restartLevel.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(false);
    }
    public void AddPlayerScore(int score)
    {
        _playerScore += score;
        _scoreText.text = "SCORE " + _playerScore;
    }
    
    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _liveSprites[currentLives];
        if(currentLives <= 0)
        {
            _gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicketRoutine());
            _restartLevel.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(true);
        }
    }

    IEnumerator GameOverFlicketRoutine()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BossDefeat()
    {
        Debug.Log("GameOver");
    }
}
