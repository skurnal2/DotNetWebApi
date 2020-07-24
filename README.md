# Vintri Technologies Exercise
## Endpoints
- GET : http://localhost:[Port]/api/beer?name=[beer_name]    
- POST : http://localhost:[Port]/api/beer/id
    - Body should contain Username, Rating, Comments 


## Tasks

#### Task 1
This takes in a json POST request containing Username, Rating, Comments in the body and id as in the parameter. First, checks whether the supplied id exists or not. Will return status code with whether it passed or failed along with the error message or success message if it is successfully able to complete the task. Doing this will update the database.json file with the supplied  details in POST request.

#### Task 2
retrieves the values using LINQ query and shows the Beer Info using Punk Api along with the values present in database.json file. 
Example Data: for GET request and name supplied = "vote sepp"
``` json
[
     {
        "id": 112,
        "name": "Vote Sepp",
        "description": "Vote Sepp is a single hop wheat beer brewed to a session strength, with hibiscus flower, which gives it an impressively vibrant shade of pink. What Vote Sepp lacks in complexity, it more than makes up for in a perfect balance of tartness, bitterness and body.",
        "userRatings": [
            {
                "username": "ron@gmail.com",
                "rating": 4.0,
                "comments": "It was pretty good."
            },
            {
                "username": "ronald@yahoo.com",
                "rating": 5.0,
                "comments": "Just loved it! Will definitely try again!"
            }
        ]
    }
]
```

#### Task 3
Added ActionFilter so that it checks first whether the regex  matches the username to be email or not. If it matches, then continues onto the action method otherwise, returns a message.

#### Task 4
I am fairly new to Unit Testing Web API, so I couldn't figure out the correct way of doing it.