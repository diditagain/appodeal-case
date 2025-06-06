## Solitaire Stack

### What is it?

-----

*Solitaire Stack* is a stack and a move save system for card games. 
You can easily implement it in your game without hussle.

Project is based on just 4 scripts following MVC model. 

### Structure
-----

#### Game Manager

Our singleton class handles instantiation of scene. Since for now our game just implements the stacking and move tracking logic. It doesn't do anything other than Instantiating one controller, BoardController and holding data regardin our scene. 

```    public static GameManager Instance { get; private set; }

    [SerializeField] private BoardController _boardController;
    [SerializeField] private int _numberOfCards = 10;
    [SerializeField] private Button _undoButton;
    [SerializeField] private SetupData _setupData;

    void Start()
    {
        Debug.Log("GameManager initialized.");
        _boardController = Instantiate(_boardController);
        _boardController.SetBoard(_setupData);
        _boardController.OnBootCompleted.AddListener(StartGame);
        _undoButton.onClick.AddListener(_boardController.Undo);
    }
```

#### BoardController

Our longest script yet. Handles communication between *CardView*, *CardStackView* and  our scriptable object (model).

```
public class CardMoveModel
{
    public CardView Card;
    public CardStackView FromStack, ToStack;

    public CardMoveModel(CardView Card, CardStackView FromStack, CardStackView ToStack)
    {
        this.Card = Card;
        this.FromStack = FromStack;
        this.ToStack = ToStack;
    }
}

public class BoardController : MonoBehaviour
{
    private CardStackView[] _stacks;

    private Stack<CardMoveModel> _moveStack = new();

    private bool _boardSet;
    public UnityEvent<bool> OnBootCompleted;

    public void SetBoard(SetupData data)
    {
        _stacks = Instantiate(data.BoardPrefab).GetComponentsInChildren<CardStackView>();
        for (int i = 0; i < data.NumOfCards; i++)
        {
            CardView card = Instantiate(data.CardPrefab).GetComponent<CardView>();
            card.OnCardDropped.AddListener(AddCardToStack);
            card.SetCard(
                data.Suits[UnityEngine.Random.Range(0, data.Suits.Length)], 
                data.Colors[i % data.Colors.Length]);
            AddCardToStack(card, _stacks[i % _stacks.Length], _boardSet);
        }
        _boardSet = true;
        OnBootCompleted?.Invoke(_boardSet);
    }

    public void AddCardToStack(CardView card, CardStackView ToCardStack, bool registerMove=true)
    {
        var cardStack = ToCardStack.Cards;
        var fromStack = card.CardStack;

        card.transform.SetParent(ToCardStack.transform);
        card.transform.localPosition = cardStack.Count > 0 ? cardStack.Peek().transform.localPosition + new Vector3(-0.02f, -0.02f, -0.1f) : new Vector3(0, 0, -0.1f);
        cardStack.Push(card);
        card.CardStack = ToCardStack;
        if (!_boardSet)
            return;
        fromStack.Cards.Pop();
        if (registerMove)
        {
            RegisterMove(card, fromStack, ToCardStack);
        }
    }

    void RegisterMove(CardView Card, CardStackView FromStack, CardStackView ToStack)
    {
        var newMove = new CardMoveModel(Card, FromStack, ToStack);
        _moveStack.Push(newMove);
    }

    public void Undo()
    {
        if (_moveStack.TryPop(out var move))
        {
            AddCardToStack(move.Card, move.FromStack, false);
        }
    }
```
  
#### CardView

Referances: 
```
Camera cam;
private Vector3 _offset;
[SerializeField] private TextMeshPro _suitLabel;

public UnityEvent<CardView, CardStackView, bool> OnCardDropped = new UnityEvent<CardView, CardStackView, bool>();

public CardStackView CardStack; // Reference to the CardStack this card belongs to
private bool _isDragging = false;
Vector3 OriginalPosition;
SpriteRenderer SpriteRenderer;
Color Color;
```

I won't get into drag/drop functionality since it's pretty straightforward using Monobehavior's built in methods. That's one of the few parts where I let AI take the lead. And it did a good job. After we drop card on a stack, we invoke `OnCardDropped` event, which we subscribed on BoardController. 

Note: How safe or logical to subscribe to an event in a loop with possible of hundred iterations? With UnityEvents, I'd say it's pretty safe. 

#### CardStackView

A class just with a `Stack<>`. Holds the data of cards on that stack. Also used as a model for simplicity.

#### SetupData (ScriptableObject)

```
public class SetupData : ScriptableObject
{
    public int NumOfCards;
    public GameObject CardPrefab, BoardPrefab;
    public string[] Suits;
    public Color[] Colors;
} 
```

Holds referances our prefabs, possible suits/colors and number of cards to instantiate. We pass it through GameManager for conveniance. If the project gets bigger, it makes sense to make it an addressable and fetch directly on BoardController.


### Roadmap
-----

- [ ] Planning to split data from scripts. Scriptable Objects will be used for Views and Models alike. 
- [ ] Use addressables for assets
- [ ] Tweening for animations

### AI Usage in Project
------
I used AI quite a lot (Copilot for auto complete, Mistral for code generation and search (questions, mostly.)), both as a coder and as a search engine. Mostly the latter. 
I think we all must admit that using AI is something reflexive at this point. Since I also code other stuff than Unity (through roo code with custom API) I'm well aware we're far away from trusting it. Regardless, it's an essential part of programming even in these terms.

I think what I'm happy about is (at least for now) I realize AI tools are really good at boring part of my job (Drag and drop being a major example). So for now, I have nothing to complain.