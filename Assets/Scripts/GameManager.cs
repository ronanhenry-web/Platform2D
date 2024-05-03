using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int MaxHealth;
    public GameObject Player;
    public TMP_Text FruitText;
    public HealthBarBehaviour HealthBar;

    public UnityEvent OnDeath;

    private int _currentHealth;
    private int _score = 0;

    private void Awake()
    {
        // Si jamais on charge une 2e scene
        // avec un autre GameManager
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void AddScore(int score)
    {
        _score += score;
        FruitText.text = $"Score: {_score}";
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        HealthBar.SetHealth(_currentHealth, MaxHealth);
        if (_currentHealth <= 0)
        {
            Player.GetComponent<PlayerBehaviour>().Die();
            OnDeath?.Invoke();
        }
        else
        {
            Player.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
