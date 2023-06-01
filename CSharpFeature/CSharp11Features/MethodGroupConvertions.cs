using FluentAssertions;
using FluentAssertions.Equivalency;

namespace CSharpFeature.CSharp11Features;

public class MethodGroupConvertions
{


    public static void Assertions()
    {
        
        var user = new User("John", "P@$$w0rd", 42, 98, DateTimeOffset.Now,
            new Address
            (
                City: "New York",
                State: "NY",
                ZipCode: "10001",
                Street: "Main Street",
                DateTimeOffset: DateTimeOffset.Now
            ));
        var anotherUser = new User("John", "P@$$w0rd", 40, 30, DateTimeOffset.Now,
            new Address
            (
                City: "New York",
                State: "NY",
                ZipCode: "10001",
                Street: "Main Street",
                DateTimeOffset: DateTimeOffset.Now
            ));

        user.Should().BeEquivalentTo(anotherUser, ExcludingCertainProperties);
        user.Address.Should().BeEquivalentTo(anotherUser.Address, ExcludingCertainProperties);

    }

    private static EquivalencyAssertionOptions<User> ExcludingCertainProperties(EquivalencyAssertionOptions<User> _)
    {
        return _
            .Excluding(x => x.Age)
            .Excluding(x => x.Phone)
            .Excluding(x => x.Address)
            .Using<DateTimeOffset>(y => y.Subject
                .Should()
                .BeCloseTo(y.Expectation, TimeSpan.FromHours(1)))
            .WhenTypeIs<DateTimeOffset>();
    }

    private static EquivalencyAssertionOptions<Address> ExcludingCertainProperties(
        EquivalencyAssertionOptions<Address> _)
    {
        return _
            .Excluding(x => x.ZipCode)
            .Excluding(x => x.Street)
            .Using<DateTimeOffset>(y => y.Subject
                .Should()
                .BeCloseTo(y.Expectation, TimeSpan.FromHours(1)))
            .WhenTypeIs<DateTimeOffset>();
    }


    private record User(string Username, string Password, int Age, int Phone, DateTimeOffset DateTimeOffset,
        Address Address);

    private record Address(string Street, string City, string State, DateTimeOffset DateTimeOffset, string ZipCode);


}