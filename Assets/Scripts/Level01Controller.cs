using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    private int _playerScore;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private Image _livesImage;

    private void Start()
    {
        scoreText.text = "SCORE 0";
    }
    public void AddPlayerScore(int score)
    {
        _playerScore += score;
        scoreText.text = "SCORE " + _playerScore;
    }
    
    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _liveSprites[currentLives];
    }
}
