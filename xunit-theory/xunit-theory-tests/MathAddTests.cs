namespace xunit_theory_tests;

public class MathAddTests
{
  // InlineData example
  [Theory]
  [InlineData(1, 2, 3, 6)]
  [InlineData(1, null, 3, 4)]
  [InlineData(1, null, null, 1)]
  public void Add_ReturnsCorrectValue(int? a, int? b, int? c, int expected)
  {
    var result = Math.Add(a, b, c);

    Assert.Equal(expected, result);
  }

  // ClassData -> IEnumerable<object[]> example
  public class ClassDataEnumerableGenerator : IEnumerable<object[]>
  {
    private readonly IList<object[]> data =
    [
      [1, 2, 3, 6],
      [1, null, 3, 4],
      [1, null, null, 1],
    ];
      
    public IEnumerator<object[]> GetEnumerator() => data.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
  }

  [Theory]
  [ClassData(typeof(ClassDataEnumerableGenerator))]
  public void ClassDataEnumerable_Add_ReturnsCorrectValue(int? a, int? b, int? c, int expected)
  {
    var result = Math.Add(a, b, c);

    Assert.Equal(expected, result);
  }

  // ClassData -> TheoryData<classtype> example
  public record TestData(int? a, int? b, int? c, int expected);
  public class ClassDataTheoryDataGenerator : TheoryData<TestData>
  {
    public ClassDataTheoryDataGenerator()
    {
      Add(new TestData(1, 2, 3, 6));
      Add(new TestData(1, null, 3, 4));
      Add(new TestData(1, null, null, 1));
    }
  }

  [Theory]
  [ClassData(typeof(ClassDataTheoryDataGenerator))]
  public void ClassDataTheoryData_Add_ReturnsCorrectValue(TestData testData)
  {
    var result = Math.Add(testData.a, testData.b, testData.c);

    Assert.Equal(testData.expected, result);
  }
  
  // MemberData
  public static class MemberDataGenerator
  {
    public static IEnumerable<object[]> TestData()
    {
      yield return new object[] { 1, 2, 3, 6 };
      yield return new object[] { 1, null, 3, 4 };
      yield return new object[] { 1, null, null, 1 };
    }
  }
  
  [Theory]
  [MemberData(nameof(MemberDataGenerator.TestData), MemberType = typeof(MemberDataGenerator))]
  public void MemberDataEnumerable_Add_ReturnsCorrectValue(int? a, int? b, int? c, int expected)
  {
    var result = Math.Add(a, b, c);

    Assert.Equal(expected, result);
  }
}