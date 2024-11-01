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
        public class TrieNode
        {
            public TrieNode()
            {
                childrenMap = new Dictionary<char, TrieNode>();
            }
            public Dictionary<char, TrieNode> childrenMap { get; set; }
            public bool isWord { get; set; }
        }
        public class Trie
        {

            private TrieNode root;
            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                var cur = root;
                foreach (var c in word)
                {
                    if (!cur.childrenMap.ContainsKey(c))
                    {
                        cur.childrenMap[c] = new TrieNode();
                    }
                    cur = cur.childrenMap[c];
                }
                cur.isWord = true;
            }

            public bool Search(string word)
            {
                var node = traverse(word);
                return node != null && node.isWord;
            }

            public bool StartsWith(string prefix)
            {
                var node = traverse(prefix);
                return node != null;
            }

            private TrieNode traverse(string path)
            {
                var cur = root;

                foreach (var c in path)
                {
                    if (cur.childrenMap.ContainsKey(c))
                    {
                        cur = cur.childrenMap[c];
                    }
                    else
                    {
                        return null;
                    }
                }
                return cur;
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
        */
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


        /*Array based solution that has a faster run time and smaller memory foot-print
        public class WordDictionary {
            Node root;
            public WordDictionary() {
                root = new Node();
            }
            
            public void AddWord(string word) {
                Node curr = root;

                foreach(char c in word)
                {
                    int let = c - 'a';
                    if(curr.children[let] == null)
                    curr.children[let] = new Node();

                    curr = curr.children[let];
                }

                curr.isWord = true;
            }
            
            public bool Search(string word) {
                return dfs(word,0,root);
            }

            public bool dfs(string word, int index,Node head)
            {
                Node curr = head;

                if(head == null)
                return false;

                for(int i = index; i < word.Length; i++)
                {
                    int let = word[i] - 'a';

                    if(word[i] == '.')
                    {

                        foreach(Node item in curr.children)
                        {
                            if(dfs(word,i + 1,item))
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        if(curr.children[let] == null)
                        return false;
                        else
                        {
                            curr = curr.children[let];
                        }
                    }
                }

                if(curr.isWord == true)
                return true;

                return false;
            }

        }

        public class Node
        {
            public Node[] children;
            public char val;
            public bool isWord;

            public Node()
            {
                children = new Node[26];
                isWord = false;
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
        public IList<string> FindWords(char[][] board, string[] words)
        {
            int rl = board.Length;
            int cl = board[0].Length;
            List<string> res = new();

            //build trie
            Node root = new();
            foreach (string word in words)
            {
                Node node = root;
                foreach (char c in word)
                {
                    if (node.Next[c] is null) node.Next[c] = new Node();
                    node = node.Next[c];
                }
                node.Word = word;
            }

            //do dfs
            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    Dfs(r, c, root);
                }
            }

            return res;

            void Dfs(int row, int col, Node node)
            {
                if (row < 0 || col < 0 || row == rl || col == cl) return;
                char c = board[row][col];
                if (c == '/' || node.Next[c] == null) return;
                node = node.Next[c];

                if (node.Word is not null)
                {
                    res.Add(node.Word);
                    node.Word = null;
                }

                board[row][col] = '/';
                Dfs(row - 1, col, node);
                Dfs(row + 1, col, node);
                Dfs(row, col + 1, node);
                Dfs(row, col - 1, node);
                board[row][col] = c;
            }
        }


        public class Node
        {
            public Node[] Next { get; } = new Node['z' + 1];
            public string Word { get; set; }
        }
        #endregion

    }
}