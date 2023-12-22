using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        #region Evaluate Reverse Polish Notation
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

        https://leetcode.com/problems/generate-parentheses/
        */
        /*
        Solution Notes:
        This is a custom solution. Same problem previously done in "iterative" approach on Recursion II card.
        This solution copies the Combinations questions back tracking solution and adapts to parantheses.
        Because it is not iterative, it is significantly faster. About 3 to 4 times. 
        It still has the same verification for correct parantheses combination from stack card question.
        */

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> tempList = new();
            List<string> myList = generator("", tempList, n, 0);
            return myList;
        }
        public List<string> generator(string prev, List<string> tempList, int n, int k)
        {
            if (prev.Length == n * 2 || k == n * 2)
            {
                if (ptv(prev))
                {
                    tempList.Add(prev);
                    return tempList;
                }
                return tempList;
            }
            StringBuilder sb = new StringBuilder(prev);
            sb.Append("(");
            tempList = generator(sb.ToString(), tempList, n, k + 1);
            sb.Length--;
            sb.Append(")");
            tempList = generator(sb.ToString(), tempList, n, k + 1);
            return tempList;
        }
        public bool ptv(string model)
        {
            Stack<char> ms = new();
            char counter = ')';

            for (int i = 0; i < model.Length; i++)
            {
                if (model[i] == '(')
                {
                    ms.Push(counter);
                }
                else
                {
                    if (ms.Count > 0)
                    {
                        ms.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (ms.Count > 0)
                return false;

            return true;
        }

        public IList<string> GenerateParenthesisNeet(int n)
        {
            var result = new List<string>();
            var seq = new StringBuilder();

            void backtrack(int open, int close)
            {
                if (seq.Length == n * 2)
                {
                    result.Add(seq.ToString());
                    return;
                }

                if (open < n)
                {
                    seq.Append("(");
                    backtrack(open + 1, close);
                    seq.Remove(seq.Length - 1, 1);
                }
                if (close < open)
                {
                    seq.Append(")");
                    backtrack(open, close + 1);
                    seq.Remove(seq.Length - 1, 1);
                }

            }

            backtrack(0, 0);

            return result;
        }

        #endregion
        #region Daily Temperatures
        /*
        Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. 
        If there is no future day for which this is possible, keep answer[i] == 0 instead.

        Example 1:
        Input: temperatures = [73,74,75,71,69,72,76,73]
        Output: [1,1,4,2,1,1,0,0]

        Example 2:
        Input: temperatures = [30,40,50,60]
        Output: [1,1,1,0]

        Example 3:
        Input: temperatures = [30,60,90]
        Output: [1,1,0]

        Constraints:
            1 <= temperatures.length <= 105
            30 <= temperatures[i] <= 100

        https://leetcode.com/problems/daily-temperatures/
        */
        /*
        Solution Notes:
        This is a custom solution. It was based on a previously seen solution but neetcode stores 
        the location of found temperature. Mine does both. There is a small amount of runtime speed difference
        less than 30 ms. However memory usage is significantly more about 10%.
        */
        public int[] DailyTemperatures(int[] temperatures)
        {
            Stack<tempRecord> warmer = new();
            int[] comp = new int[temperatures.Length];
            for (int i = 0; i < temperatures.Length; i++)
            {
                if (warmer.Count > 0 && warmer.Peek().warmness < temperatures[i])
                {
                    while (warmer.Count > 0 && warmer.Peek().warmness < temperatures[i])
                    {
                        tempRecord stackPopped = warmer.Pop();
                        comp[stackPopped.location] = i - stackPopped.location;
                    }
                    tempRecord stackPushed = new();
                    stackPushed.location = i;
                    stackPushed.warmness = temperatures[i];
                    warmer.Push(stackPushed);
                }
                else
                {
                    tempRecord temp = new();
                    temp.location = i;
                    temp.warmness = temperatures[i];
                    warmer.Push(temp);
                }
            }
            return comp;
        }
        public class tempRecord
        {
            public int location;
            public int warmness;
        }

        public int[] DailyTemperaturesNeet(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            Array.Fill(result, 0);
            var stack = new Stack<int>();

            for (var i = 0; i < temperatures.Length; i++)
            {
                var t = temperatures[i];
                while (stack.Any() && temperatures[stack.Peek()] < t)
                {
                    var prev = stack.Pop();
                    result[prev] = i - prev;
                }
                stack.Push(i);
            }

            return result;
        }
        #endregion
        #region Car Fleet
        /*
        There are n cars going to the same destination along a one-lane road. The destination is target miles away.
        You are given two integer array position and speed, both of length n, where position[i] is the position of the ith car and speed[i] is the speed of the ith car (in miles per hour).
        A car can never pass another car ahead of it, but it can catch up to it and drive bumper to bumper at the same speed. 
        The faster car will slow down to match the slower car's speed. The distance between these two cars is ignored (i.e., they are assumed to have the same position).
        A car fleet is some non-empty set of cars driving at the same position and same speed. Note that a single car is also a car fleet.
        If a car catches up to a car fleet right at the destination point, it will still be considered as one car fleet.
        Return the number of car fleets that will arrive at the destination.

        Example 1:
        Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
        Output: 3
        Explanation:
        The cars starting at 10 (speed 2) and 8 (speed 4) become a fleet, meeting each other at 12.
        The car starting at 0 does not catch up to any other car, so it is a fleet by itself.
        The cars starting at 5 (speed 1) and 3 (speed 3) become a fleet, meeting each other at 6. The fleet moves at speed 1 until it reaches target.
        Note that no other cars meet these fleets before the destination, so the answer is 3.

        Example 2:
        Input: target = 10, position = [3], speed = [3]
        Output: 1
        Explanation: There is only one car, hence there is only one fleet.

        Example 3:
        Input: target = 100, position = [0,2,4], speed = [4,2,1]
        Output: 1
        Explanation:
        The cars starting at 0 (speed 4) and 2 (speed 2) become a fleet, meeting each other at 4. The fleet moves at speed 2.
        Then, the fleet (speed 2) and the car starting at 4 (speed 1) become one fleet, meeting each other at 6. The fleet moves at speed 1 until it reaches target.

        Constraints:

            n == position.length == speed.length
            1 <= n <= 105
            0 < target <= 106
            0 <= position[i] < target
            All the values of position are unique.
            0 < speed[i] <= 106
        Extra Test Case:
         10
        [6,8]
        [3,2]
        https://leetcode.com/problems/car-fleet/
        */
        public int CarFleetNeet(int target, int[] position, int[] speed)
        {
            var pair = new (int, int)[position.Length];
            for (var i = 0; i < position.Length; i++)
            {
                pair[i] = (position[i], speed[i]);
            }

            var stack = new Stack<double>();
            foreach (var (p, s) in pair.OrderByDescending(i => i.Item1))
            {
                stack.Push((target - p) / (double)s);
                if (stack.Count >= 2 && stack.Peek() <= stack.Skip(1).First())
                {
                    stack.Pop();
                }
            }

            return stack.Count;
        }
        //Added because of single pass.
        public int CarFleet(int target, int[] position, int[] speed)
        {
            if (position.Length == 1)
                return 1;

            var stack = new Stack<(int Position, double Duration)>(position.Length);

            Array.Sort(position, speed);

            for (int i = position.Length - 1; i >= 0; i--)
            {
                double distance = target - position[i];
                double duration = distance / speed[i];
                // Boils down to comparing durations
                // if the duration is less than previously seen cars, then it will join a fleet
                // if the duration is more than previously seen cars, it will be in it's own fleet

                ////Console.Out.WriteLine($"({position[i]},{speed[i]}) ({distance},{duration})");
                if (stack.Count == 0 || duration > stack.Peek().Duration)
                {
                    var print = stack.Count > 0 ? stack.Peek().Duration.ToString() : "";
                    ////Console.Out.WriteLine($"(PUSHING ({distance}>{print})");
                    stack.Push((position[i], duration));
                }
            }

            return stack.Count;
        }

        #endregion
        #region Largest Rectangle in Histogram
        /* WIP
        https://leetcode.com/problems/largest-rectangle-in-histogram/
        */
        #endregion

    }
}