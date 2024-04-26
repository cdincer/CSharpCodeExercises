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

            for (int i = 0; i < m - 1; i++)
            {
                var newrow = new int[n];
                Array.Fill(newrow, 1);
                for (int r = n - 2; r >= 0; r--)
                {
                    newrow[r] = newrow[r + 1] + row[r];
                }
                row = newrow;
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
            string longW = text1.Length > text2.Length ? text1 : text2;
            string shortW = text1.Length > text2.Length ? text2 : text1;

            int[,] dp = new int[longW.Length + 1, shortW.Length + 1];

            for (int r = longW.Length - 1; r >= 0; r--)
            {
                for (int c = shortW.Length - 1; c >= 0; c--)
                {
                    if (longW[r] == shortW[c])
                        dp[r, c] = 1 + dp[r + 1, c + 1];
                    else
                        dp[r, c] = Math.Max(dp[r, c + 1], dp[r + 1, c]);

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
            int sold = 0, rest = 0, hold = Int32.MinValue;

            for (int i = 0; i < prices.Length; i++)
            {
                int prevSold = sold;
                sold = hold + prices[i];
                hold = Math.Max(hold, rest - prices[i]);
                rest = Math.Max(rest, prevSold);
            }
            return Math.Max(sold, rest);
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
        */
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
        public int FindTargetSumWays(int[] nums, int target)
        {
            var mem = new Dictionary<(int, int), int>();

            int dfs(int index, int total)
            {
                if (index == nums.Length)
                    return total == target ? 1 : 0;


                if (mem.ContainsKey((index, total)))
                {
                    return mem[(index, total)];
                }

                mem[(index, total)] = dfs(index + 1, total + nums[index]) + dfs(index + 1, total - nums[index]);
                return mem[(index, total)];
            }

            return dfs(0, 0);
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
        */
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3.Length != s1.Length + s2.Length)
                return false;
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
            dp[s1.Length, s2.Length] = true;

            for (int r = s1.Length; r >= 0; r--)
            {
                for (int c = s2.Length; c >= 0; c--)
                {
                    if (s1.Length > r && s1[r] == s3[r + c] && dp[r + 1, c])
                        dp[r, c] = true;

                    if (s2.Length > c && s2[c] == s3[r + c] && dp[r, c + 1])
                        dp[r, c] = true;
                }
            }

            return dp[0, 0];
        }
        #endregion
        #region Longest Increasing Path in a Matrix
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
        */
        public int LongestIncreasingPath(int[][] matrix)
        {

            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var maxValue = int.MinValue;

            var dictionary = new Dictionary<(int, int), int>();

            int dfs(int r, int c, int previous)
            {
                if (r >= matrix.Length || c >= matrix[0].Length || r < 0 || c < 0 || matrix[r][c] <= previous)
                    return 0;

                if (dictionary.ContainsKey((r, c)))
                    return dictionary[(r, c)];

                var value = new int[]
                            {
                             dfs(r + 1, c, matrix[r][c]),
                             dfs(r - 1, c, matrix[r][c]),
                             dfs(r, c - 1, matrix[r][c]),
                             dfs(r, c + 1, matrix[r][c])
                            }.Max() + 1;

                dictionary.TryAdd((r, c), 0);
                dictionary[(r, c)] = value;

                maxValue = Math.Max(maxValue, value);
                return value;
            }

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    dfs(r, c, -1);
                }
            }
            return maxValue;
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
                    if (s[r] == t[c])
                        dp[r, c] = dp[r + 1, c + 1] + dp[r + 1, c];
                    else
                        dp[r, c] = dp[r + 1, c];
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
        */
    
        //T: O(N^2), S: O(N^2)
        public int MinDistance(string word1, string word2)
        {
            //Bottom up
            var w1l = word1.Length;
            var w2l = word2.Length;
            var dp = new int[w1l + 1, w2l + 1];

            for (var r = 0; r < w1l + 1; r++)
            {
                dp[r, w2l] = w1l - r;
            }
            for (var c = 0; c < w2l + 1; c++)
            {
                dp[w1l, c] = w2l - c;
            }

            for (var r = w1l - 1; r >= 0; r--)
            {
                for (var c = w2l - 1; c >= 0; c--)
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
    }

}