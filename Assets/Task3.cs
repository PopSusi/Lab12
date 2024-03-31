using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;
using System.Runtime.CompilerServices;

namespace Cards
{
        public enum Rank {Jack = 0, Queen, King, Ace}
        public enum Suit {Spades = 0, Clubs, Hearts, Diamonds}
}

public struct Card
{
    public Card(Rank rank, Suit Suit)
    {
        myRank = rank;
        mySuit = Suit;
    }
    public Rank myRank { get; }
    public Suit mySuit { get; }
    public override string ToString() => $"({myRank} of {mySuit})";
}
public class Task3 : MonoBehaviour
{
    List<Card> Deck = new List<Card>();
    HashSet<Card> Hand = new HashSet<Card>();
    HashSet<Card> Suit = new HashSet<Card>();
    int rounds;
    // Start is called before the first frame update
    void Awake()
    {
        CreateDeck();
        CreateHand();
        Game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateDeck()
    {
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Deck.Add(new Card((Rank)i, (Suit)j));
            }
        }
    }
    void CreateHand()
    {
        int temp;
        bool won;
        for (int i = 0; i < 4; i++)
        {
            temp = Random.Range(0, Deck.Count - 1);
            Hand.Add(Deck[temp]);
            Deck.RemoveAt(temp);
        }
    }
    private void Game()
    {
        bool won;
        if (rounds == 0)
        {
            Debug.Log($"I made the initial deck and draw. My hand is: {PrintHand()}. {CompareHand(out won)}");
        } else
        {
            Debug.Log($"{Discard()}. My hand is: {PrintHand()}. {CompareHand(out won)}");
        }
        if (!won)
        {
            Game();
        }
        rounds++;
    }

    private string PrintHand(){
        string outputString = "";
        foreach(Card card in Hand)
        {
            outputString += card.ToString() + ", ";
        }
        return outputString;
    }
    private string CompareHand(out bool won)
    {
        int[] matches = new int[4];
        foreach(Card card in Hand)
        {
            matches[(int) card.mySuit] += 1;
        }
        foreach(int i in matches)
        {
            if(i > 3)
            {
                won = true;
                return "The game is WON.";
            }
        }
        won = false;
        return "This is not a winning hand.";
    }
    private string Discard()
    {
        List<Card> tempHand = new List<Card>(Hand);
        Card gone;
        int deleteIndex = Random.RandomRange(0, 3);
        gone = tempHand[deleteIndex];
        tempHand[deleteIndex] = Deck[Random.Range(0, Deck.Count - 1)];
        Hand = new HashSet<Card>(tempHand);
        return $"I discarded {gone.ToString()} and draw {tempHand[deleteIndex].ToString()}";
    }
}
