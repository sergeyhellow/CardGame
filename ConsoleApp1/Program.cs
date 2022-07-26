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

            Game Game = new Game(Deck);

         
            Game.ShowCPUCard();
            Console.WriteLine("\n");
            Game.ShowPlayerCard();


            //Game.Card_Value();
            Game.GameVS_CPU();

            Game.ShowCPUCard();
            Console.WriteLine("\n");
           // Game.ShowPlayerCard();
      

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


    public class Game {

        public List<Card> Player_1 = new List<Card>();
        public List<Card> CPU = new List<Card>();

        protected Dictionary<string,int> Dic_value_ = new Dictionary<string, int>
           {
               { "Six", 6},
               { "Seven", 7},
               {  "Eight", 8},
               {  "Nine", 9},
               {  "Ten", 10},
               {  "Jack", 11},
               {  "Queen", 12},
               {  "King", 13},
               { "Ace", 14},
             };

        public Game(Deck_of_cards deck)

        {

            int count = 0;
            foreach (Card card in deck)
            {
                count++;
                if (count % 2 == 0)
                {
                    this.Player_1.Add(card);
                }
                else
                    this.CPU.Add(card);


            }
        }

        public void ShowPlayerCard()
        {
            Console.WriteLine("Player Deck: ");
            int count = 0;
            foreach (Card card in Player_1)
            {
                count++;
                Console.WriteLine(count + " " + card.card_suit + " " + card.value);

            }

        }

        public void ShowCPUCard()
        {
            Console.WriteLine("CPU Deck: ");
            int count = 0;
            foreach (Card card in CPU)
            {
                count++;
                Console.WriteLine(count + " " + card.card_suit + " " + card.value);

            }

        }

        public void ShowDeckCard(Deck_of_cards deck)
        {
            Console.WriteLine("Deck: ");
            int count = 0;
            foreach (Card card in deck)
            {
                count++;
                Console.WriteLine(count + " " + card.card_suit + " " + card.value);

            }

        }



        public void Card_Value()
        {
            Console.WriteLine(" Card_Value CPU Deck: ");


            Console.WriteLine(Dic_value_[CPU[0].value]);

        }
    

       
           public void GameVS_CPU()
           {

               Console.WriteLine("Lets Play\n");

                             
               int _num;
               int _num_;
               bool end = true;
               Random RND = new Random();
               while (end) {
                Console.WriteLine("\n");
                Console.WriteLine("Get num of your card \n");
                   _num_= Convert.ToInt32(RND.Next(0, this.CPU.Count()));
                   _num = Convert.ToInt32(Console.ReadLine()) - 1;

                bool WtF = true; // тут немного запутался, не мог зайти в цикл без переменной , пришлось создавать.  

                while (WtF) // если тут вместо переменно1 ставить выражение- программа сыпалась.
                    {
                    if (_num > Player_1.Count())
                    {
                        Console.WriteLine("Get num of your card again, there is no card with this number \n");
                        _num = Convert.ToInt32(Console.ReadLine()) - 1;
                    }

                    if (_num <= Player_1.Count())
                    { WtF = false; }
                    }


                
                Console.WriteLine("Your card: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Player_1[_num].Show_card();
                    Console.ResetColor();

                    Console.WriteLine("CPU card: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    CPU[_num_].Show_card();
                    Console.ResetColor();


                    if (Dic_value_[CPU[_num_].value] < Dic_value_[Player_1[_num].value] || Dic_value_[CPU[_num_].value] == Dic_value_[Player_1[_num].value])
                    {
                        Player_1.Add(CPU[_num_]);
                        CPU.RemoveAt(_num_);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Player take the card");
                        Console.ResetColor();

                    }
                    else
                    {
                        CPU.Add(Player_1[_num]);
                        Player_1.RemoveAt(_num);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CPU take the card");
                        Console.ResetColor();

                    }
                Console.WriteLine("\n");
                Console.WriteLine("click enter \n");
                Console.ReadLine();
                Console.Clear();
                ShowPlayerCard();
             
                if (this.Player_1.Count() == 0)
                {
                    end = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CPU WINS!!!");
                    Console.ResetColor();
                }
                if (this.CPU.Count() == 0)
                {
                    end = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("PLAYER WINS!!!");
                    Console.ResetColor();
                }




                if (this.Player_1.Count() == 0 || this.CPU.Count() == 0)
                { end = false; 
                }

            

            }

           

           }




    }


}


    
    






