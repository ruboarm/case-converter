# Ruboarm Case Converter
Convert between possible 4 cases:
1. Snake Case
2. Pascal Case
3. Kebab Case
4. Camel Case

The conversion is simple and works with extension methods. <br>
In order to convert between cases you need to provide case string and use needed conversion type to convert into it.

### Example Usage
```Snake Case convertions
var snakeCase = "user_account_id";

var camelCase = snakeCase.ToCamelCase();
// Output - "userAccountId"

var kebabCase = snakeCase.ToKebabCase();
// Output - "user-account-id"

var pascalCase = snakeCase.ToPascalCase();
// Output - "UserAccountId"
```

