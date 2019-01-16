using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/reveal-cards-in-increasing-order/
class CardsIncreasingOrder
{
    static void Main(string[] args)
    {
        int[] input = new int[]{ 17,13,11,2,3,5,7};
        Array.Sort(input);
        int index = 0;
        LinkedList<int> outputIndex = new LinkedList<int>();
        List<int> tempOrdered = new List<int>();
        List<CardMapping> mappingAns = new List<CardMapping>();
        for(int i = 0; i < input.Length; i++)
        {
            outputIndex.AddLast(index);
            index++;
        }

        bool isActionOne = true;
        while(outputIndex.Count > 0)
        {
            if(isActionOne) 
                tempOrdered.Add(outputIndex.First());
            else
                outputIndex.AddLast(outputIndex.First());
            outputIndex.RemoveFirst();
            isActionOne = !isActionOne;
        }
        //when reach here, finalOutput has re - ordered indexes
        Console.Write("input: ");
        foreach (int i in input)
            Console.Write(i + " ");
        Console.WriteLine();

        Console.Write("index: ");
        foreach (int i in tempOrdered)
            Console.Write(i + " ");
        Console.WriteLine();

        foreach (int i in tempOrdered)
            mappingAns.Add(new CardMapping(tempOrdered[i], input[i]));

        mappingAns.Sort((x, y) => x.index.CompareTo(y.index));
        foreach(CardMapping i in mappingAns)
            Console.Write(i.cardValue + " ");

        Console.ReadKey();
    }
}

struct CardMapping
{
    public int index, cardValue;
    public CardMapping(int i, int j)
    {
        this.index = i;
        this.cardValue = j;
    }
}



