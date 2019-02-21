### Here is a
# @color[#DC143C](Simple)
## example

---

```cs
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName() => $"{FirstName} {LastName}";
}
```

@[1-7](Define a simple @color[#DC143C](`Person`) class)
@[3-4](Add some @color[#DC143C](properties))
@[6](Add a @color[#DC143C](method))

---

### Now we can use
# @color[#DC143C](reflection)
### on the class

---
@transition[none]

```cs
var person = new Person
{
    FirstName = "John",
    LastName = "Smith"
};
```

@[1-5](Create a new instance of our @color[#DC143C](`Person`) class)
@[3](Set the @color[#DC143C](FirstName) property)
@[4](Set the @color[#DC143C](LastName) property)

---
@transition[none]

```cs
var firstName = person
    .GetType()
    .GetProperty("FirstName")
    .GetValue(person, null);

Console.WriteLine(firstName);
```

@[2](Invoke @color[#DC143C](`GetType`) to get the objects @color[#DC143C](`Type`))
@[3](Look for the @color[#DC143C](FirstName) property on that @color[#DC143C](`Type`))
@[4](Get the @color[#DC143C](value) of that property from the passed in @color[#DC143C](instance) of the object)
@[6](Returns @color[#DC143C](John))

---
@transition[none]

```cs
var lastName = person
    .GetType()
    .GetProperty("LastName")
    .GetValue(person, null);

Console.WriteLine(lastName);
```

@[2](Invoke @color[#DC143C](`GetType`) to get the objects @color[#DC143C](`Type`))
@[3](Look for the @color[#DC143C](LastName) property on that @color[#DC143C](`Type`))
@[4](Get the @color[#DC143C](value) of that property from the passed in @color[#DC143C](instance) of the object)
@[6](Returns @color[#DC143C](Smith))

---
@transition[none]

```cs
var fullName = person
    .GetType()
    .GetMethod("FullName")
    .Invoke(person, null);

Console.WriteLine(fullName);
```

@[2](Invoke @color[#DC143C](`GetType`) to get the objects @color[#DC143C](`Type`))
@[3](Look for the @color[#DC143C](FullName) method on that @color[#DC143C](`Type`))
@[4](Invoke the method to get the @color[#DC143C](value) that is returned)
@[6](Returns @color[#DC143C](John Smith))
