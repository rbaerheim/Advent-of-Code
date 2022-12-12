using System.Collections.Generic;
using System.Linq;

namespace Dec11_1;

class Monkey
{
    public int Id { get; private set; }
    public List<int> CurrentItems { get; set; }
    public string Operation { get; set; }
    public int Test { get; set; }
    public int MonkeyTrueId { get; set; }
    public int MonkeyFalseId { get; set; }


    public Monkey(int id, List<int> currentItems, string operation, int test, int monkeyTrueId, int monkeyFalseId)
    {
        Id = id;
        CurrentItems = currentItems;
        Operation = operation;
        Test = test;
        MonkeyTrueId = monkeyTrueId;
        MonkeyFalseId = monkeyFalseId;
    }

    public int test(int worryLevel, int divisibleBy)
    {
        if (worryLevel % divisibleBy == 0)
        {
            return MonkeyTrueId;
        }
        return MonkeyFalseId;
    }

    public int operation(int firstValue, string mathOperator, int secondValue)
    {
        switch (mathOperator)
        {
            case "+":
                return firstValue + secondValue;
            case "-":
                return firstValue - secondValue;
            case "*":
                return firstValue * secondValue;
            case "/":
                return firstValue / secondValue;
            default:
                return default;
        }
    }

    public void addToCurrentItems(int item)
    {
        CurrentItems.Add(item);
    }

    public void removeFromCurrentItems(int item)
    {
        CurrentItems.Remove(item);
    }
}
