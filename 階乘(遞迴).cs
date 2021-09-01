static int fac(int n)
{
	if(n>0)
		return n*fac(n-1);
	else
		return 1;
}