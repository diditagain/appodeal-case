using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
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
}
