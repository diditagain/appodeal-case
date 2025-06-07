using UnityEngine;

[CreateAssetMenu(menuName = "Game/Setup Data")]
public class SetupData : ScriptableObject
{
    public int NumOfCards;
    public GameObject CardPrefab, BoardPrefab;
    public string[] Suits;
    public Color[] Colors;

    private void OnValidate() {
        if (NumOfCards < 0)
        {
            NumOfCards = 0;
            Debug.LogWarning("Number of cards cannot be negative. Resetting to 0.");
        }

        if (Suits == null || Suits.Length == 0)
        {
            Debug.LogWarning("Suits array is empty. Please provide at least one suit.");
        }

        if (Colors == null || Colors.Length == 0)
        {
            Debug.LogWarning("Colors array is empty. Please provide at least one color.");
        }
    }
}
