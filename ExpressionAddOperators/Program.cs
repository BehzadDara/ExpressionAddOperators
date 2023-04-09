#region Problem
/*
Given a string num that contains only digits and an integer target, 
return all possibilities to insert the binary operators '+', '-', and/or '*' between the digits of num 
so that the resultant expression evaluates to the target value.

Note that operands in the returned expressions should not contain leading zeros.

Example 1:
Input: num = "123", target = 6
Output: ["1*2*3","1+2+3"]
Explanation: Both "1*2*3" and "1+2+3" evaluate to 6.

Example 2:
Input: num = "232", target = 8
Output: ["2*3+2","2+3*2"]
Explanation: Both "2*3+2" and "2+3*2" evaluate to 8.

Example 3:
Input: num = "3456237490", target = 9191
Output: []
Explanation: There are no expressions that can be created from "3456237490" to evaluate to 9191.

LeetCode link: https://leetcode.com/problems/expression-add-operators/
*/
#endregion

#region Solution

Console.WriteLine(AddOperators("231", 6));
static IList<string> AddOperators(string num, int target)
{
    if (num.Length == 1)
    {
        if (int.Parse(num) == target)
        {
            return new List<string> { num };
        }
        return new List<string>();
    }

    var result = new List<string>();

    var multiple = (int.Parse(num[0].ToString()) * int.Parse(num[1].ToString())).ToString() + num[2..num.Length];
    result.AddRange(AddOperators(multiple, target));

    var sum = (int.Parse(num[0].ToString()) + int.Parse(num[1].ToString())).ToString() + num[2..num.Length];
    result.AddRange(AddOperators(sum, target));

    var minus = (int.Parse(num[0].ToString()) - int.Parse(num[1].ToString())).ToString() + num[2..num.Length];
    result.AddRange(AddOperators(minus, target));

    return result;
}

#endregion