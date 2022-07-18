using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck_of_cards Deck = new Deck_of_cards();
            int count = 0;
            foreach (Card card in Deck) {
                count++;
                Console.WriteLine(count + " "  +  card.card_suit + " " + card.value);
           
            }


              

            Console.ReadLine();
        }

    }


    public class Card
    {
        public string card_suit { get; set; }
        public string value { get; set; }


        protected Dictionary<int, string> Dic_card_suit = new Dictionary<int, string>
           {
               { 1, "Heart"},
               { 2, "Diamond"},
               { 3, "Club"},
               { 4, "Spade"},

             };

        protected Dictionary<int, string> Dic_value = new Dictionary<int, string>
           {
               { 6, "Six"},
               { 7, "Seven"},
               { 8, "Eight"},
               { 9, "Nine"},
               { 10, "Ten"},
               { 11, "Jack"},
               { 12, "Queen"},
               { 13, "King"},
               { 14, "Ace"},
             };

        public Card()
        {

        }


        public Card(int card_suit, int value)
        {
            this.card_suit = Dic_card_suit[card_suit];
            this.value = Dic_value[value];

        }

        public void Show_card(Card _card)
        {
            Console.WriteLine(_card.value + " " + _card.card_suit);


        }

        public void Show_card()
        {
            Console.WriteLine(this.value + " " + this.card_suit);

        }


        public Card Get_card(int i, int j)
        {
            Card Tmp = new Card();
            Tmp.card_suit = Dic_card_suit[i];
            Tmp.value = Dic_value[j];
            return Tmp;


        }

    }




            public class Deck_of_cards : IEnumerable
    {
        protected List <Card> deck = new List<Card>(36);
       

        public Deck_of_cards()
        {
            Card Tmp = new Card();

            for (int i = 1; i < 5; i++)
            {
               
                for (int j = 6; j < 15; j++)
                {
                                     
                    deck.Add(Tmp.Get_card(i, j));

                }

            }
            Random RND = new Random();
            deck = deck.OrderBy(v => RND.Next()).ToList();

        }
        public IEnumerator GetEnumerator() => deck.GetEnumerator();


      




    }

}



