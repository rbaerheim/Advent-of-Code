namespace Dec11_1;

class Monkey
{
    public int Id { get; set; }
    public List<int> CurrentItems { get; set; } = new();
    public string? Operation { get; set; }
    public string? Test { get; set; }

    public Monkey(int id, string operation, string test)
    {
        Id = id;
        Operation = operation;
        Test = test;
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
