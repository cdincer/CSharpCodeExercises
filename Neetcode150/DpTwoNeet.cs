using System;
using System.Collections.Generic;
using System.Linq;

namespace Neetcode150
{
    public class DpTwoNeet
    {
        #region Unique Paths
        /*
        There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). 
        The robot can only move either down or right at any point in time. Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.
        The test cases are generated so that the answer will be less than or equal to 2 * 109.
       
        Example 1:
        Input: m = 3, n = 7
        Output: 28

        Example 2:
        Input: m = 3, n = 2
        Output: 3
        Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
        1. Right -> Down -> Down
        2. Down -> Down -> Right
        3. Down -> Right -> Down

        Constraints:
            1 <= m, n <= 100

        */
        public int UniquePaths(int m, int n)
        {
            int[] row = new int[n];
            Array.Fill(row, 1);

            for (int r = 0; r < m - 1; r++)
            {
                int[] newRow = new int[n];
                Array.Fill(newRow, 1);
                for (int col = n - 2; col >= 0; col--)
                {
                    newRow[col] = newRow[col + 1] + row[col];
                }
                row = newRow;
            }
            return row[0];
        }
        #endregion
        #region Longest Common Subsequence
        /*
        Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.
        A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.
        For example, "ace" is a subsequence of "abcde".
        A common subsequence of two strings is a subsequence that is common to both strings.

        Example 1:
        Input: text1 = "abcde", text2 = "ace" 
        Output: 3  
        Explanation: The longest common subsequence is "ace" and its length is 3.

        Example 2:
        Input: text1 = "abc", text2 = "abc"
        Output: 3
        Explanation: The longest common subsequence is "abc" and its length is 3.

        Example 3:
        Input: text1 = "abc", text2 = "def"
        Output: 0
        Explanation: There is no such common subsequence, so the result is 0.

        Constraints:

            1 <= text1.length, text2.length <= 1000
            text1 and text2 consist of only lowercase English characters.

        Extra Test Cases:
        "a"
        "ttta"
        "wggi"
        "g"
        "iitt"
        "tttttttttt"
        "jijiijjpji"
        "jjji"
        "fnbeaucuyhgariizanpxffiiicvjcynwcvlqyvobxvmqpqelcqrdvggecbwrhrwyqbgafyrnmwqrbtugykagycteuusvkpthokeiqddumbgwzechfyxrqxwfzmcpkewebbhaowqjalzqpkwzfyymttnatmczxbnmydnzfongvdokxjwibilpitdxfwavtkftdenrzsktqlsptsccttizehxvellkmqnomfynnptzcwseragirexubilbnxddsmmwufhcijrsdmecixjbahrhhkrekuqqcdghnljlazvvvtziqaimkfqignlmmfzujeboaqqeswjseozaspgpbedwwheshjettreroubajeaqfbrzlpehcnurcdeimkofesjgcmtqrdjwvsuagtszyxaqmctdusuyjdlwedsjrdpnsdizoflilgvkjdbdxhqtnguqjzkjknpbvawoywklsfvnlkhlfmvbanxtypouejervclgkinohleenbsrvddvhjeelokbtuikrfilyyerqamcanglbdihfffociwoloifuipddpnccwzlpqblpohjstiygligyibclnewnhgdjjatspmtphgddgyfdpizyengteffdwrkswjwuznebeougvojdzzztaallammgskuzrjhwxonzogekpderhzdehbzgcxgveaxiyrptakpblbsmmuwwmtmiezgghvesvqtgdiazzkboitidoeeookdfvgcujpvixvzzzakbwkynicutzowvzfspxfkndfvodvpwadlrvswalmpdhllilhmofyoyaxhncjmhqghadfajienejnihwniubbajajyzpxvuraorjnkgonjvnmdboujfyoimsqdfebutbjcqgvdkkgczzwruinxsltspempsvclpzgqwybsquxubmvzygkpabvkchieqtvqdocjpufcmojehiwdnmvzgrsfgiwqmiahmozjzqzzfzrtxnqistceggdm"
        "vfkfjkpuyo"
        "fffkvfffkkkkkffffffkvfvvvfffvvvkffkfkfkvvvkkvfkvvvkvvffvvkvfvvfkffvfffkkffkfvkkkffffvfkvfvvvffvvkkvvkvvvfvfvvkfkfvfvvfvvffkvkfkkkkvvffkkfvvvkvkvvfvvvkkfkvffkfkffkfffvkvkfvkvfkvffkkvkfkffkfvkffvvkkfkkvvvkfffkfkvfkffvfvkfvkkvkvffvvfkvvffkvkkfkffkvfkffkkffkkkfkvfvfkfvvfkvfvkfvkkfkvvkkfkfvvfvkkffffkkkvffkfvvkkfkkvvvffffvvvvkffkffkvkvkvvkvfffvfkkfffkvvvkfvvfvvvfkfkfkfvfffkvkvfkvfkffkvkkvvkkfkkvkfkvvfvffkkkkkfffvkfvkfkkkkvkkvvkkfvvvfkvvfkvffvvfkkfkfkfvvkfkkvvkkfvvkvvkfffkvvvkffvfkkfkfvvkkkkfkvvfvkfkfkvvfvkkvfvfkfvvkvfkkkkvvffvfvffvvvvvfkkkfkvvfkvvffkkkvkfkkfkfkkkffffvvkvvvfkvkfkffffvfvvvfvkvvkkkkvkkkkvvfvfkvvkkkfkkvfkkfffvfkvkvffvkfvvkkfkfvvkfvkffkfvvkkvfkvfffffvkkfkfkkkkkfkvvvfkvvvffffkfffvfvkvvfvkkfkkvfkkkkfkfkvvkffkkvkkfvffvkvfvfffffvvfvvvvvvkfvvfvfkfvvvvkffffvkkfkkfvvkfffkkvvkkvfkvkkfvkkvffkfkvkffvfkkkfkkvvvvkkvvfvfkkkfvkvfkkkfkkfkvkvvvkvfffkvkfkvfkkvvvkkffkvfvfkkvkffffvfkkfvfkfvffvvvkkfvfvvvfkkkkkkvfvkvkkkfvfkkffvkvkkvfvkkkvfkkfvfffkvvvfkfffvvvfkffvvfkfvkfkfffkkkvffvvvkfkkkvvkkkkkfvvkvf"
        "vkkkkkffvk"
        "jduirerawykaiwuavukhrzhrkmrrsgvhkvorntvritqrikfrsowwvqqqmhlhotjhejvsqgcdooqxddogyuknrlircvibjrvpnagltihrkporzbpcopxshjpnotcrdtwomegqvlbbwhnaxgiiyojgzcdjzapcxsdjryotvpybpyrpomtbxtjmeionxqmypkhtwklicxoahrggebhisypyjepbehretsucyjbycemhochgexmjryiehrkvjpaflpkdeqzvmlxzfddgqfzpugqxufqgsdomwtwlulyzoghcadlkizvxxkjuucycgkaaiyxbtchgkrlmgoyiybooskaimdmbgdunnaetobnvdmafxflddipayovckxclvrhvcvwkxkzcchecswecdpjhbmgyqpvhbuvjefuqjryfiemmolboenvqebszzphxxircsreeyyybvkndakdtgbzfhprcxzzpvhwsqfjxxphgxirciruvlpzirfkengtlihkftqwbxxbizgdosnkorwdctuadclrdxpbtasewryelndvpbqeovpjxfkpsieauewhvourullpeeergppcajiglrpubywcngksnltjucbaapjpphcrbhdnldhobvtpgmzulzcfcrrwmqorxobnugdrspdxlcrahlsiadousabbneeasaxpwvkwkajiliqqjjbuautnmorrmhkpbagztvhotxlwrxxwfpwbamhjogguaubvyhtthjcgybyszjsazqtodwsshxargcydrbpdqgeehzpzjeckqjvuhdnkjffhmgbywhkcvzinqvhjqqtgvzildpjlnummlxmbqsrxtpwcpgezhxmphwoxzeruogaxytsyvrafqnowsskzhpfjruykkxftbxedznpmhcabdvwutnoyvwvzdhezagvlbbzihzpvrvvwnftgleyzyjldnfdwezzjsiinzqobgwevgifliyngizlkjyoawjlcmnkalyqfc"
        "bcrvkxirhlayhntityxpewodsaxukgleifcyfxzroxhekjqwhiltrahuwjjtqprhsaajtojzaabgykkylnebewxjkwcchejchefbikcltdrrvfqfjdzeyqkinufmebjankixhdsvtynzheihvhceyuuwrqhoagyeihaimxuodjnkryflzqirsgoiithsrdecijeuylfudpotgvhcmixjvlwnwdmpaukzmiatzvvbilydajfvhofewpxdzynchdcimywmunjhlndfaqecawmneinwazlvuafwghxqtbmunjbppgdpoklsqetuktjglkqelxknepxmpupteauyimcrwqzdofthulkoqhmjsnstdsvbsvtunoiytycfvzaazxflusdbbylrhbvbdzayjjhuzptbfgpzhhozotgbmnhstopclzamvxstoukmqaeqryxjylubkojpyhrofcngydxcurvncwbypfbqmhtflrfwdtckfowkjyareehfvkzjyhblenbimgjdtkgewmrzeuiojkuaqwfibfsbbbqinxxfuezzhgrndzcrjqdfxjwnqsrhukncrmapdvgyjeibmmewtwysuxddrtegebwpudmukgphrlwwopsyipooljpteojxyrkigtmhhntlhggdvgujpctycbebsszpwxzzxxmlwosoeerstgjwxdhctolxrfyeatdociyymxvqajikjxqxhfaegmudedtuiqmoouifvtxwhiyvkvpaljxhnfdgeraezjjthvktdibqtteaveqeikylkdoudjxwlgmuyapghfjodmsttvlgnjgfvtcrjunqckgicztpxhpsoracexdafcwkqpeyjwxmhyjctbmngzqjfvnveruvlbpbldhgofofdkmvwgsnnzutlpjbmsoszsycvuhgoobxwiqnvwmqgcvcvyexvoxciqgwrvpdjmogqbmmoeymcbxbynljfwpjbklxszouoxuuqrgmjwmq"
        "qqqzqzqzqzqqqqzqqqqqqzqqqqqqzqqzqqqqqzzqzzqqqqzqqzqqqqzzqqzzzqqqzzqzzzzqzqqqqzzqzqqqqqqqqzzqzzzzqzqzqqqqqzqzqzzqqqzqqzzqqqzqqzqqzqzqzqqqqqzqzzzzqqqqqqzzzqqzqzqqzqqqqzqqzqzzzqqzqzzzzqqqqzzqqqqqqqqqqzqqqzqzqzqqzqqqzqqqzzqzqqqqqzqzqqqqzqqqqqqqzzqzqzqqqzqqzzqzqqqzqqqzzqqqqqzqzqzqqqqqqqqqqzqqzqzqqqqqqqzqzzqqqqqqzqqzqqqqzqqqzqqqqqzqqqqqzqqqzqzqzqqqzzqqqqzqqzzqqqzzqqqqzzzqqqqqqzqqzqqzqqqzzqqqqzzqqzzqzqzzqqqzqqqqzzqzqzzzzqqqzqzqzzqqzzqqqqqqzqqqqqqqqqzzqzqqqzqzqqqqqqqqqzqzqqzqqqzzqqzzqqqqqqqqqqqqzzqqqzqzqzqqqqqzqqqqzzqqzqqqzqzqzqqqzzqqqqqqqqqzqzqzqqqzzzqqqzzqqqzqzzqzzzqqzqqqqzqzqqzqzqqqqqqqqzzqqqzqzzqqqqzzqzzqzqqqqqqqzqqqzqqqqqqqqzqqqqzqqqzqzqqzqqzzzzqqzzqqzqqzqqqzqqqqqqqqqqqzzqzzqqqzqqqzqzzqqzqqqzzzqzqqqqqqqqqqqzzqqzqqqqzzqqqzqqzqqqqqqzqqqqqzqqqqqzzqqqzqqqqzzzqqqqqqzzzzqqqzqzqzqqqqzqqzzzzqqqqzqqqzzzqqzqzqzqzzqzzzqqzqqqzqqqzqzqqqzqqqqqzqqqzzqqqqzqqqzqzzqzzqqzqzzqqqqzqqqqqzqqqqqqqqqqzqqzzqqzzqqqqqzqqzzzzqqqqqqqqzqzzqqzzqzqqqqqqqzqqzqqqqqzqqqzqqzqzqzzqqzqzqqqzqzzqqzqqqqqqzqqqzzzqzqqqqqqqzqqqzzzqq"
        "qzqqqqqzzqqqqzqqzqzqqqqqqqzqqqzqqzzqqqqzzzzqqqqzqqqqzzqqzqqqqqzqzqzqzqzqqqzqzqqqqqqzzqqqqqqzqzzqqqqzqqqzqzzqqzqzqqzqz
        https://leetcode.com/problems/longest-common-subsequence/
        */
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int t1l = text1.Length;
            int t2l = text2.Length;

