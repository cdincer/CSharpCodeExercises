
namespace CSharpCodeExercises
{    //Put single functions in this class for testing
     //So it can be isolated from working code.
     #region Test Area

    public class TestGroundClass
    {
        int carrier = 0;
        public int ClimbStairs(int n)
        {
            WaysOfClimb(n, 0);
            return carrier;
        }

        public int WaysOfClimb(int n, int curr)
        {
            if (curr > n)
                return 0;

            if (curr == n)
            {
                carrier++;
                return 1;
            }


            int[] steps = new int[] { 1, 2 };

            for (int i = 0; i < steps.Length; i++)
            {
                if (curr + steps[i] <= n)
                {
                    WaysOfClimb(n, steps[i] + curr);
                }
            }

            return 1;
        }


        #endregion
    }
}