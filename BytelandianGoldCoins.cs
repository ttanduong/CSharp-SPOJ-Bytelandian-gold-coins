using System;
					
public class Program
{
	public static void Main()
	{
		string line;
        while ((line = Console.ReadLine()) != null)
        {
            Console.WriteLine(dollarMemoi(int.Parse(line)));
        } 					
	}
	
	/* Recursion
	 * Input: 0 <= n <= 1000000000 
	 * Time limit if input = 1000000000
	 */
	static long dollarRecur(long n)
	{
		long a = n/2, b = n/3, c = n/4;
		if (a + b + c > n)
			return dollarRecur(a) + dollarRecur(b) + dollarRecur(c);
		else return n;
	}
	
	/* Tabulation
	 * Input: 0 <= n <= 1000000000 
	 * Out of memory if input = 1000000000
	 */
	static long dollarTabul(long n)
	{
		long[] coin = new long[n + 1];
		
		for (long i = 0; i <= n; i++)
		{
			if (i < 12) coin[i] = i;
			else
				coin[i] = coin[i/2] + coin[i/3] + coin[i/4];
		}				
		
		return coin[n];
	} 
	
	/* Memoization
	 * Input: 0 <= n <= 1000000000 
	 * Output: OK
	 */
	static long dollarMemoi(long n)
	{
		//Create an array to cache first 1000000 value  
		long[] coin = new long[1000000];
		for (long i = 0; i < coin.Length; i++)
		{
			coin[i] = -1;
		}
		return coinChange(coin, n);
	}
	
	static long coinChange(long[] a, long n)
	{
		if (n >= a.Length)
		{
			return coinChange(a, n/2) + coinChange(a, n/3) + coinChange(a, n/4);
		}
		else if (a[n] == -1) 
		{
			if ((n/2 + n/3 + n/4) <= n) a[n] = n;
			else
				a[n] = coinChange(a, n/2) + coinChange(a, n/3) + coinChange(a, n/4);
		}	
		return a[n];
	}
}
