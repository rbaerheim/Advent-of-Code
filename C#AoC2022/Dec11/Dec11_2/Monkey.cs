using System.Collections.Generic;
using System.Linq;

namespace Dec11_1;

class Monkey
{
    public int Id { get; private set; }
    public string[] Operation { get; set; }
    private readonly List<int> _currentItems = new();
    public IEnumerable<int> CurrentItems => _currentItems.AsReadOnly();
    public int Test { get; set; }
    public int MonkeyTrueId { get; set; }
    public int MonkeyFalseId { get; set; }
    public int inspectedItems { get; set; } = 0;


    public Monkey(int id, string[] operation, int test, int monkeyTrueId, int monkeyFalseId)
    {
        Id = id;
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

    public int operationOnItem(Monkey monkey, int index, int firstValue, string mathOperator, int secondValue)
    {
        int newValue;
        switch (mathOperator)
        {
            case "+":
                newValue = firstValue + secondValue;
                break;
            case "-":
                newValue = firstValue - secondValue;
                break;
            case "*":
                newValue = firstValue * secondValue;
                break;
            default:
                throw new Exception();
        }

        monkey._currentItems[index] = newValue;

        return newValue;

    }

    public void addToCurrentItems(int item)
    {
        _currentItems.Add(item);
    }

    public void removeFromCurrentItems(int item)
    {
        _currentItems.Remove(item);
    }
    public int getValue(int index)
    {
        return _currentItems[index];
    }
}
