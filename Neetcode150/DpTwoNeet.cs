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
    }
    
}