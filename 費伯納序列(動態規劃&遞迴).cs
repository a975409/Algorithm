static int[] nums=new int[1000];
static int dpafib(int n)
{
	if(nums[n]==0)
	{
		if(n<=1)
			nums[n]=n;
		else
			nums[n]= fib(n-1)+fib(n-2);
	}

	return nums[n];
}