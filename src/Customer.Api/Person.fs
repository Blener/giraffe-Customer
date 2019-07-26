module Person

open System

type Address =
    {
        City : string
        State : string
        Street : string
        Suite: string
        ZipCode : string
    }
    
type Contact =
    {
        Email: string
        Phone1: string
        Phone2: string
    }
    
type Person =
    {
        Id : Guid
        FirstName : string
        LastName : string
        UserName : string
        Address : Address
        Contact: Contact
        DateOfBirth : DateTime
    }
    
let fakePerson () =
    let faker = Bogus.Faker<Person>().CustomInstantiator(fun p ->
        {
            Id = Guid.NewGuid()
            FirstName = p.Person.FirstName
            LastName = p.Person.LastName
            UserName = p.Person.UserName
            Address =
                {
                    City = p.Person.Address.City
                    State = p.Person.Address.State
                    Street = p.Person.Address.Street
                    Suite = p.Person.Address.Suite
                    ZipCode = p.Person.Address.ZipCode
                }
            Contact =
                {
                    Email = p.Person.Email
                    Phone1 = p.Person.Phone
                    Phone2 = ""
                }
            DateOfBirth = p.Person.DateOfBirth
        })
    faker.Generate()
    
let generatePersons quantity =
    let persons =
        Seq.init quantity (fun p -> p)
        |> Seq.map (fun _ -> fakePerson())
            
    persons