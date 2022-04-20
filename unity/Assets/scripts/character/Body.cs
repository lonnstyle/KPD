using UnityEngine;
public class Body : MonoBehaviour
{
    [SerializeField] SpriteRenderer bodySprite;

    public void SetColor(Color newColor) => bodySprite.color = newColor;


    private void OnEnable()
    {
        if (PlayerMovement.allBodies != null)
        {
            PlayerMovement.allBodies.Add(transform);
        }
    }

    public void Report()
    {
        Debug.Log("Reported");
        PlayerMovement.allBodies.RemoveAt(PlayerMovement.allBodies.Count - 1);
        Destroy(gameObject);
    }
}
