using System;
using System.Collections.Generic;
using System.Linq;

namespace Neetcode150
{
    public class DpOneNeet
    {
        #region Climbing Stairs
        /*
        You are climbing a staircase. It takes n steps to reach the top.
        Each time you can either climb 1 or 2 steps. 
        In how many distinct ways can you climb to the top?

        
        Example 1:

        Input: n = 2
        Output: 2
        Explanation: There are two ways to climb to the top.
        1. 1 step + 1 step
        2. 2 steps

        Example 2:
        Input: n = 3
        Output: 3
        Explanation: There are three ways to climb to the top.
        1. 1 step + 1 step + 1 step
        2. 1 step + 2 steps
        3. 2 steps + 1 step

        https://leetcode.com/problems/climbing-stairs/
        n = 38 16 / 45 testcases passed
        n = 44 21 / 45 testcases passed
        */
        //House Robber problems have a similar way of solving the question.
        public int ClimbStairs(int n)
        {
            int one = 1;
            int two = 1;

            for (int i = 0; i < n - 1; i++)
            {
                int temp = one + two;
                one = two;
                two = temp;
            }

            return two;
        }
        #endregion
        #region Min Cost Climbing Stairs
        /*
        You are given an integer array cost where cost[i] is the cost of ith step on a staircase. 
        Once you pay the cost, you can either climb one or two steps.
        You can either start from the step with index 0, or the step with index 1.
        Return the minimum cost to reach the top of the floor.

        Example 1:
        Input: cost = [10,15,20]
        Output: 15
        Explanation: You will start at index 1.
        - Pay 15 and climb two steps to reach the top.
        The total cost is 15.

        Example 2:
        Input: cost = [1,100,1,1,1,100,1,1,100,1]
        Output: 6
        Explanation: You will start at index 0.
        - Pay 1 and climb two steps to reach index 2.
        - Pay 1 and climb two steps to reach index 4.
        - Pay 1 and climb two steps to reach index 6.
        - Pay 1 and climb one step to reach index 7.
        - Pay 1 and climb two steps to reach index 9.
        - Pay 1 and climb one step to reach the top.
        The total cost is 6.

        Constraints:

            2 <= cost.length <= 1000
            0 <= cost[i] <= 999

        https://leetcode.com/problems/min-cost-climbing-stairs/
        */
        //Space optimized
        public int MinCostClimbingStairs(int[] cost)
        {
            for (int i = cost.Length - 3; i >= 0; i--)
            {
                //This point is reachable by the previous two.
                cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
            }

            //Two starting points only places left to check
            return Math.Min(cost[0], cost[1]);
        }
        #endregion
        #region House Robber
        /*
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, 
        the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected 
        and it will automatically contact the police if two adjacent houses were broken into on the same night.
        Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

        Example 1:
        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        Total amount you can rob = 1 + 3 = 4.

        Example 2:
        Input: nums = [2,7,9,3,1]
        Output: 12
        Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
        Total amount you can rob = 2 + 9 + 1 = 12.

        Constraints:

            1 <= nums.length <= 100
            0 <= nums[i] <= 400

        https://leetcode.com/problems/house-robber/
        Test Cases:
        [2,1,1,2] 40 / 70 testcases passed
        */
        //For around 400 variables. The memory usage difference between these two are as follows: DP array store: 40.09MB Neetcode 2 variable store : 39.99MB
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            var dp = new Dictionary<int, int>();
            dp[0] = nums[0];
            dp[1] = nums[1];
            dp[2] = nums[2] + nums[0];

            for (int i = 3; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + nums[i];
            }

