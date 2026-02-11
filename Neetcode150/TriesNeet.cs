using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class TriesNeet
    {
        #region Implement Trie (Prefix Tree)
        /*
        A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

        Implement the Trie class:

            Trie() Initializes the trie object.
            void insert(String word) Inserts the string word into the trie.
            boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
            boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.

        Example 1:
        Input
        ["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
        [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
        Output
        [null, null, true, false, true, null, true]

        Explanation
        Trie trie = new Trie();
        trie.insert("apple");
        trie.search("apple");   // return True
        trie.search("app");     // return False
        trie.startsWith("app"); // return True
        trie.insert("app");
        trie.search("app");     // return True

        Constraints:
        1 <= word.Length, prefix.Length <= 2000
        word and prefix consist only of lowercase English letters.
        At most 3 * 104 calls in total will be made to insert, search, and startsWith.

        */
        public class Trie
        {
            public NodeArr root;
            public Trie()
            {
                root = new NodeArr();
            }

            public void Insert(string word)
            {
                var cur = root;

                foreach (char c in word)
                {
                    int let = c - 'a';
                    if (cur.children[let] == null)
                        cur.children[let] = new NodeArr();

                    cur = cur.children[let];
                }
                cur.isWord = true;
            }

            public bool Search(string word)
            {
                var cur = root;

                foreach (char c in word)
                {
                    int let = c - 'a';
                    if (cur.children[let] == null)
                        return false;

                    cur = cur.children[let];
                }

                return cur.isWord;
            }

            public bool StartsWith(string prefix)
            {
                var cur = root;

                foreach (char c in prefix)
                {
                    int let = c - 'a';
                    if (cur.children[let] == null)
                        return false;

                    cur = cur.children[let];
                }

                return true;
            }
        }

        public class NodeArr
        {
            public NodeArr[] children;
            public bool isWord;

            public NodeArr()
            {
                children = new NodeArr[26];
                isWord = false;
            }
        }
        #endregion
        #region Design Add and Search Words Data Structure
        /*
        Design a data structure that supports adding new words and finding if a string matches any previously added string.

        Implement the WordDictionary class:
            WordDictionary() Initializes the object.
            void addWord(word) Adds word to the data structure, it can be matched later.
            bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.

        Example:
        Input
        ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
        [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
        Output
        [null,null,null,null,false,true,true,true]

        Explanation
        WordDictionary wordDictionary = new WordDictionary();
        wordDictionary.addWord("bad");
        wordDictionary.addWord("dad");
        wordDictionary.addWord("mad");
        wordDictionary.search("pad"); // return False
        wordDictionary.search("bad"); // return True
        wordDictionary.search(".ad"); // return True
        wordDictionary.search("b.."); // return True

        Constraints:
        1 <= word.length <= 25
        word in addWord consists of lowercase English letters.
        word in search consist of '.' or lowercase English letters.
        There will be at most 2 dots in word for search queries.
        At most 104 calls will be made to addWord and search.


        https://leetcode.com/problems/design-add-and-search-words-data-structure/
        Extra Test Cases:
        ["WordDictionary","addWord","addWord","search","search","search","search","search","search"] 14 / 29 testcases passed
        [[],["a"],["a"],["."],["a"],["aa"],["a"],[".a"],["a."]] 
        ["WordDictionary","addWord","addWord","addWord","addWord","search","search","addWord","search","search","search","search","search","search"] 15 / 29 testcases passed
        [[],["at"],["and"],["an"],["add"],["a"],[".at"],["bat"],[".at"],["an."],["a.d."],["b."],["a.d"],["."]]

        ["WordDictionary","addWord","addWord","addWord","addWord","search","search","addWord","search","search","search","search","search","search"]
        [[],["at"],["and"],["an"],["add"],["a"],[".at"],["bat"],[".at"],["an."],["a.d."],["b."],["a.d"],["."]]
        Expected:[null,null,null,null,null,false,false,null,true,true,false,false,true,false]
        */

        public class Node3
        {
            public Node3[] children;
            public char val;
            public bool isWord;

            public Node3()
            {
                children = new Node3[26];
                isWord = false;
            }
        }

        public class WordDictionary
        {
            Node3 root3;
            public WordDictionary()
            {
                root3 = new Node3();
            }

            public void AddWord(string word)
            {
                Node3 curr = root3;

                foreach (char c in word)
                {
                    int let = c - 'a';
                    if (curr.children[let] == null)
                        curr.children[let] = new Node3();

                    curr = curr.children[let];
                }

                curr.isWord = true;
            }

            public bool Search(string word)
            {
                return dfs(word, 0, root3);
            }

            public bool dfs(string word, int index, Node3 head)
            {
                Node3 curr = head;

                if (head == null)
                    return false;

                for (int i = index; i < word.Length; i++)
                {
                    int let = word[i] - 'a';

                    if (word[i] == '.')
                    {

                        foreach (Node3 item in curr.children)
                        {
                            if (dfs(word, i + 1, item))
                                return true;
                        }
                        return false;
                    }
                    else
                    {
                        if (curr.children[let] == null)
                            return false;
                        else
                        {
                            curr = curr.children[let];
                        }
                    }
                }

                if (curr.isWord == true)
                    return true;

                return false;
            }

        }

        /*Dictionary based solution keeping it as a alternative,it's slower 
        so not a replacement for the array based one.
        
        public class TrieNode2
        {
            public Dictionary<char, TrieNode2> childrenMap { get; set; }
            public bool isWord { get; set; }

            public TrieNode2()
            {
                childrenMap = new Dictionary<char, TrieNode2>();
                isWord = false;
            }
        }

        public class WordDictionary
        {
            public TrieNode2 root { get; set; }
            public WordDictionary()
            {
                root = new TrieNode2();
            }

            public void AddWord(string word)
            {
                var cur = root;

                foreach (var element in word)
                {
                    if (!cur.childrenMap.ContainsKey(element))
                    {
                        cur.childrenMap[element] = new TrieNode2();
                    }
                    cur = cur.childrenMap[element];
                }
                cur.isWord = true;
            }

            public bool Search(string word)
            {
                var cur = root;

                return traverse(0, cur, word);

            }

            public bool traverse(int index, TrieNode2 root, string word)
            {
                var cur = root;

                for (int i = index; i < word.Length; i++)
                {
                    if (word[i] == '.')
                    {
                        foreach (var (key, value) in cur.childrenMap)
                        {
                            if (traverse(i + 1, value, word))
                                return true;
                        }
                        return false;
                    }
                    else
                    {
                        if (!cur.childrenMap.ContainsKey(word[i]))
                            return false;

                        cur = cur.childrenMap[word[i]];
                    }
                }
                return cur.isWord;
            }
        }
        */


        #endregion
        #region Word Search II
        /*
        Given an m x n board of characters and a list of strings words, return all words on the board.
        Each word must be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. 
        The same letter cell may not be used more than once in a word.

        Example 1:
        Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
        Output: ["eat","oath"]

        Example 2:
        Input: board = [["a","b"],["c","d"]], words = ["abcb"]
        Output: []

        Constraints:

            m == board.length
            n == board[i].length
            1 <= m, n <= 12
            board[i][j] is a lowercase English letter.
            1 <= words.length <= 3 * 104
            1 <= words[i].length <= 10
            words[i] consists of lowercase English letters.
            All the strings of words are unique.
            Extra Test Cases:
            board = [["a"]]
            words =  ["a"] 42 / 65 testcases passed
            board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]] 63 / 65 testcases passed
            words = ["oath","pea","eat","rain","oathi","oathk","oathf","oate","oathii","oathfi","oathfii"]
        
           C# test case 1:
           char[][] board = new char[][]
            {
            new char[] {'o','a','a','n'},
            new char []{'e','t','a','e'},
            new char []{'i','h','k','r'},
            new char []{'i','f','l','v'},
            };
          string[] words = new string[] {"oath","pea","eat","rain"};
        
        */
        //Neetcode answer to this problem times out at 64th test case.
        //Solution below doesn't.

        class TrieNode3
        {
            public TrieNode3[] children = new TrieNode3[26];
            public int idx = -1;
            public int refs = 0;

            public void AddWord(string word, int i)
            {
                TrieNode3 cur = this;
                cur.refs++;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    if (cur.children[index] == null)
                    {
                        cur.children[index] = new TrieNode3();
                    }
                    cur = cur.children[index];
                    cur.refs++;
                }
                cur.idx = i;
            }
        }
        private List<string> res = new List<string>();

        public List<string> FindWords(char[][] board, string[] words)
        {
            TrieNode3 root = new TrieNode3();
            for (int i = 0; i < words.Length; i++)
            {
                root.AddWord(words[i], i);
            }

            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    Dfs(board, root, r, c, words);
                }
            }

            return res;
        }

        private void Dfs(char[][] board, TrieNode3 node, int r, int c, string[] words)
        {
            if (r < 0 || c < 0 || r >= board.Length ||
                c >= board[0].Length || board[r][c] == '*' ||
                node.children[board[r][c] - 'a'] == null)
            {
                return;
            }

            char temp = board[r][c];
            board[r][c] = '*';
            TrieNode3 prev = node;
            node = node.children[temp - 'a'];
            if (node.idx != -1)
            {
                res.Add(words[node.idx]);
                node.idx = -1;
                node.refs--;
                if (node.refs == 0)
                {
                    node = null;
                    prev.children[temp - 'a'] = null;
                    board[r][c] = temp;
                    return;
                }
            }

            Dfs(board, node, r + 1, c, words);
            Dfs(board, node, r - 1, c, words);
            Dfs(board, node, r, c + 1, words);
            Dfs(board, node, r, c - 1, words);

            board[r][c] = temp;
        }

        #endregion

    }
}