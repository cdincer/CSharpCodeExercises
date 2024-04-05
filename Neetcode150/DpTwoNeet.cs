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
        https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
        */
        #endregion
    }
    
}