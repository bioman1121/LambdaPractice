using System;


class Program
{
    public delegate bool Judgement(int value);

    static void Main()
    {
        int[] numbers = new[] { 1, 2, 4, };

        // デリゲート（メソッドを変数のように扱う仕組み）を使用しない記法
        Console.WriteLine("偶数をカウント");
        Console.WriteLine(CountIsEven(numbers));    // 偶数以外のカウント条件を設定したい場合は別メソッド

        // C#初期 デリゲートを使用する記法
        Judgement judge = IsEven;
        Console.WriteLine("偶数をカウント：デリゲートを使用");
        Console.WriteLine(Count(numbers, judge));

        // C#初期 デリゲートを使用する記法（関数をそのまま呼び出し）
        Console.WriteLine("偶数をカウント：デリゲートを使用（関数をそのまま呼び出し）");
        Console.WriteLine(Count(numbers, IsEven));

        // C#2.0 デリゲートを使用する記法（匿名メソッド）
        Console.WriteLine("偶数をカウント：デリゲートを使用（引数に関数を直接記述）");
        Console.WriteLine(CountByAnonimousMethod(numbers, delegate(int n) { return n % 2 == 0; }));

        // C#3.0 ラムダ式の記法（冗長）
        Console.WriteLine("偶数をカウント：ラムダ式を使用（冗長）");
        Predicate<int> judge2 =
            (int n) =>
            {
                if (n % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
        Console.WriteLine(CountByAnonimousMethod(numbers, judge2));

        // C#3.0 ラムダ式の記法
        Console.WriteLine("偶数をカウント：ラムダ式を使用");
        Console.WriteLine(CountByAnonimousMethod(numbers, n => n % 2 == 0));

        Console.ReadLine();
    }



    private static int CountIsEven(int[] numbers)
    {
        int count = 0;
        foreach (int n in numbers) 
        {
            if(n%2==0) count++;
        }
        return count;
    }

    static bool IsEven(int n)
    {
        return (n % 2 == 0);
    }

    static int Count(int[] numbers, Judgement judge)
    {
        int count = 0;
        foreach (int n in numbers)
        {
            if (judge(n)) count++;
        }
        return count;
    }

    // public delegate bool Predicate<in T>(T obj)
    // Predicateはジェネリック版のデリゲート
    // Predicate<int> judge　は、「int型の引数で、boolを返すメソッド　judgeが引数」
    private static int CountByAnonimousMethod(int[] numbers, Predicate<int> judge)
    {
        int count = 0;
        foreach (int n in numbers)
        {
            if (judge(n)) count++;
        }
        return count;
    }

}