            int[,] dp = new int[t1l + 1, t2l + 1];

            for (int r = t1l - 1; r >= 0; r--)
            {
                for (int c = t2l - 1; c >= 0; c--)
                {
                    if (text1[r] == text2[c])
                    {
                        dp[r, c] = 1 + dp[r + 1, c + 1];
                    }
                    else
                    {
                        dp[r, c] = Math.Max(dp[r + 1, c], dp[r, c + 1]);
                    }
                }
            }

            return dp[0, 0];
        }
        #endregion
        #region Best Time to Buy and Sell Stock with Cooldown
        /*
        You are given an array prices where prices[i] is the price of a given stock on the ith day.
        Find the maximum profit you can achieve. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times) with the following restrictions:
        After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).
        Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

        Example 1:
        Input: prices = [1,2,3,0,2]
        Output: 3
        Explanation: transactions = [buy, sell, cooldown, buy, sell]

        Example 2:
        Input: prices = [1]
        Output: 0

        Constraints:

            1 <= prices.length <= 5000
            0 <= prices[i] <= 1000

        Extra Test Cases:
        [4,3,2,10,11,0,11]
        https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
        */

        public int MaxProfit(int[] prices)
        {
            int hold = int.MinValue; // Requires a initial state, we can't
                                     // hold without buying anything
                                     // if we don't it will be missing 
                                     // spending of purchasing
            int sold = 0;
            int rest = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                int prevSold = sold;
                sold = hold + prices[i];//In order to sell we have to be holding.
                hold = Math.Max(hold, rest - prices[i]);//In order to hold, we need to decide
                                                        //on buying or not buying.
                rest = Math.Max(rest, prevSold);//We store our resting amount. 
                                                //This will be our tracing previous days.
            }

