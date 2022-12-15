using System.Collections.Generic;
using System.Linq;

namespace Dec11_1;

class Monkey
{
    public Int64 Id { get; private set; }
    public string[] Operation { get; set; }
    private readonly List<Int64> _currentItems = new();
    public IEnumerable<Int64> CurrentItems => _currentItems.AsReadOnly();
    public int Test { get; set; }

    public Int64 MonkeyTrueId { get; set; }
    public Int64 MonkeyFalseId { get; set; }
    public Int64 inspectedItems { get; set; } = 0;


    public Monkey(Int64 id, string[] operation, int test, Int64 monkeyTrueId, Int64 monkeyFalseId)
    {
        Id = id;
        Operation = operation;
        Test = test;
        MonkeyTrueId = monkeyTrueId;
        MonkeyFalseId = monkeyFalseId;
    }

    public Int64 test(Int64 worryLevel, Int64 divisibleBy)
    {
        if (worryLevel % divisibleBy == 0)
        {
            return MonkeyTrueId;
        }
        return MonkeyFalseId;
    }

    public Int64 operationOnItem(Monkey monkey, int index, Int64 firstValue, string mathOperator, Int64 secondValue, Int64 lcm)
    {
        Int64 newValue;
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

        newValue = newValue % lcm;

        monkey._currentItems[index] = newValue;

        return newValue;
    }

    public void addToCurrentItems(Int64 item)
    {
        _currentItems.Add(item);
    }

    public void removeFromCurrentItems(Int64 item)
    {
        _currentItems.Remove(item);
    }
    public Int64 getValue(int index)
    {
        return _currentItems[index];
    }

    public Int64 getGCD(Monkey monkey)
    {
        Int64 result = 1;

        var list = monkey._currentItems;
        if (list.Count() == 0)
        {
            return result;
        }
        result = list[0];

        for (int i = 1; i < list.Count(); i++)
        {
            result = gcdTwoNumbers(list[i], result);

            if (result == 1)
            {
                return 1;
            }
        }
        return result;
    }

    public Int64 gcdTwoNumbers(Int64 a, Int64 b)
    {
        if (a == 0)
        {
            return b;
        }
        return gcdTwoNumbers(b % a, a);
    }

    public Int64 productOfList(Monkey monkey)
    {
        Int64 result = 1;

        var list = monkey._currentItems;
        if (list.Count() == 0)
        {
            return result;
        }
        result = list[0];
        for (int i = 1; i < list.Count(); i++)
        {
            result = result * list[i];
        }

        return result;
    }

    public Int64 leastCommonMultiple(Monkey monkey)
    {
        return monkey.Test;
    }
}
