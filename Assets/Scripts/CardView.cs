using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CardView : MonoBehaviour
{
    Camera cam;
    private Vector3 _offset;
    [SerializeField] private TextMeshPro _suitLabel;

    public UnityEvent<CardView, CardStackView, bool> OnCardDropped = new UnityEvent<CardView, CardStackView, bool>();

    public CardStackView CardStack; // Reference to the CardStack this card belongs to
    private bool _isDragging = false;
    Vector3 OriginalPosition;
    SpriteRenderer SpriteRenderer;
    Color Color;

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main camera not found. Please ensure there is a camera tagged as 'MainCamera'.");
        }
        SpriteRenderer = GetComponent<SpriteRenderer>();

        Color = SpriteRenderer.color;
    }

    public void SetCard(string label, Color color)
    {
        _suitLabel.text = label;
        _suitLabel.color = color;
    }

    #region  Drag-Drop Functionality
    void OnMouseDown()
    {
        _isDragging = true;
        OriginalPosition = transform.position; // Store the original position of the card
        SpriteRenderer.color = Color.green;
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (_isDragging)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) + _offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, -9);
        }
    }
    #endregion
    void OnMouseUp()
    {
        if (_isDragging)
        {
            _isDragging = false;
            /// Check if the card is dropped on another object ==AI + Modifications==
            Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
            bool successfulMove = false;

            foreach (var hit in hits)
            {
                if (hit.gameObject != gameObject && hit.gameObject.GetComponent<CardStackView>() != null)
                {
                    CardStackView targetStack = hit.gameObject.GetComponent<CardStackView>();
                    if (targetStack == CardStack) break;
                    successfulMove = MakeMove(targetStack);
                    break;
                }
            }
            SpriteRenderer.color = Color;
            if (!successfulMove)
                transform.position = OriginalPosition; // Reset to original position if not dropped on a card
        }
    }

    private bool MakeMove(CardStackView destinationStack)
    {
        OnCardDropped?.Invoke(this, destinationStack, true);
        return true;
        /// Can be extended depending on game design
    }
    
    private void OnDestroy() {
        // Unsubscribe from the event to prevent memory leaks
        OnCardDropped.RemoveAllListeners();
    }
}


