## Reflecting on Reflection in an open source library

---

### What is Reflection?

---

### How is the library using reflection?

---

### What is the alternative?

---

### Lets take a look at the FakeFaker

---?code=src/FakeFaker_interface.cs&lang=cs&title=The FakeFaker interface

@[3]

---?code=src/FakeFaker_class.cs&lang=cs&title=The FakeFaker class

@[11-21]
@[13-14]
@[18]

---

### What the F does F do?!
#### Who needs descriptive method names @emoji[eyes]

---

@ul

- Looks for **"{FakerName.Method}"**
- Replaces with the result of a call to the faker method

@ulend

---

### So this

---

@size[0.7em]("My name is {Faker.FirstName} {Faker.LastName}")

---

### Turns into this

---

@size[0.7em]("My name is John Smith")

---

### How does it look without reflection?

---?code=src/FakeFaker_without_reflection.cs&lang=cs&title=FakeFaker without reflection

### How does it look WITH reflection?

---?code=src/FakeFaker_with_reflection.cs&lang=cs&title=FakeFaker using reflection
