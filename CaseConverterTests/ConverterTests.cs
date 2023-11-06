using Ruboarm.CaseConverter;

namespace CaseConverterTests;

public class ConverterTests
{
    [Fact]
    public void Snake_Case_Conversion()
    {
        var snakeCase = "user_account_id";

        var camelCase = snakeCase.ToCamelCase();
        Assert.Equal("userAccountId", camelCase);
        
        var kebabCase = snakeCase.ToKebabCase();
        Assert.Equal("user-account-id", kebabCase);
        
        var pascalCase = snakeCase.ToPascalCase();
        Assert.Equal("UserAccountId", pascalCase);
    }
    
    [Fact]
    public void Camel_Case_Conversion()
    {
        var camelCase = "userAccountId";

        var snakeCase = camelCase.ToSnakeCase();
        Assert.Equal("user_account_id", snakeCase);
        
        var kebabCase = camelCase.ToKebabCase();
        Assert.Equal("user-account-id", kebabCase);
        
        var pascalCase = camelCase.ToPascalCase();
        Assert.Equal("UserAccountId", pascalCase);
    }
    
    [Fact]
    public void Kebab_Case_Conversion()
    {
        var kebabCase = "user-account-id";

        var camelCase = kebabCase.ToCamelCase();
        Assert.Equal("userAccountId", camelCase);
        
        var snakeCase = kebabCase.ToSnakeCase();
        Assert.Equal("user_account_id", snakeCase);
        
        var pascalCase = kebabCase.ToPascalCase();
        Assert.Equal("UserAccountId", pascalCase);
    }
    
    [Fact]
    public void Pascal_Case_Conversion()
    {
        var pascalCase = "UserAccountId";

        var camelCase = pascalCase.ToCamelCase();
        Assert.Equal("userAccountId", camelCase);
        
        var kebabCase = pascalCase.ToKebabCase();
        Assert.Equal("user-account-id", kebabCase);
        
        var snakeCase = pascalCase.ToSnakeCase();
        Assert.Equal("user_account_id", snakeCase);
    }
}