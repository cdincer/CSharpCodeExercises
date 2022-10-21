using System.Collections.Generic;

namespace Leetcode
{

    public class ValidParentheses
    {/*
    20. Valid Parentheses
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    An input string is valid if:

        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
    Example 1:

    Input: s = "()"
    Output: true

    Example 2:

    Input: s = "()[]{}"
    Output: true

    Example 3:

    Input: s = "(]"
    Output: false

    

    Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.


        https://leetcode.com/problems/valid-parentheses/description/
    */
        public bool IsValid(string s)
        {

            Stack<char> MyStack = new Stack<char>();
            foreach (char letter in s)
            {
                if (MyStack.Count == 0)
                {
                    MyStack.Push(letter);
                }
                else
                {
                    char StackTop = MyStack.Peek();
                    if (StackTop == letter - 1 || StackTop == letter - 2)
                    {
                        MyStack.Pop();
                    }
                    else
                    {
                        MyStack.Push(letter);
                    }
                }
            }

            if (MyStack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}