            return Math.Max(dp[nums.Length - 1], dp[nums.Length - 2]);
        }
        public int RobNeet(int[] nums)
        {
            int rob1 = 0;
            int rob2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }
            return rob2;
        }
        #endregion
        #region House Robber 2
        /*
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically 
        contact the police if two adjacent houses were broken into on the same night.
        Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

        Example 1:
        Input: nums = [2,3,2]
        Output: 3
        Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.

        Example 2:
        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        Total amount you can rob = 1 + 3 = 4.

        Example 3:
        Input: nums = [1,2,3]
        Output: 3

        Constraints:

            1 <= nums.length <= 100
            0 <= nums[i] <= 1000

        Test Cases:
        nums= [2,7,9,3,1] 48 / 75 test cases passed
        nums = [1] 73/75 test cases passed

        https://leetcode.com/problems/house-robber-ii/
        */
        //52 ms on March 04th 2024
        public int Rob2(int[] nums)
        {

            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            return Math.Max(cycles(nums, 0, nums.Length - 1), cycles(nums, 1, nums.Length));
        }
        public int cycles(int[] nums, int begin, int end)
        {
            int rob1 = 0;
            int rob2 = 0;

            for (int i = begin; i < end; i++)
            {
                int temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            return rob2;
        }

        #endregion
        #region Longest Palindromic Substring
        /*
        Given a string s, return the longest palindromic substring in s.
                
        Example 1:
        Input: s = "babad"
        Output: "bab"
        Explanation: "aba" is also a valid answer.

        Example 2:
        Input: s = "cbbd"
        Output: "bb"

        Constraints:
        1 <= s.length <= 1000
        s consist of only digits and English letters.
        Extra Test Cases:
        "bb" 82 / 142 testcases passed

        https://leetcode.com/problems/longest-palindromic-substring/
        */
        int resLen = 0, resIdx = 0;
        public string LongestPalindrome(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                findLongest(s, i, i);
                findLongest(s, i, i + 1);
            }

            return s.Substring(resIdx, resLen);
        }


        public void findLongest(string w, int l, int r)
        {

            while (l >= 0 && r < w.Length && w[l] == w[r])
            {
                if (r - l + 1 > resLen)
                {
                    resIdx = l;
                    resLen = r - l + 1;
                }
                l--;
                r++;
            }
            return;
        }
        #endregion
        #region Palindromic Substrings
        /*
        Given a string s, return the number of palindromic substrings in it.
        A string is a palindrome when it reads the same backward as forward.
        A substring is a contiguous sequence of characters within the string.

        Example 1:
        Input: s = "abc"
        Output: 3
        Explanation: Three palindromic strings: "a", "b", "c".

        Example 2:
        Input: s = "aaa"
        Output: 6
        Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".

        Constraints:
            1 <= s.length <= 1000
            s consists of lowercase English letters.

        https://leetcode.com/problems/palindromic-substrings/
        */
        public int CountSubstrings(string s)
        {
            var count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                count += getPalindromeCount(s, i, i);
                count += getPalindromeCount(s, i, i + 1);
            }

            return count;
        }

        public int getPalindromeCount(string s, int l, int r)
        {
            var count = 0;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }
            return count;
        }
        #endregion
        #region Decode Ways
        /*
        A message containing letters from A-Z can be encoded into numbers using the following mapping:

        'A' -> "1"
        'B' -> "2"
        ...
        'Z' -> "26"

        To decode an encoded message, all the digits must be grouped then mapped back into letters using the reverse of the mapping above (there may be multiple ways). 
        For example, "11106" can be mapped into:
            "AAJF" with the grouping (1 1 10 6)
            "KJF" with the grouping (11 10 6)

        Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".
        Given a string s containing only digits, return the number of ways to decode it.
        The test cases are generated so that the answer fits in a 32-bit integer.

        Example 1:
        Input: s = "12"
        Output: 2
        Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).

        Example 2:
        Input: s = "226"
        Output: 3
        Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

        Example 3:
        Input: s = "06"
        Output: 0
        Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06").

        Constraints:

            1 <= s.length <= 100
            s contains only digits and may contain leading zero(s).

        s = "2101" Expected = 1 166 / 269 testcases passed
        s ="1201234" Expected = 3 258 / 269 testcases passed

        https://leetcode.com/problems/decode-ways/
        */
        public int NumDecodings(string s)
        {

            int[] dp = new int[s.Length + 1];
            dp[s.Length] = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                    dp[i] = 0;
                else
                    dp[i] = dp[i + 1];

                if (i + 1 < s.Length && (s[i] == '1' || (s[i] == '2' && s[i + 1] < '7')))
                    dp[i] += dp[i + 2];
            }


            return dp[0];
        }
        #endregion
        #region Coin Change
        /*
        You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
        Return the fewest number of coins that you need to make up that amount. 
        If that amount of money cannot be made up by any combination of the coins, return -1.
        You may assume that you have an infinite number of each kind of coin.

        Example 1:
        Input: coins = [1,2,5], amount = 11
        Output: 3
        Explanation: 11 = 5 + 5 + 1

        Example 2:
        Input: coins = [2], amount = 3
        Output: -1

        Example 3:
        Input: coins = [1], amount = 0
        Output: 0

        Constraints:

            1 <= coins.length <= 12
            1 <= coins[i] <= 231 - 1
            0 <= amount <= 104

        https://leetcode.com/problems/coin-change/
        Test Cases:
        [186,419,83,408]
        6249
        */
        public int CoinChange(int[] coins, int amount)
        {
            var dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();

            dp[0] = 0;

            for (var a = 1; a <= amount; a++)
            {
                foreach (var c in coins)
                {
                    if (a - c >= 0)
                    {
                        dp[a] = Math.Min(dp[a], 1 + dp[a - c]);
                    }
                }
            }

            return dp[amount] == amount + 1
                ? -1
                : dp[amount];
        }
        #endregion
        #region Maximum Product Subarray
        /*
        Given an integer array nums, find a subarray that has the largest product, and return the product.
        The test cases are generated so that the answer will fit in a 32-bit integer.

        Example 1:
        Input: nums = [2,3,-2,4]
        Output: 6
        Explanation: [2,3] has the largest product 6.

        Example 2:
        Input: nums = [-2,0,-1]
        Output: 0
        Explanation: The result cannot be 2, because [-2,-1] is not a subarray.

        Constraints:

            1 <= nums.length <= 2 * 104
            -10 <= nums[i] <= 10
            The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

        Extra Test Cases:
         [-1,4,-4,5,-2,-1,-1,-2,-3] Expected : 960
         [2,3,-2,4] Expected : 6 54 / 190 testcases passed
         [-2] Expected : -2 189 / 190testcases passed
        */
        public int MaxProduct(int[] nums)
        {
            int res = nums[0];

            int curMin = 1, curMax = 1;

            foreach (int num in nums)
            {
                int tmp = curMax * num;
                curMax = Math.Max(num, Math.Max(curMax * num, curMin * num));
                curMin = Math.Min(num, Math.Min(tmp, curMin * num)); // tmp because curMax 
                                                                     // might have changed
                res = Math.Max(curMax, res);
            }

            return res;
        }

        #endregion
        #region Word Break
        /*
        Given a string s and a dictionary of strings wordDict, return true if s can be 
        segmented into a space-separated sequence of one or more dictionary words.
        Note that the same word in the dictionary may be reused multiple times in the segmentation.

        Example 1:
        Input: s = "leetcode", wordDict = ["leet","code"]
        Output: true
        Explanation: Return true because "leetcode" can be segmented as "leet code".

        Example 2:
        Input: s = "applepenapple", wordDict = ["apple","pen"]
        Output: true
        Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
        Note that you are allowed to reuse a dictionary word.

        Example 3:
        Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
        Output: false

        Constraints:

            1 <= s.length <= 300
            1 <= wordDict.length <= 1000
            1 <= wordDict[i].length <= 20
            s and wordDict[i] consist of only lowercase English letters.
            All the strings of wordDict are unique.

        Extra Test Cases:
        "cars" ["car","ca","rs"] Expected : true      
        "bb" ["a","b","bbb","bbbb"] Expected : true

        https://leetcode.com/problems/word-break/
        */
        public bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] dp = new bool[s.Length + 1];
            Array.Fill(dp, false);
            dp[s.Length] = true;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                foreach (var w in wordDict)
                {
                    if (i + w.Length <= s.Length && s.Substring(i, w.Length) == w)
                        dp[i] = dp[i + w.Length];

                    if (dp[i] == true)
                        break;
                }
            }
            return dp[0];
        }
        #endregion
        #region Longest Increasing Subsequence
        /*
        Given an integer array nums, return the length of the longest strictly increasing
        subsequence.
        
        Example 1:
        Input: nums = [10,9,2,5,3,7,101,18]
        Output: 4
        Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

        Example 2:
        Input: nums = [0,1,0,3,2,3]
        Output: 4

        Example 3:
        Input: nums = [7,7,7,7,7,7,7]
        Output: 1

        Constraints:

            1 <= nums.length <= 2500
            -104 <= nums[i] <= 104

        Follow up: Can you come up with an algorithm that runs in O(n log(n)) time complexity?

        Extra test cases:
        [-86,-60]
        [-35,27,-71,-24,-13,-13,15,10,45,-75,-53,-75,29,-39,-56,44,5,-39,-16,-18,35,5,-34,47,-62,-56,-59,-72,-40,-70,-68,-25,-9,-11,37,-46,-35,-18,9,-54,3,0,25,-34,-21,-73,-46,-26,-43,-18]
        [98,42,61,11,-24,-47,83,-9,85,60,-45,-25,14,75,73,-16,-22,-27,-7,-17,16,54,37,81,87,38,18,-17,100,-42,86,45,-40,60,92,39,83,0,65,96,85,-21,97,23,-20,-34,75,53,30,37,-4,6,29,-39,37,-42,-18,69,8,-33,-25,10,-20,74,-47,95,66,-32,84,-3,25,12,-25,60,51,93,81,-10,-28,-34,-22,64,-45,-18,-31,91,39,-10,59,-31,52,12,-39,58,-22,81,69,88,0,95]
        [73,102,67,137,136,199,190,115,108,147,195,119,107,71,41,94,190,198,80,87,70,180,139,83,137,188,74,115,9,183,39,13,68,136,132,71,196,100,27,0,90,94,170,198,190,199,116,84,189,112,140,170,5,115,29,94,109,23,89,153,168,48,122,40,11,123,173,49,10,113,114,19,127,125,61,28,141,134,82,65,196,152,156,50,74,91,28,117,126,3,63,84,106,144,125,179,121,28,127,187,96,68,176,116,121,59,156,131,109,193,12,75,79,2,160,164,82,105,65,169,165,142,27,121,75,80,199,35,78,23,86,118,124,162,159,98,65,162,149,197,162,196,145,96,200,82,19,74,55,24,181,122,167,165,9,113,176,90,40,88,64,85,175,2,24,105,35,37,159,127,26,3,144,51,18,187,170,107,188,4,84,198,144,80,172,2,23,18,3,37,7,124,118,184,62,41,113,156,194,149]
        [141,238,170,166,119,203,194,115,280,50,211,135,274,177,249,258,114,269,55,280,175,87,109,101,166,201,56,236,171,57,198,113,215,131,168,51,204,245,55,229,228,124,89,76,229,233,57,69,144,120,202,128,68,96,62,63,98,118,78,177,237,156,76,249,99,168,202,130,189,198,270,86,248,262,62,170,146,210,109,287,229,90,143,157,250,261,186,127,233,137,148,92,149,276,219,58,112,218,245,294,283,171,178,213,108,293,58,157,58,95,202,193,91,107,57,276,139,80,58,262,268,226,173,62,79,195,249,124,266,260,112,277,279,131,85,164,219,292,201,184,216,187,256,108,210,175,245,145,191,204,261,59,57,226,167,194,222,153,210,65,77,85,237,96,65,95,84,273,284,273,172,249,176,276,98,103,262,209,282,70,244,193,220,174,127,240,236,85,212,95,64,194,219,93,246,263,199,239,87,72,75,190,189,143,90,85,267,265,166,72,185,189,287,293,272,230,288,256,209,159,216,161,74,128,100,214,95,127,157,193,93,178,139,187,298,62,134,242,170,142,257,77,160,123,203,249,101,140,218,113,65,222,247,77,93,133,83,296,81,158,81,203,252,145,127,135,124,219,73,228,105,156,198,233,101,175,90,105,274,221,285,288,76,267,66,286,228,248,274,244,290,109,227,73,155,73,214,189,142,261]
        [389,139,398,331,325,197,151,112,268,217,107,378,279,385,295,291,314,336,188,258,244,199,355,203,261,207,290,239,193,303,346,347,324,183,114,194,229,160,122,149,382,360,261,228,152,343,181,359,335,313,158,255,294,185,102,208,325,340,132,201,181,339,124,240,382,218,301,197,365,206,355,238,251,119,224,207,367,131,270,114,301,260,152,339,361,363,154,295,366,372,193,379,358,363,394,118,384,183,191,366,216,331,336,226,101,363,282,229,384,322,338,209,262,215,205,300,306,329,183,361,252,277,171,148,116,224,273,316,306,269,269,347,361,285,219,390,309,206,180,358,126,340,233,273,351,233,332,167,255,225,146,223,103,120,267,345,180,141,369,141,358,393,190,215,373,274,244,339,179,279,384,391,319,312,327,228,237,158,398,136,324,161,191,210,146,276,129,206,134,310,180,179,193,127,319,276,305,275,276,137,206,247,287,279,276,180,180,299,139,305,297,105,185,337,330,356,170,318,390,396,356,124,132,328,227,344,150,279,340,367,269,247,170,208,370,330,165,169,304,121,257,328,351,253,203,158,268,370,396,213,321,313,139,204,368,392,137,285,347,296,330,322,260,373,367,149,314,394,283,184,384,147,223,197,307,246,246,155,395,323,195,196,299,253,318,196,268,217,373,327,308,100,241,264,352,367,136,322,343,199,294,294,217,118,168,230,113,361,330,185,110,219,354,327,364,283,198,141,389,249,112,135,188,120,314,321,341,367,378,330,312,385,287,226,245,357,356,365,181,216,186,357,341,328,396,277,273,222,310,201,277,212,118,313,340,114,194,305,108,176,297,390,309,109,364,344,141,223,126,150,388,187,254,113,147,365,183,178,200,314,324,113,218,228,285,157,256,145,357,181,188,137,207,350,316,262,238,326,171,286]
        [-8358,-8357,-8356,-8355,-8354,-8353,-8352,-8351,-8350,-8349,-8348,-8347,-8346,-8345,-8344,-8343,-8342,-8341,-8340,-8339,-8338,-8337,-8336,-8335,-8334,-8333,-8332,-8331,-8330,-8329,-8328,-8327,-8326,-8325,-8324,-8323,-8322,-8321,-8320,-8319,-8318,-8317,-8316,-8315,-8314,-8313,-8312,-8311,-8310,-8309,-8308,-8307,-8306,-8305,-8304,-8303,-8302,-8301,-8300,-8299,-8298,-8297,-8296,-8295,-8294,-8293,-8292,-8291,-8290,-8289,-8288,-8287,-8286,-8285,-8284,-8283,-8282,-8281,-8280,-8279,-8278,-8277,-8276,-8275,-8274,-8273,-8272,-8271,-8270,-8269,-8268,-8267,-8266,-8265,-8264,-8263,-8262,-8261,-8260,-8259,-8258,-8257,-8256,-8255,-8254,-8253,-8252,-8251,-8250,-8249,-8248,-8247,-8246,-8245,-8244,-8243,-8242,-8241,-8240,-8239,-8238,-8237,-8236,-8235,-8234,-8233,-8232,-8231,-8230,-8229,-8228,-8227,-8226,-8225,-8224,-8223,-8222,-8221,-8220,-8219,-8218,-8217,-8216,-8215,-8214,-8213,-8212,-8211,-8210,-8209,-8208,-8207,-8206,-8205,-8204,-8203,-8202,-8201,-8200,-8199,-8198,-8197,-8196,-8195,-8194,-8193,-8192,-8191,-8190,-8189,-8188,-8187,-8186,-8185,-8184,-8183,-8182,-8181,-8180,-8179,-8178,-8177,-8176,-8175,-8174,-8173,-8172,-8171,-8170,-8169,-8168,-8167,-8166,-8165,-8164,-8163,-8162,-8161,-8160,-8159,-8158,-8157,-8156,-8155,-8154,-8153,-8152,-8151,-8150,-8149,-8148,-8147,-8146,-8145,-8144,-8143,-8142,-8141,-8140,-8139,-8138,-8137,-8136,-8135,-8134,-8133,-8132,-8131,-8130,-8129,-8128,-8127,-8126,-8125,-8124,-8123,-8122,-8121,-8120,-8119,-8118,-8117,-8116,-8115,-8114,-8113,-8112,-8111,-8110,-8109,-8108,-8107,-8106,-8105,-8104,-8103,-8102,-8101,-8100,-8099,-8098,-8097,-8096,-8095,-8094,-8093,-8092,-8091,-8090,-8089,-8088,-8087,-8086,-8085,-8084,-8083,-8082,-8081,-8080,-8079,-8078,-8077,-8076,-8075,-8074,-8073,-8072,-8071,-8070,-8069,-8068,-8067,-8066,-8065,-8064,-8063,-8062,-8061,-8060,-8059,-8058,-8057,-8056,-8055,-8054,-8053,-8052,-8051,-8050,-8049,-8048,-8047,-8046,-8045,-8044,-8043,-8042,-8041,-8040,-8039,-8038,-8037,-8036,-8035,-8034,-8033,-8032,-8031,-8030,-8029,-8028,-8027,-8026,-8025,-8024,-8023,-8022,-8021,-8020,-8019,-8018,-8017,-8016,-8015,-8014,-8013,-8012,-8011,-8010,-8009,-8008,-8007,-8006,-8005,-8004,-8003,-8002,-8001,-8000,-7999,-7998,-7997,-7996,-7995,-7994,-7993,-7992,-7991,-7990,-7989,-7988,-7987,-7986,-7985,-7984,-7983,-7982,-7981,-7980,-7979,-7978,-7977,-7976,-7975,-7974,-7973,-7972,-7971,-7970,-7969,-7968,-7967,-7966,-7965,-7964,-7963,-7962,-7961,-7960,-7959,-7958,-7957,-7956,-7955,-7954,-7953,-7952,-7951,-7950,-7949,-7948,-7947,-7946,-7945,-7944,-7943,-7942,-7941,-7940,-7939,-7938,-7937,-7936,-7935,-7934,-7933,-7932,-7931,-7930,-7929,-7928,-7927,-7926,-7925,-7924,-7923,-7922,-7921,-7920,-7919,-7918,-7917,-7916,-7915,-7914,-7913,-7912,-7911,-7910,-7909,-7908,-7907,-7906,-7905,-7904,-7903,-7902,-7901,-7900,-7899,-7898,-7897,-7896,-7895,-7894,-7893,-7892,-7891,-7890,-7889,-7888,-7887,-7886,-7885,-7884,-7883,-7882,-7881,-7880,-7879,-7878,-7877,-7876,-7875,-7874,-7873,-7872,-7871,-7870,-7869,-7868,-7867,-7866,-7865,-7864,-7863,-7862,-7861,-7860,-7859]
        [-6030,-6031,-6032,-6033,-6034,-6035,-6036,-6037,-6038,-6039,-6040,-6041,-6042,-6043,-6044,-6045,-6046,-6047,-6048,-6049,-6050,-6051,-6052,-6053,-6054,-6055,-6056,-6057,-6058,-6059,-6060,-6061,-6062,-6063,-6064,-6065,-6066,-6067,-6068,-6069,-6070,-6071,-6072,-6073,-6074,-6075,-6076,-6077,-6078,-6079,-6080,-6081,-6082,-6083,-6084,-6085,-6086,-6087,-6088,-6089,-6090,-6091,-6092,-6093,-6094,-6095,-6096,-6097,-6098,-6099,-6100,-6101,-6102,-6103,-6104,-6105,-6106,-6107,-6108,-6109,-6110,-6111,-6112,-6113,-6114,-6115,-6116,-6117,-6118,-6119,-6120,-6121,-6122,-6123,-6124,-6125,-6126,-6127,-6128,-6129,-6130,-6131,-6132,-6133,-6134,-6135,-6136,-6137,-6138,-6139,-6140,-6141,-6142,-6143,-6144,-6145,-6146,-6147,-6148,-6149,-6150,-6151,-6152,-6153,-6154,-6155,-6156,-6157,-6158,-6159,-6160,-6161,-6162,-6163,-6164,-6165,-6166,-6167,-6168,-6169,-6170,-6171,-6172,-6173,-6174,-6175,-6176,-6177,-6178,-6179,-6180,-6181,-6182,-6183,-6184,-6185,-6186,-6187,-6188,-6189,-6190,-6191,-6192,-6193,-6194,-6195,-6196,-6197,-6198,-6199,-6200,-6201,-6202,-6203,-6204,-6205,-6206,-6207,-6208,-6209,-6210,-6211,-6212,-6213,-6214,-6215,-6216,-6217,-6218,-6219,-6220,-6221,-6222,-6223,-6224,-6225,-6226,-6227,-6228,-6229,-6230,-6231,-6232,-6233,-6234,-6235,-6236,-6237,-6238,-6239,-6240,-6241,-6242,-6243,-6244,-6245,-6246,-6247,-6248,-6249,-6250,-6251,-6252,-6253,-6254,-6255,-6256,-6257,-6258,-6259,-6260,-6261,-6262,-6263,-6264,-6265,-6266,-6267,-6268,-6269,-6270,-6271,-6272,-6273,-6274,-6275,-6276,-6277,-6278,-6279,-6280,-6281,-6282,-6283,-6284,-6285,-6286,-6287,-6288,-6289,-6290,-6291,-6292,-6293,-6294,-6295,-6296,-6297,-6298,-6299,-6300,-6301,-6302,-6303,-6304,-6305,-6306,-6307,-6308,-6309,-6310,-6311,-6312,-6313,-6314,-6315,-6316,-6317,-6318,-6319,-6320,-6321,-6322,-6323,-6324,-6325,-6326,-6327,-6328,-6329,-6330,-6331,-6332,-6333,-6334,-6335,-6336,-6337,-6338,-6339,-6340,-6341,-6342,-6343,-6344,-6345,-6346,-6347,-6348,-6349,-6350,-6351,-6352,-6353,-6354,-6355,-6356,-6357,-6358,-6359,-6360,-6361,-6362,-6363,-6364,-6365,-6366,-6367,-6368,-6369,-6370,-6371,-6372,-6373,-6374,-6375,-6376,-6377,-6378,-6379,-6380,-6381,-6382,-6383,-6384,-6385,-6386,-6387,-6388,-6389,-6390,-6391,-6392,-6393,-6394,-6395,-6396,-6397,-6398,-6399,-6400,-6401,-6402,-6403,-6404,-6405,-6406,-6407,-6408,-6409,-6410,-6411,-6412,-6413,-6414,-6415,-6416,-6417,-6418,-6419,-6420,-6421,-6422,-6423,-6424,-6425,-6426,-6427,-6428,-6429,-6430,-6431,-6432,-6433,-6434,-6435,-6436,-6437,-6438,-6439,-6440,-6441,-6442,-6443,-6444,-6445,-6446,-6447,-6448,-6449,-6450,-6451,-6452,-6453,-6454,-6455,-6456,-6457,-6458,-6459,-6460,-6461,-6462,-6463,-6464,-6465,-6466,-6467,-6468,-6469,-6470,-6471,-6472,-6473,-6474,-6475,-6476,-6477,-6478,-6479,-6480,-6481,-6482,-6483,-6484,-6485,-6486,-6487,-6488,-6489,-6490,-6491,-6492,-6493,-6494,-6495,-6496,-6497,-6498,-6499,-6500,-6501,-6502,-6503,-6504,-6505,-6506,-6507,-6508,-6509,-6510,-6511,-6512,-6513,-6514,-6515,-6516,-6517,-6518,-6519,-6520,-6521,-6522,-6523,-6524,-6525,-6526,-6527,-6528,-6529]
        https://leetcode.com/problems/longest-increasing-subsequence/description/
        */
        
        //This solution is chosen for the following reasons:
        // 1 - Other run times for solutions that use  recursiong, dynamic programming have run time of n^2.
        // 2 - Segment tree solution code is much longer than Binary Tree using one.
        // 3 - Follow up for this question is "Follow up: Can you come up with an algorithm that runs in O(n log(n)) time complexity?"
        // 4-  It's memory foot print is equal to all others while having faster run time and easy to write nature of it.

        //    Time complexity: O(n log⁡n)
        //    Space complexity: O(n)

        public int LengthOfLIS(int[] nums)
        {
            List<int> dp = new List<int>();
            dp.Add(nums[0]);

            int LIS = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (dp[dp.Count - 1] < nums[i])
                {
                    dp.Add(nums[i]);
                    LIS++;
                    continue;
                }
                /*
                    The zero-based index of item in the sorted List<T>, if item is found;
                    otherwise, a negative number that is the bitwise complement of the index
                    of the next element that is larger than item or, if there is no larger element, 
                    the bitwise complement of Count.
                    https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.binarysearch?view=net-9.0#system-collections-generic-list-1-binarysearch(-0)
                */
                int idx = dp.BinarySearch(nums[i]);
                if (idx < 0) 
                {  //Bitwise complement operator ~
                   //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-
                   idx = ~idx;
                }
                //Only grow the list if there is something bigger than the elements we saw previously
                //Otherwise keep replacing our starting element and keep our list fresh for adding bigger elements
                dp[idx] = nums[i];
            }

            return LIS;
        }
        #endregion
        #region Partition Equal Subset Sum
        /*
        Given an integer array nums, return true if you can partition the array into two subsets such that the sum of the elements in both subsets is equal or false otherwise.

        Example 1:
        Input: nums = [1,5,11,5]
        Output: true
        Explanation: The array can be partitioned as [1, 5, 5] and [11].

        Example 2:
        Input: nums = [1,2,3,5]
        Output: false
        Explanation: The array cannot be partitioned into equal sum subsets.

        Constraints:

            1 <= nums.length <= 200
            1 <= nums[i] <= 100

        [23,13,11,7,6,5,5]
        [1,1]
        [6,14,19,10,17,10,8,15,16,1,12,4,9,2,15]
        [4,10,7,9,7,1,11,9,13,15]
        [9,10,15,3,9,2,9,10,13,1]
        [100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,99,97] 
        [1,5,10,6] 140 / 142 testcases passed
        https://leetcode.com/problems/partition-equal-subset-sum/
        */

        public bool CanPartition(int[] nums)
        {
            int arrSum = nums.Sum();
            if (arrSum % 2 != 0)
            {
                return false;
            }

            int target = arrSum / 2;
            bool[] dp = new bool[target + 1];

            dp[0] = true;

            //Coin Change problem adjacent
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = target; j >= nums[i]; j--)
                {
                    dp[j] = dp[j] || dp[j - nums[i]];
                }
            }

            return dp[target];
        }

        #endregion
    }
}