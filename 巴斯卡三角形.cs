static int Pascal(int r,int n) //列出指定行列的數值
        {
            if(n==0)
                return 1;
            else
                return Pascal(r,n-1)*(r-n+1)/n;
        }