            return Math.Max(rest, sold);
        }

        #endregion
        #region Coin Change II 
        /*
        You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
        Return the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of the coins, return 0.
        You may assume that you have an infinite number of each kind of coin.
        The answer is guaranteed to fit into a signed 32-bit integer.

        Example 1:
        Input: amount = 5, coins = [1,2,5]
        Output: 4
        Explanation: there are four ways to make up the amount:
        5=5
        5=2+2+1
        5=2+1+1+1
        5=1+1+1+1+1

        Example 2:
        Input: amount = 3, coins = [2]
        Output: 0
        Explanation: the amount of 3 cannot be made up just with coins of 2.

        Example 3:
        Input: amount = 10, coins = [10]
        Output: 1

        Constraints:

            1 <= coins.length <= 300
            1 <= coins[i] <= 5000
            All the values of coins are unique.
            0 <= amount <= 5000


        Extra Test Cases:
        14 / 28 testcases passed
        amount = 500
        [3,5,7,8,9,10,11]

        https://leetcode.com/problems/coin-change-ii/
        */


        //    This solution picked for following reasons:
        //    1-Clarity
        //    2-Efficient use of memory
        //    3-It doesn't initialize new array for every coin loop
        //
        //    https://neetcode.io/solutions/coin-change-ii - 5. Dynamic Programming (Optimal)
        //    Time complexity: O(n∗a)
        //    Space complexity: O(a)
        //    Where n is the number of coins and a is the given amount. 

        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach (int coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                {
                    dp[i] += dp[i - coin];
                }
            }

            return dp[amount];
        }

        #endregion
        #region Target Sum
        /*
        You are given an integer array nums and an integer target.
        You want to build an expression out of nums by adding one of the symbols '+' and '-' before each integer in nums and then concatenate all the integers.
            For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate them to build the expression "+2-1".
        Return the number of different expressions that you can build, which evaluates to target.

        Example 1:
        Input: nums = [1,1,1,1,1], target = 3
        Output: 5
        Explanation: There are 5 ways to assign symbols to make the sum of nums be target 3.
        -1 + 1 + 1 + 1 + 1 = 3
        +1 - 1 + 1 + 1 + 1 = 3
        +1 + 1 - 1 + 1 + 1 = 3
        +1 + 1 + 1 - 1 + 1 = 3
        +1 + 1 + 1 + 1 - 1 = 3

        Example 2:
        Input: nums = [1], target = 1
        Output: 1

        Constraints:

            1 <= nums.length <= 20
            0 <= nums[i] <= 1000
            0 <= sum(nums[i]) <= 1000
            -1000 <= target <= 1000

        Extra Test Cases:
        [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
        0
        [0,0,0,0,0,0,0,0,1]
        1
        https://leetcode.com/problems/target-sum/
        */

        //Coin Change like DP solution
        public int FindTargetSumWays(int[] nums, int target)
        {
            Dictionary<int, int> dp = new();
            dp[0] = 1;

            foreach (int num in nums)
            {
                Dictionary<int, int> nextDp = new();
                foreach (var entry in dp)
                {
                    int total = entry.Key;
                    int count = entry.Value;

                    if (!nextDp.ContainsKey(total + num))
                    {
                        nextDp[total + num] = 0;
                    }
                    nextDp[total + num] += count;

                    if (!nextDp.ContainsKey(total - num))
                    {
                        nextDp[total - num] = 0;
                    }
                    nextDp[total - num] += count;
                }
                dp = nextDp;
            }
            return dp.ContainsKey(target) ? dp[target] : 0;
        }

        #endregion
        #region Interleaving String
        /*
        Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.
        An interleaving of two strings s and t is a configuration where s and t are divided into n and m
        substrings respectively, such that:

            s = s1 + s2 + ... + sn
            t = t1 + t2 + ... + tm
            |n - m| <= 1
            The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...

        Note: a + b is the concatenation of strings a and b.

        Example 1:
        Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
        Output: true
        Explanation: One way to obtain s3 is:
        Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
        Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" = "aadbbcbcac".
        Since s3 can be obtained by interleaving s1 and s2, we return true.

        Example 2:
        Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
        Output: false
        Explanation: Notice how it is impossible to interleave s2 with any other string to obtain s3.

        Example 3:
        Input: s1 = "", s2 = "", s3 = ""
        Output: true

        Constraints:

            0 <= s1.length, s2.length <= 100
            0 <= s3.length <= 200
            s1, s2, and s3 consist of lowercase English letters.

        Follow up: Could you solve it using only O(s2.length) additional memory space?

        https://leetcode.com/problems/interleaving-string/
        
        Extra Test Cases:
        s1 = "aabc"
        s2 = "abad"
        s3= "aabadabc"
        s1 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        s2 = "aaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        s3 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        92/106 test cases passed
        s1 = "aabc"
        s2 = "abad"
        s3 = "aabcabad"
        */
        #region 2-D DP Bottom Up
        public bool IsInterleave1(string s1, string s2, string s3)
        {
            int s1L = s1.Length, s2L = s2.Length;
            if (s1L + s2L != s3.Length)
            {
                return false;
            }

            bool[,] dp = new bool[s1L + 1, s2L + 1];
            dp[s1L, s2L] = true;

            for (int r = s1L; r >= 0; r--)
            {
                for (int c = s2L; c >= 0; c--)
                {
                    //dp[r + 1, c] and dp[r, c  +1] are for checking 
                    //the interleaving works, this is done by checking the
                    //used up parts (remaining of both on 2-D array) are "valid"
                    if (r < s1L && s1[r] == s3[r + c] && dp[r + 1, c])
                    {
                        dp[r, c] = true;
                    }
                    if (c < s2L && s2[c] == s3[r + c] && dp[r, c + 1])
                    {
                        dp[r, c] = true;
                    }
                }
            }
            return dp[0, 0];
        }
        #endregion 2-D DP Bottom Up
        #region Space Optimized 2-D DP
        public bool IsInterleave2(string s1, string s2, string s3)
        {
            int shortLength = s1.Length > s2.Length ? s2.Length : s1.Length;
            int longLength = s1.Length > s2.Length ? s1.Length : s2.Length;

            string shortWord = s1.Length > s2.Length ? s2 : s1;
            string longWord = s1.Length > s2.Length ? s1 : s2;

            if (shortLength + longLength != s3.Length)
                return false;

            bool[] dp = new bool[longLength + 1];
            dp[longLength] = true;
            for (int i = shortLength; i >= 0; i--)
            {
                bool nextDp = true;
                for (int j = longLength - 1; j >= 0; j--)
                {
                    bool res = false;
                    if (i < shortLength && shortWord[i] == s3[i + j] && dp[j])
                    {
                        res = true;
                    }
                    if (j < longLength && longWord[j] == s3[i + j] && nextDp)
                    {
                        res = true;
                    }
                    dp[j] = res;
                    nextDp = dp[j];
                }
            }
            return dp[0];
        }
        #endregion Space Optimized 2-D DP
        #endregion
        #region  Increasing Path in a Matrix
        /*
        Given an m x n integers matrix, return the length of the longest increasing path in matrix.
        From each cell, you can either move in four directions: left, right, up, or down. You may not move diagonally or move outside the boundary (i.e., wrap-around is not allowed).

        Example 1:
        Input: matrix = [[9,9,4],[6,6,8],[2,1,1]]
        Output: 4
        Explanation: The longest increasing path is [1, 2, 6, 9].

        Example 2:
        Input: matrix = [[3,4,5],[3,2,6],[2,2,1]]
        Output: 4
        Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.

        Example 3:
        Input: matrix = [[1]]
        Output: 1

        Constraints:

            m == matrix.length
            n == matrix[i].length
            1 <= m, n <= 200
            0 <= matrix[i][j] <= 231 - 1

        Code below can use a 2d array and it became 40% faster than dictionary.
        
        https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
        Extra Test Case:
        [[7,0,8],[4,7,8],[4,7,4]] 17 / 139 testcases passed
        135 / 139 testcases passed
        [[0,1,2,3,4,5,6,7,8,9],[19,18,17,16,15,14,13,12,11,10],[20,21,22,23,24,25,26,27,28,29],[39,38,37,36,35,34,33,32,31,30],[40,41,42,43,44,45,46,47,48,49],[59,58,57,56,55,54,53,52,51,50],[60,61,62,63,64,65,66,67,68,69],[79,78,77,76,75,74,73,72,71,70],[80,81,82,83,84,85,86,87,88,89],[99,98,97,96,95,94,93,92,91,90],[100,101,102,103,104,105,106,107,108,109],[119,118,117,116,115,114,113,112,111,110],[120,121,122,123,124,125,126,127,128,129],[139,138,137,136,135,134,133,132,131,130],[0,0,0,0,0,0,0,0,0,0]]
        
        C# Converted Sample Test Case:
        [[9,9,4],[6,6,8],[2,1,1]]
         int[][] twoDArray = new int[][]
            {
            new int[] {9,9,4},
            new int[] {6,6,8},
            new int[] {2,1,1}
            };

        [[3,4,5],[3,2,6],[2,2,1]]
         int[][] twoDArray = new int[][]
            {
            new int[] {3,4,5},
            new int[] {3,2,6},
            new int[] {2,2,1}
            };
        */
        private int[][] memo;
        //TO-DO
        //Needs refactoring and benchmarking between jagged array and 2D array.
        //Variable:memo
        public int LongestIncreasingPath(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            memo = new int[m][];
            for (int i = 0; i < m; i++)
            {
                memo[i] = new int[n];
            }

            int max = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    max = Math.Max(max, DFS(matrix, i, j));
                }
            }
            return max;
        }
        private int DFS(int[][] matrix, int i, int j)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            if (memo[i][j] != 0)
            {
                return memo[i][j];
            }

            int max = 1;
            // up
            if (i - 1 >= 0 && matrix[i - 1][j] > matrix[i][j])
            {
                max = Math.Max(max, 1 + DFS(matrix, i - 1, j));
            }
            // down
            if (i + 1 < m && matrix[i + 1][j] > matrix[i][j])
            {
                max = Math.Max(max, 1 + DFS(matrix, i + 1, j));
            }
            // left
            if (j - 1 >= 0 && matrix[i][j - 1] > matrix[i][j])
            {
                max = Math.Max(max, 1 + DFS(matrix, i, j - 1));
            }
            // right
            if (j + 1 < n && matrix[i][j + 1] > matrix[i][j])
            {
                max = Math.Max(max, 1 + DFS(matrix, i, j + 1));
            }
            memo[i][j] = max;
            return max;
        }
        #endregion
        #region Distinct Subsequences
        /*
        Given two strings s and t, return the number of distinct subsequences of s which equals t.
        The test cases are generated so that the answer fits on a 32-bit signed integer.

        Example 1:
        Input: s = "rabbbit", t = "rabbit"
        Output: 3
        Explanation:
        As shown below, there are 3 ways you can generate "rabbit" from s.
        rabbbit
        rabbbit
        rabbbit

        Example 2:
        Input: s = "babgbag", t = "bag"
        Output: 5
        Explanation:
        As shown below, there are 5 ways you can generate "bag" from s.
        babgbag
        babgbag
        babgbag
        babgbag
        babgbag

        Constraints:

            1 <= s.length, t.length <= 1000
            s and t consist of English letters.
        https://leetcode.com/problems/distinct-subsequences
        https://neetcode.io/solutions/distinct-subsequences
        */
        public int NumDistinct(string s, string t)
        {
            if (t.Length > s.Length)
                return 0;

            //s is longer //t is shorter
            int wll = s.Length;
            int wsl = t.Length;
            int[,] dp = new int[wll + 1, wsl + 1];

            for (int r = 0; r < wll; r++)
                dp[r, wsl] = 1;

            dp[wll, wsl] = 1;

            for (int r = wll - 1; r >= 0; r--)
            {
                for (int c = wsl - 1; c >= 0; c--)
                {
                    if (s[r] == t[c])//dp[r + 1,c + 1] newly matched sequence
                                     //dp[r + 1,c] previously matched sequences
                                     //both are ok to push on as a result.
                        dp[r, c] = dp[r + 1, c + 1] + dp[r + 1, c];
                    else
                        dp[r, c] = dp[r + 1, c]; // only previously matched sequences
                }
            }
            return dp[0, 0];
        }
        #endregion
        #region Edit Distance
        /*
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

            Insert a character
            Delete a character
            Replace a character

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        Example 2:
        Input: word1 = "intention", word2 = "execution"
        Output: 5
        Explanation: 
        intention -> inention (remove 't')
        inention -> enention (replace 'i' with 'e')
        enention -> exention (replace 'n' with 'x')
        exention -> exection (replace 'n' with 'c')
        exection -> execution (insert 'u')

        Constraints:
            0 <= word1.length, word2.length <= 500
            word1 and word2 consist of lowercase English letters.
        
        Extra Test Cases:
        word1 = "spartan" word2 = "part" Expected 3 1106 / 1146 testcases passed
    
        https://leetcode.com/problems/edit-distance/
        https://neetcode.io/solutions/edit-distance
        */

       
        public int MinDistance(string word1, string word2)
        {
            //Bottom up
            int w1l = word1.Length;
            int w2l = word2.Length;
            int[,] dp = new int[w1l + 1, w2l + 1];

            for (int r = 0; r < w1l + 1; r++)
            {
                dp[r, w2l] = w1l - r;
            }
            for (int c = 0; c < w2l + 1; c++)
            {
                dp[w1l, c] = w2l - c;
            }

            for (int r = w1l - 1; r >= 0; r--)
            {
                for (int c = w2l - 1; c >= 0; c--)
                {
                    if (word1[r] == word2[c])
                        dp[r, c] = dp[r + 1, c + 1];
                    else
                        dp[r, c] = 1 + Math.Min(Math.Min(dp[r + 1, c + 1], dp[r + 1, c]), dp[r, c + 1]); //Replace, Delete, Insert
                }
            }

            return dp[0, 0];
        }


        #endregion
        #region Burst Balloons
        /*
        You are given n balloons, indexed from 0 to n - 1. Each balloon is painted with a number on it represented by an array nums. You are asked to burst all the balloons.
        If you burst the ith balloon, you will get nums[i - 1] * nums[i] * nums[i + 1] coins. If i - 1 or i + 1 goes out of bounds of the array, 
        then treat it as if there is a balloon with a 1 painted on it.
        Return the maximum coins you can collect by bursting the balloons wisely.

        Example 1:
        Input: nums = [3,1,5,8]
        Output: 167
        Explanation:
        nums = [3,1,5,8] --> [3,5,8] --> [3,8] --> [8] --> []
        coins =  3*1*5    +   3*5*8   +  1*3*8  + 1*8*1 = 167

        Example 2:
        Input: nums = [1,5]
        Output: 10

        Constraints:

            n == nums.length
            1 <= n <= 300
            0 <= nums[i] <= 100
        https://leetcode.com/problems/burst-balloons/
        */
        public int MaxCoins(int[] nums)
        {
            int n = nums.Length;

            int[] newNums = nums.Prepend(1).Append(1).ToArray();

            int[,] dp = new int[n + 2, n + 2];
            for (int l = n; l >= 1; l--)
            {
                for (int r = l; r <= n; r++)
                {
                    for (int i = l; i <= r; i++)
                    {
                        int coins = newNums[l - 1] * newNums[i] * newNums[r + 1];
                        coins += dp[l, i - 1] + dp[i + 1, r];
                        dp[l, r] = Math.Max(dp[l, r], coins);
                    }
                }
            }

            return dp[1, n];
        }
        #endregion
        #region Regular Expression Matching
        /*
        Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:
            '.' Matches any single character.​​​​
            '*' Matches zero or more of the preceding element.
        The matching should cover the entire input string (not partial).

        Example 1:
        Input: s = "aa", p = "a"
        Output: false
        Explanation: "a" does not match the entire string "aa".

        Example 2:
        Input: s = "aa", p = "a*"
        Output: true
        Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

        Example 3:
        Input: s = "ab", p = ".*"
        Output: true
        Explanation: ".*" means "zero or more (*) of any character (.)".

        Constraints:

            1 <= s.length <= 20
            1 <= p.length <= 20
            s contains only lowercase English letters.
            p contains only lowercase English letters, '.', and '*'.
            It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.

        Extra Test Cases:
        Input: "aaa", Pattern:"ab*ac*a"
        Input: "mississippi" Pattern:"mis*is*p*."
        Input "a" Pattern:".*"
        Input:"ab" Pattern: ".*c" 10 /356 test cases.
        https://leetcode.com/problems/regular-expression-matching/
        https://neetcode.io/solutions/regular-expression-matching
        */
        public bool IsMatch(string stri, string pat)
        {
            // Top down
            Dictionary<(int, int), bool> cache = new();

            //Three possibilities.
            //Match the wild cards.
            //Match a letter.
            //Nothing is matched
            bool dfs(int r, int c)//r is for input, c is for pattern.
            {
                if (cache.ContainsKey((r, c)))
                    return cache[(r, c)];
                if (r >= stri.Length && c >= pat.Length)
                    return true;
                if (c >= pat.Length)
                    return false;

                var match = r < stri.Length && (stri[r] == pat[c] || pat[c] == '.');
                if (c + 1 < pat.Length && pat[c + 1] == '*')
                {
                    cache.TryAdd((r, c), false);
                    cache[(r, c)] = (match && dfs(r + 1, c)) || //use *
                      dfs(r, c + 2); //dont use *
                    return cache[(r, c)];
                }

                if (match)
                {
                    cache.TryAdd((r, c), false);
                    cache[(r, c)] = dfs(r + 1, c + 1);
                    return cache[(r, c)];
                }

                cache.TryAdd((r, c), false);
                cache[(r, c)] = false;
                return cache[(r, c)];
            }

            return dfs(0, 0);
        }

        #region Alternative Top Down
        public bool IsMatchTopDown(string s, string p)
        {
            int sL = s.Length;
            int pL = p.Length;
            bool[,] dp = new bool[sL + 1, pL + 1];
            dp[sL, pL] = true;

            for (int r = sL; r >= 0; r--)
            {
                for (int c = pL - 1; c >= 0; c--) //pL - 1 because of c + 2
                {
                    //'.' Matches any single character.​​​​
                    bool match = r < sL &&
                                 (s[r] == p[c] || p[c] == '.');

                    //'*' Matches zero or more of the preceding element.
                    if ((c + 1) < pL && p[c + 1] == '*') //Use the star if it's available.
                    {
                        dp[r, c] = dp[r, c + 2]; // incase star matching doesn't work out.
                        if (match)               // see if the other pattern character matched.
                        {                        // with the current string character
                                                 // we can skip using star wildcard and move
                                                 // onto a other character in the pattern.

                            dp[r, c] |= dp[r + 1, c];//Do the star pattern matching 
                                                     //see if the next
                        }                            //string element matched current pattern.
                    }
                    else if (match) //Star doesn't exist just use the routine matching.
                    {
                        dp[r, c] = dp[r + 1, c + 1];
                    }
                }
            }

            return dp[0, 0];
        }
        #endregion Alternative Top Down
        #endregion
    }
}

