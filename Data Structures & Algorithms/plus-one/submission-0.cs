public class Solution {
    public int[] PlusOne(int[] digits) {
        
        int carry = 1;

        List<int> result = [];

        for(int i = digits.Length - 1; i >= 0; i--)
        {
            int cur = digits[i];

            if(cur + carry == 10)
            {
                result.Add(0);
                carry = 1; 
            }
            else
            {
                result.Add(cur + carry);
                carry = 0;
            }
        }

        if(carry == 1)
        {
            result.Add(carry);
        }


        var resultArr = result.ToArray();
        Array.Reverse(resultArr);

        return resultArr;
    }
}
