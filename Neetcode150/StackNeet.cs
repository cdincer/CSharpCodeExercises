using System.Collections.Generic;

namespace Neetcode150
{
    public class StackNeet
    {
        #region Valid Parantheses
        /*
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
        Extra Test Cases:
        "["
        ")(){}"
        "){"
        "]"
        https://leetcode.com/problems/valid-parentheses/description/
        */

        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>()
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{'
            };

            foreach (char c in s)
            {
                if (!pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
        #endregion
        #region Min Stack
        /*
        Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
        Implement the MinStack class:

            MinStack() initializes the stack object.
            void push(int val) pushes the element val onto the stack.
            void pop() removes the element on the top of the stack.
            int top() gets the top element of the stack.
            int getMin() retrieves the minimum element in the stack.

        You must implement a solution with O(1) time complexity for each function.

        Example 1:

        Input
        ["MinStack","push","push","push","getMin","pop","top","getMin"]
        [[],[-2],[0],[-3],[],[],[],[]]

        Output
        [null,null,null,null,-3,null,0,-2]

        Explanation
        MinStack minStack = new MinStack();
        minStack.push(-2);
        minStack.push(0);
        minStack.push(-3);
        minStack.getMin(); // return -3
        minStack.pop();
        minStack.top();    // return 0
        minStack.getMin(); // return -2

        Constraints:

            -231 <= val <= 231 - 1
            Methods pop, top and getMin operations will always be called on non-empty stacks.
            At most 3 * 104 calls will be made to push, pop, top, and getMin.

        https://leetcode.com/problems/min-stack/
        Extra Test Case:
        ["MinStack","push","push","push","top","pop","getMin","pop","getMin","pop","push","top","getMin","push","top","getMin","pop","getMin"]
        [[],[2147483646],[2147483646],[2147483647],[],[],[],[],[],[],[2147483647],[],[],[-2147483648],[],[],[],[]]
        */
        public class MinStack
        {
            Stack<int> minKeeper;
            Stack<int> intKeeper;
            public MinStack()
            {
                minKeeper = new Stack<int>();
                intKeeper = new Stack<int>();
            }
            public void Push(int val)
            {
                if (minKeeper.Count == 0 && intKeeper.Count == 0)
                {
                    minKeeper.Push(val);
                    intKeeper.Push(val);
                    return;
                }

                if (minKeeper.Count > 0 && val <= minKeeper.Peek())
                {
                    minKeeper.Push(val);
                }
                intKeeper.Push(val);
            }

            public void Pop()
            {
                int intTemp = intKeeper.Peek();
                int minTemp = minKeeper.Peek();

                if (minTemp == intTemp)
                {
                    minKeeper.Pop();
                }
                intKeeper.Pop();
            }

            public int Top()
            {
                return intKeeper.Peek();
            }

            public int GetMin()
            {
                if (minKeeper.Peek() < intKeeper.Peek())
                    return minKeeper.Peek();

                return intKeeper.Peek();
            }
        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(val);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */
        #endregion
        #region  Evaluate Reverse Polish Notation
        /*
        You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.
        Evaluate the expression. Return an integer that represents the value of the expression.

        Note that:
            The valid operators are '+', '-', '*', and '/'.
            Each operand may be an integer or another expression.
            The division between two integers always truncates toward zero.
            There will not be any division by zero.
            The input represents a valid arithmetic expression in a reverse polish notation.
            The answer and all the intermediate calculations can be represented in a 32-bit integer.

        Example 1:
        Input: tokens = ["2","1","+","3","*"]
        Output: 9
        Explanation: ((2 + 1) * 3) = 9

        Example 2:
        Input: tokens = ["4","13","5","/","+"]
        Output: 6
        Explanation: (4 + (13 / 5)) = 6

        Example 3:
        Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
        Output: 22
        Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
        = ((10 * (6 / (12 * -11))) + 17) + 5
        = ((10 * (6 / -132)) + 17) + 5
        = ((10 * 0) + 17) + 5
        = (0 + 17) + 5
        = 17 + 5
        = 22

        Constraints:

            1 <= tokens.length <= 104
            tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].

        https://leetcode.com/problems/evaluate-reverse-polish-notation/description/
        */
        public int EvalRPN(string[] tokens)
        {
            Stack<int> elements = new Stack<int>();
            int sum = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                if (int.TryParse(tokens[i], out int parsed))
                {
                    elements.Push(parsed);
                }
                else
                {
                    switch (tokens[i])
                    {
                        case "+":
                            int b = elements.Pop();
                            int a = elements.Pop();
                            elements.Push(a + b);
                            break;
                        case "-":
                            b = elements.Pop();
                            a = elements.Pop();
                            elements.Push(a - b);
                            break;
                        case "*":
                            b = elements.Pop();
                            a = elements.Pop();
                            elements.Push(b * a);
                            break;
                        case "/":
                            b = elements.Pop();
                            a = elements.Pop();
                            elements.Push(a / b);
                            break;
                        default:
                            //
                            break;
                    }
                }
            }


            return elements.Pop();
        }
        #endregion
        #region Generate Parentheses
        /*
        Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

        Example 1:
        Input: n = 3
        Output: ["((()))","(()())","(())()","()(())","()()()"]

        Example 2:
        Input: n = 1
        Output: ["()"]

        Constraints:
            1 <= n <= 8

        Look up permutation generation / backtracking style solution
        https://leetcode.com/problems/generate-parentheses/
        */

        
        #endregion

    }
}