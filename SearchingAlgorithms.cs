namespace PractiseAlgorithms;

internal class SearchingAlgorithms
{
    public int BinarySearch(int itemToSearch, params int[] numbers)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left <= right)
        {
            var midpoint = (left + right) / 2;
            if (numbers[midpoint] == itemToSearch)
            {
                return midpoint;
            }

            if (itemToSearch > numbers[midpoint])
            {
                left = midpoint + 1;
            } else
            {
                right = midpoint - 1;
            }
        }

        return -1; //to indicate nothing was found
    }


}
