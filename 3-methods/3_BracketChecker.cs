using System;

/// <summary>
/// A class to check the correctness of bracket placement in an arithmetic expression
/// </summary>
public class BracketChecker
{
    private char[] stack;  // An array that represents the stack of characters used for tracking brackets
    private int top;       // The index of the top element in the bracket stack

    /// <summary>
    /// Initializes a new instance of the BracketChecker class with the specified capacity
    /// </summary>
    /// <param name="capacity">The maximum capacity of the bracket stack</param>
    public BracketChecker(int capacity)
    {
        stack = new char[capacity];
        top = -1;
    }

    /// <summary>
    /// Check if the given arithmetic expression has correctly placed brackets
    /// </summary>
    /// <param name="expression">The arithmetic expression to check</param>
    /// <returns>True if brackets are correctly placed, false otherwise</returns>
    public bool AreBracketsPlacedCorrectly(string expression)
    {
        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            if (c == '(')
            {
                Push(c);
            }
            else if (c == ')')
            {
                if (top == -1 || stack[top] != '(')
                {
                    Console.WriteLine($"No, unexpected closing bracket at position {i}");
                    return false;
                }
                Pop();
            }
        }

        if (top == -1)
        {
            Console.WriteLine("Yes, brackets are correctly placed");
            return true;
        }
        else
        {
            Console.WriteLine($"No, {top + 1} unmatched opening brackets");
            return false;
        }
    }

    /// <summary>
    /// Pushes a character onto the bracket stack
    /// </summary>
    /// <param name="bracket">The character to push onto the stack</param>
    /// <remarks>
    /// This method adds the specified character to the top of the bracket stack if there is available space
    /// If the stack is already full, it will display an error message and not modify the stack
    /// </remarks>
    private void Push(char bracket)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("error");
            return;
        }

        stack[++top] = bracket;
    }

    /// <summary>
    /// Pops a character from the bracket stack
    /// </summary>
    /// <remarks>
    /// This method removes the character from the top of the bracket stack if the stack is not empty
    /// If the stack is already empty, it will display an error message and not modify the stack
    /// </remarks>
    private void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("error");
            return;
        }

        top--;
    }
}

class BracketCheckerProgram
{
    static void Main()
    {
        Console.WriteLine("Enter an expression to check brackets:");
        string expression = Console.ReadLine();
        BracketChecker bracketChecker = new BracketChecker(expression.Length);
        bracketChecker.AreBracketsPlacedCorrectly(expression);
    }
}
