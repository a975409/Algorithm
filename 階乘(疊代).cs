static void iterative(int n)
        {
            for(int j=1;j<=n;j++)
            {
                int num=1;
                for(int i=1;i<=j;i++)
                {
                    num*=i;
                }

                Console.WriteLine($"{j}!={num}");
            }
        }