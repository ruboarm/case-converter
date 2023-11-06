# Ruboarm Case Converter
Convert between cases

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

