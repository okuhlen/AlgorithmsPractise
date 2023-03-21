namespace PractiseAlgorithms.CodingQuestions;

//LeetCode Question: 724

/*Given an array of integers nums, calculate the pivot index of this array.

The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.

If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.

Return the leftmost pivot index.If no such index exists, return -1.*/

//NOTES: Researched what the answer is 
public class PivotIndexSolution
{
    public int PivotIndex(int[] nums)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        int left = 0;
        int right = 0;

        foreach (var num in nums)
        {
            right += num;
        }

        for (int a = 0; a <= nums.Length - 1; a++)
        {
            right -= nums[a];
            if (right == left)
            {
                return a;
            }
            left += nums[a];
        }

        return -1;
    }
}
