// See https://aka.ms/new-console-template for more information

Console.WriteLine("All integers supplied      : {0}", Math.Add(1, 2, 3));
Console.WriteLine("Only two integers supplied : {0}", Math.Add(1, null, 3));
Console.WriteLine("Only one integer supplied  : {0}", Math.Add(1, null, null));

public static class Math
{
  public static int Add(int? a, int? b, int? c)
  {
    return (a ?? 0) + (b ?? 0) + (c ?? 0);
  }
}
