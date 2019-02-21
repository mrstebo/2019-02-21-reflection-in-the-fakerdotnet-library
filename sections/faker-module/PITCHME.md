### Lets take a look at the
# @color[#DC143C](CODE)

---

@code[cs zoom-01](sections/faker-module/code/FakeFaker.cs)

---
@transition[none]

@code[cs](sections/faker-module/code/IFakeFaker.cs)

---
@transition[none]

@code[cs](sections/faker-module/code/FakeFaker_slim.cs)

@[3-8](Inject the @color[#DC143C](`IFakerContainer`) into the class)
@[10-13](The @color[#DC143C](`F`) method @emoji[heart_eyes])

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/F_method.cs)

@[3](Handle @color[#DC143C](empty) or @color[#DC143C](null) strings @emoji[punch])

@[5](Create a local variable to store the @color[#DC143C](result))
@[6](Create a local variable to store the @color[#DC143C](match) so we can use in it in our `while` loop below)
@[7](Find a @color[#DC143C](match) in the string)
@[9](Create an instance of the specific @color[#DC143C](faker) class)
@[10](Get the @color[#DC143C](value) from invoking the specific method on the faker class)
@[11-14](Inject the new value between the @color[#DC143C](start) and @color[#DC143C](end) and update the @color[#DC143C](result))
@[7-15](Continue doing this until no more matches are found)
@[17](Return the @color[#DC143C](result))
@[6](What does @color[#DC143C](`FakerMatch`) look like?)

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/FakerMatch.cs)

@[3](Did we get a @color[#DC143C](successful) match?)
@[4](If we did, where is the @color[#DC143C](start)?)
@[5](How @color[#DC143C](long) was the match?)
@[6](What @color[#DC143C](name) did we find?)
@[7](What @color[#DC143C](method) did we find?)

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/F_method.cs)

@[7]

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/ExtractMatchFrom_method.cs)

@[3](Example: @color[#DC143C]({Name.FirstName}))
@[1,4](Check if we find a @color[#DC143C](match) in `input`)
@[6](Were we successful?)
@[7-14](@color[#DC143C](Yes))
@[9](Set @color[#DC143C](Success) to true (for our `while` loop))
@[10-11](Extract the @color[#DC143C](Index) and @color[#DC143C](Length) from the @color[#DC143C](match))
@[12](Extract the first capture for the @color[#DC143C](Name))
@[13](Extract the second capture for the @color[#DC143C](Method))
@[15](If there was @color[#DC143C](no match) then return the default `FakerMatch`)
@[15](`Success` will automatically set to @color[#DC143C](`false`))

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/F_method.cs)

@[9]

---
@transition[none]

@code[cs zoom-06](sections/faker-module/code/GetFaker_method.cs)

@[3]
@[3](@color[#DC143C](IgnoreCase) means we can do a case-insensitive search for the property)
@[3](@color[#DC143C](Public) means public members are included in the search)
@[3](@color[#DC143C](Instance) means instance members are to be included in the search)
@[5](@emoji[tada])
@[6](@emoji[boom])

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/F_method.cs)

@[10]

---
@transition[none]

@code[cs zoom-06](sections/faker-module/code/GetValue_method.cs)

@[3](The same flags as the previous method)
@[4](@emoji[tada])
@[5](@emoji[boom])
@[7](Some methods @color[#DC143C](require parameters))
@[7, 13-18](So we use the @color[#DC143C](`DefaultValue`) method)
@[15-16](If the parameter is a @color[#DC143C](ValueType) then we need to create an instance of it)
@[17](Otherwise we can return @color[#DC143C](null))
@[8](Invoke the method on the @color[#DC143C](`_fakerContainer`) with those parameters @emoji[point_up])
@[10](Convert the returning value into a @color[#DC143C](string))

---
@transition[none]

@code[cs zoom-07](sections/faker-module/code/F_method.cs)

@[11-14](@color[#DC143C](Inject) the returned value)
@[17](@color[#DC143C](Return) when we are finished)

---

#### Is it
# @color[#DC143C](DIFFICULT)
### to unit test?

---

# NO
@emoji[sunglasses]

---

@code[cs zoom-06](sections/faker-module/code/FakeFakerTests.cs)

@[2, 4](The tests are using @color[#DC143C](NUnit) and @color[#DC143C](FakeItEasy))
@[15, 19](We create a @color[#DC143C](mock) instance of the @color[#DC143C](`IFakerContainer`))
@[16,20](We @color[#DC143C](inject) the mock into the @color[#DC143C](`FakeFaker`) instance)
@[32-41](It @color[#DC143C](replaces the placeholders) with calls to the faker methods)
@[22-30](It handles @color[#DC143C](duplicates))
@[43-52](It is @color[#DC143C](case-insensitive))
@[54-60](It handles @color[#DC143C](empty strings))
@[82-86](It handles @color[#DC143C](null))
@[62-70](It @color[#DC143C](throws an error) if it can't find the faker module)
@[72-80](And it @color[#DC143C](throws an error) if it can't find the method on the faker module)

---

#### Is there a way to do this
# @color[#DC143C](WITHOUT)
## reflection?

---

# @color[#DC143C](YES)
@emoji[eyes]

---

@snap[fragment]
#### A
@snapend

@snap[fragment]
### @color[#DC543C](REALLY)
@snapend

@snap[fragment]
## @color[#DCA43C](BIG)
@snapend

@snap[fragment]
# @color[#DC143C](SWITCH)
@snapend

---

# @color[#DC143C](END)
