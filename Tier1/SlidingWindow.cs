using System;

namespace SlidingWindow
{
    public class SlidingWindow
    {
        public int SlidingWindowOriginal(string s)
        {
            int beginWindow = 0;
            int endWindow = 0;
            int length = 1;

            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            if (s.Length > 1)
            {
                int currentLength = 1;
                while (endWindow < s.Length)
                {
                    for (int currentIndex = beginWindow; currentIndex < endWindow; currentIndex++)
                    {
                        if (s[currentIndex] == s[endWindow])
                        {
                            beginWindow = currentIndex + 1;
                            currentLength = 1;
                            break;
                        }
                        else
                        {
                            currentLength++;
                        }
                    }
                    if (currentLength > length)
                    {
                        length = currentLength;
                    }
                    endWindow++;
                    currentLength = 1;
                }
            }

            return length;
        }
    }
}