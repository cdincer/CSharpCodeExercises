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
        1 <= word.length, prefix.length <= 2000
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
            public Dictionary<char, TrieNode2> Children;
            public bool EndOfWord;

            public TrieNode2()
            {
                Children = new Dictionary<char, TrieNode2>();
                EndOfWord = false;
            }
        }

        public class WordDictionary
        {

            public TrieNode2 root;

            public WordDictionary()
            {
                root = new TrieNode2();
            }

            public void AddWord(string word)
            {
                var current = root;
                for (var i = 0; i < word.Length; i++)
                {
                    if (!current.Children.ContainsKey(word[i]))
                    {
                        var newNode = new TrieNode2();
                        current.Children.Add(word[i], newNode);
                    }
                    current = current.Children[word[i]];
                }
                current.EndOfWord = true;
            }

            public bool Search(string word)
            {
                return dfs(0, root, word);
            }

            private bool dfs(int index, TrieNode2 root, string word)
            {
                var currentNode = root;

                for (var i = index; i < word.Length; i++)
                {
                    var letter = word[i];
                    if (letter == '.')
                    {
                        foreach (var (key, value) in currentNode.Children)
                        {
                            if (dfs(i + 1, value, word))
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                    else
                    {
                        if (!currentNode.Children.ContainsKey(letter))
                        {
                            return false;
                        }
                        currentNode = currentNode.Children[letter];
                    }
                }
                return currentNode.EndOfWord;
            }
        }

        /**
         * Your WordDictionary object will be instantiated and called as such:
         * WordDictionary obj = new WordDictionary();
         * obj.AddWord(word);
         * bool param_2 = obj.Search(word);
         */
        #endregion
    }
}