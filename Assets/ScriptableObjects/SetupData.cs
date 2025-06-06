using UnityEngine;

[CreateAssetMenu(menuName = "Game/Setup Data")]
public class SetupData : ScriptableObject
{
    public int NumOfCards;
    public GameObject CardPrefab, BoardPrefab;
    public string[] Suits;
    public Color[] Colors;
}
