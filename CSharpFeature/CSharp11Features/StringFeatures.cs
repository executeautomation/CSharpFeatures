namespace CSharpFeature.CSharp11Features;

public class StringFeatures
{
    public static void StringLiterals()
    {
        var dynamicData = "LoginLink";

        var htmlSource =
            $"""
    <body>
        <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
        <li><a href="/">Home</a></li>
        <li><a href="/Home/About">About</a></li>
        <li><a href="/Employee">Employee List</a></li>
        </ul>
        <ul class="nav navbar-nav navbar-right">
        <li><a href="/Account/Register" id="registerLink">{dynamicData}</a></li>
        <li><a href="/Account/Login" id="loginLink">Login</a></li>
    </body>
    """;

        Console.WriteLine(htmlSource);
    }

    public static void StringLiteralsWithInterpolation()
    {
        var jsonDynamicData = "Service";
        var jsonString = $$"""        
    {
    "openapi": "3.0.1",
    "responses": {
        "200": {
            "description": "Success",
            "content": {
                "text/plain": {
                    "schema": {
                        "$ref": "#/components/schemas/{{jsonDynamicData}}"
                    }
                },
                "application/json": {
                    "schema": {
                        "$ref": "#/components/schemas/{{jsonDynamicData}}"
                    }
                },
                "text/json": {
                    "schema": {
                        "$ref": "#/components/schemas/{{jsonDynamicData}}"
                    }
                }
            },
    """;

        Console.WriteLine(jsonString);
    }

    public static void StringExpressions()
    {
        var salary = 10000;

        Console.WriteLine($"The Salary Range is: {
            salary switch
            {
                < 1000 => "Low range Salary",
                <= 2500 => "Mid range Salary",
                > 9000 => "Awesome Salary",
                _ => "Salary does not match"
            }
        }");
    }
}