static bool Is_prime(int n)
        {
            int num=2;
            int end=2;

            while(end*end<=n)
            {
                end++;
            }

            while(n%num!=0)
            {
                if(num<end)
                    num++;
                else
                    return true;
            }
            
            return false;
        }