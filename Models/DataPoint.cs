namespace PractiseAlgorithms.Models;

public class DataPoint : IComparable<DataPoint>
{
    public DataPoint(int point)
    {
        Value = point;
    }
    public int Value { get; set; }

    public int CompareTo(DataPoint? other)
    {
        if (other is null)
            throw new Exception("Cannot compare a null value against this current value");

        if (Value > other.Value)
            return 1;

        if (Value < other.Value)
            return -1;

        return 0;
    }
}