using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private BoardController _boardController;
    [SerializeField] private int _numberOfCards = 10;
    [SerializeField] private Button _undoButton;
    [SerializeField] private SetupData _setupData;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log("GameManager initialized.");
        _boardController = Instantiate(_boardController);
        _boardController.SetBoard(_setupData);
        _boardController.OnBootCompleted.AddListener(StartGame);
        _undoButton.onClick.AddListener(_boardController.Undo);
    }

    private void StartGame(bool success)
    {
        /// Does nothing for now, might (and most likely) be useful in the future.
        /// Keeping a list of controllers and checking for each of them makes more sense as game gets bigger
        if (success)
        {
            _undoButton.interactable = true;
        } else
        {
            Debug.LogError("CRITICAL ERROR");
        }
    }
}

