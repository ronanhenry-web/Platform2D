using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FruitBehaviour : MonoBehaviour
{
    public FruitData Data;
    public GameObject CollectedPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(Data.Score);
            Destroy(gameObject);
            Instantiate(CollectedPrefab, transform.position, Quaternion.identity);
        }
    }
}
