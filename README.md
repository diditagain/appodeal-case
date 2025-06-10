## Solitaire Stack

### What is it?

-----

*Solitaire Stack* is a stack and a move save system for card games. 
You can easily implement it in your game without hussle.

Project is based on just 4 scripts following MVC model. 

![GIF](https://github.com/diditagain/appodeal-case/blob/main/Assets/Unity_VjYiunuTn2.gif))


### Structure
-----

Diagram for project (Mermaid code generated using Gemini API)

[![](https://mermaid.ink/img/pako:eNp9Vdtu4jAQ_RXLT1SFKtwK-GGlFvYmLUtV2j7sslqZxKTZJjayndIWwbfv2IEkTlN4iC9zZjwzZ2bYYl8EDBPsx1SpSURDSZMFR_CzN-grTdiUchoyibaZwPxa6O9SUBmMBddSxDGTBF27Fw6Yp8mSydlqDBBFUMS1I055IK5TrQUHM3Z1xIrpdD2hmhI0P24LwDn6zpWm3Gek7G4ZcLWhT6xxVr6aayp1zZWx0FgKESOV-j5T6gDZLXg5L5VgK7kBd_wniNOEOzf7h4htfv9xMIl4ZlZGkF32BjyFyykwEu_f5xpCJ8h4VvZ5xq-F0GORrGOmWUDQPY_06-dnxvXeYPdOgExbvxt5FlEAHycJV0FgHLkT1qmG2RvnkQ-bphsQuhP5uWk9Q5KFkdJMmjgcs7clQWF0XGP0ixTJwWT1Nbt3zN5D4TTqGcofqVCTRvoHXbKYoDv2oqdMPd5IUYbkr1b4c8xEaiJpGEY8rHLSQjMZgYDGN0JFOjI1_cB8LWS3DJqvZaTZLeMBk6Z73LPjj4gFAOxSYdP411BaghsoNkE1MxjyzffMLZSpSBWbiA1v1AognFrB_dq9nkIr5SwW7ARMaQjaxJvRVM5LDTWF5rZs_TAgio4wkL2L4Ad2PrRflLdj-2ea1E-g7NkbyVZ0mc2Q2fIfUFZG2MY5DZlDaYHpjI9yt59nrKgDiUdRTVby_n-fFZJXdFmSd8uHxXp-bJxaRO5DedC3Wp_eDTgCUxaqmcbRG1OZShVi1FxqCcpMKpRNxNN6B5VvlAcxqJiJg8yUTGCYnVAt2Ibpp4yi4KsoTKUtxtNPFvmGcSCNi_ZFhZs4lFGAiZYpa-KEyYSaI7a0LLB-BK8WmMA2oPJpgRd8Bzpryn8JkRzVpEjDR0xWNFZwStcwbNnhPza_lbbjxyLlGpN2z7NGMNniFzj2-xedXq_neR4sILxs4ldMWp2L0eVgNBp6ncHQa_fb3cGuid_sw97FqHvZaw9Gw-HAG3SH_c7uPyzHc40?type=png)](https://mermaid.live/edit#pako:eNp9Vdtu4jAQ_RXLT1SFKtwK-GGlFvYmLUtV2j7sslqZxKTZJjayndIWwbfv2IEkTlN4iC9zZjwzZ2bYYl8EDBPsx1SpSURDSZMFR_CzN-grTdiUchoyibaZwPxa6O9SUBmMBddSxDGTBF27Fw6Yp8mSydlqDBBFUMS1I055IK5TrQUHM3Z1xIrpdD2hmhI0P24LwDn6zpWm3Gek7G4ZcLWhT6xxVr6aayp1zZWx0FgKESOV-j5T6gDZLXg5L5VgK7kBd_wniNOEOzf7h4htfv9xMIl4ZlZGkF32BjyFyykwEu_f5xpCJ8h4VvZ5xq-F0GORrGOmWUDQPY_06-dnxvXeYPdOgExbvxt5FlEAHycJV0FgHLkT1qmG2RvnkQ-bphsQuhP5uWk9Q5KFkdJMmjgcs7clQWF0XGP0ixTJwWT1Nbt3zN5D4TTqGcofqVCTRvoHXbKYoDv2oqdMPd5IUYbkr1b4c8xEaiJpGEY8rHLSQjMZgYDGN0JFOjI1_cB8LWS3DJqvZaTZLeMBk6Z73LPjj4gFAOxSYdP411BaghsoNkE1MxjyzffMLZSpSBWbiA1v1AognFrB_dq9nkIr5SwW7ARMaQjaxJvRVM5LDTWF5rZs_TAgio4wkL2L4Ad2PrRflLdj-2ea1E-g7NkbyVZ0mc2Q2fIfUFZG2MY5DZlDaYHpjI9yt59nrKgDiUdRTVby_n-fFZJXdFmSd8uHxXp-bJxaRO5DedC3Wp_eDTgCUxaqmcbRG1OZShVi1FxqCcpMKpRNxNN6B5VvlAcxqJiJg8yUTGCYnVAt2Ibpp4yi4KsoTKUtxtNPFvmGcSCNi_ZFhZs4lFGAiZYpa-KEyYSaI7a0LLB-BK8WmMA2oPJpgRd8Bzpryn8JkRzVpEjDR0xWNFZwStcwbNnhPza_lbbjxyLlGpN2z7NGMNniFzj2-xedXq_neR4sILxs4ldMWp2L0eVgNBp6ncHQa_fb3cGuid_sw97FqHvZaw9Gw-HAG3SH_c7uPyzHc40)

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

Note: How safe or logical to subscribe to an event in a loop with possible of hundred iterations? With UnityEvents, I'd say it's pretty safe. Plus, I already unsub from object if it gets destroyed.

#### CardStackView

A class just with a `Stack<>`. Holds the data of cards on that stack. Also used as the model for simplicity.

#### SetupData (ScriptableObject)

```
public class SetupData : ScriptableObject
{
    public int NumOfCards;
    public GameObject CardPrefab, BoardPrefab;
    public string[] Suits;
    public Color[] Colors;
    public Vector2 CardOffsetOnStack;
} 
```

Holds referances our prefabs, possible suits/colors and number of cards to instantiate. We pass it through GameManager for conveniance. If the project gets bigger, it makes sense to make it an addressable and fetch directly on BoardController.


### Roadmap
-----

- [x] Planning to split data from scripts. Scriptable Objects will be used for Views and Models alike. (Already did afterwards, as project gets bigger, we may create bigger).
- [ ] Object pooling cards when we need to recycle them. 
- [ ] Move undo system to controller from GameManager singleton. For now making another script for it makes project bloat.
- [ ] Use addressables for assets (If project gets big). May reduce load time of game. 
- [ ] Tweening for undo animation.
- [ ] Centralize events (using EventBus). If we're to create more events, it will be easier to keep track of different events in one place.

### AI Usage in Project
------
I used AI quite a lot (Copilot and Qwen), both as a coder and as a search engine. 
I think we all must admit that using AI tools should be something reflexive at this point. Since I also code other stuff than Unity (through roo code with custom API) I'm well aware we're far away from fully trusting it. Regardless, it's an essential part of programming even in these terms.

#### Example Prompts
- "I want to drag and drop a Unity2D object and be able detect if it's in collision with a certain object. How can I achieve this?"

- (Using RooCode with Google API) "I have a unity project. Fnctionality is: Stack and undo system for a solitaire like game. Game doesn't have a design, a purpose or something. Just to show my capabilities. Here are the files. Take a look at them and give me the mermaid code for structure."

I think what I'm happy about is; (at least for now) AI tools are really good at boring part of my job (Drag and drop being a major example). So for now, I have nothing to complain.

Note: I DID NOT use AI to write this README. However, this doesn't mean I won't in the future. Since this is one of the first interactions with the Dev team, I wanted to keep my writing as close to my real communication as possible.  
