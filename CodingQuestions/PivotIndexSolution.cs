namespace PractiseAlgorithms.CodingQuestions;

//LeetCode Question: 724

/*Given an array of integers nums, calculate the pivot index of this array.

The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.

If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.

Return the leftmost pivot index.If no such index exists, return -1.*/

//NOTES: I am not happy with this solution, I think I can improve it somehow. Will try think of a better way. 
public class PivotIndexSolution
{
    public int PivotIndex(int[] nums)
    {
        if (nums.Length <= 2)
        {
            return 0;
        }

        //to figure out what the pivot point is, we will calculate what the midpoint is.
        //then, update the midpoint by going 1 up or 1 down each iteration. 
        int midpoint = (int)(nums.Length / 2);
        midpoint = midpoint - 1;
        if (midpoint == 0) //if the midpoint ends up being the left edge of the array, we can only calculate whats on the right of the array
        {
            int sumOfLeftItems = 0;
            int sumOfRightItems = 0;
            for (int i = 1; i <= nums.Length - 1; i++)
            {
                sumOfRightItems += nums[i];
            }

            if (sumOfLeftItems == sumOfRightItems)
            {
                return midpoint;
            }
        }

        //if the midpoint is the right edge of the array, we can only calculate what is on the left of the array. 
        if (midpoint == (nums.Length - 1))
        {
            int sumOfRightItems = 0;
            int sumOfLeftItems = 0;

            for (int i = midpoint - 1; i <= 0; i--)
            {
                sumOfLeftItems += nums[i];
            }

            if (sumOfLeftItems == sumOfRightItems)
            {
                return 0;
            }
        }

        //this loop is responsible for summing up everything from the midpoint, till the end of the array
        //with each iteration, the midpoint is updated (1 up)
        for (int a = midpoint; a <= nums.Length - 1; a++)
        {

            int sumOfLeft = 0;
            for (int b = (midpoint + 1); b >= 0; b--)
            {
                sumOfLeft += nums[b];
            }

            int sumOfRight = 0;
            for (int c = (midpoint + 1); c <= nums.Length - 1; c++)
            {
                sumOfRight += nums[c];
            }

            if (sumOfLeft == sumOfRight)
            {
                return a + 1;
            }
        }

        //this loop is responsible for summing up everything from the midpoint till the start of the array. 
        //with each iteration, the midpoint is updated (1 down)
        for (int a = (midpoint + 1); a >= 0; a--)
        {

            int sumOfLeft = 0;
            for (int b = (midpoint + 1); b >= 0; b--)
            {
                sumOfLeft += nums[b];
            }

            int sumOfRight = 0;
            for (int c = (midpoint + 1); c <= nums.Length - 1; c++)
            {
                sumOfRight += nums[c];
            }

            if (sumOfLeft == sumOfRight)
            {
                return a + 1;
            }
        }

        return -1;

    }
}
