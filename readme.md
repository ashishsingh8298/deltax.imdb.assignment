Please find the imdbDatabaseScript.sql with then required script for creating the database

This Asp.Net Core Web Api has several endpoints : 

1. Screen 1 : 

	Requirement : Gets all the movies with associated actors and producers
	
	EndPoint : Get Request to https://localhost:44328/api/Movie

	Response : 

	            [
                    {
                        "movieId": 3,
                        "movieName": "Drishyam",
                        "plot": "plot",
                        "posterUrl": "url",
                        "dateOfRelease": "2020-05-12T00:00:00",
                        "producer": {
                            "producerId": 2,
                            "producerFirstName": "Ashish",
                            "producerLastName": "Producer",
                            "bio": "I am going to be a producer",
                            "dob": "1977-10-20T00:00:00",
                            "company": "DeltaX",
                            "gender": "M"
                        },
                        "actors": [
                            {
                                "actorId": 1,
                                "actorFirstName": "Arpit",
                                "actorLastName": "Singh",
                                "bio": "I am want to be a Producer like ashish",
                                "dob": "1998-10-20T00:00:00",
                                "gender": "M"
                            }
                        ]
                    }
                ]


2. Screen 2 : 

	Requirement : Create the movies with associated actors and producers
	
	EndPoint : Post Request to https://localhost:44328/api/Movie

    JsonBody :
                {
                    "movieName": "Tom&Jerry",
                    "plot": "Chuha Billi ka race",
                    "dateOfRelease": "2020-05-20T00:00:00",
                    "posterUrl":"posterUrl",
                    "producer": {
                        "producerId": 2,
                        "producerFirstName": "Ashish",
                        "producerLastName": "Producer",
                        "bio": "I am going to be a producer",
                        "dob": "1977-10-20T00:00:00",
                        "company": "DeltaX",
                        "gender": "M"
                    },
                    "actors": [
                        {
                            "actorId": 1,
                            "actorFirstName": "Arpit",
                            "actorLastName": "Singh",
                            "bio": "I am want to be a Producer like ashish",
                            "dob": "1998-10-20T00:00:00",
                            "gender": "M"
                        }
                    ]
                }
	Response : 
            if Successfully inserted then newly generated movieID will be returned but if it not found then -1 will be returned 

3. Screen 3 : 

	Requirement : Updates the movies with associated actors and producers
	
	EndPoint : Put Request to https://localhost:44328/api/Movie with 
    
    JsonBody: 
                {
                    "movieId": 15,
                    "movieName": "Drishyam Updated",
                    "plot": "plot is twisted now",
                    "posterUrl": "url hi ",
                    "dateOfRelease": "2020-05-12T00:00:00",
                    "producer": {
                        "producerId": 2,
                        "producerFirstName": "Ashish",
                        "producerLastName": "Producer",
                        "bio": "I am going to be a producer",
                        "dob": "1977-10-20T00:00:00",
                        "company": "DeltaX",
                        "gender": "M"
                    },
                    "actors": [
                        {
                                "actorId": 1,
                                "actorFirstName": "Arpit",
                                "actorLastName": "Singh",
                                "bio": "I am want to be a Producer like ashish",
                                "dob": "1998-10-20T00:00:00",
                                "gender": "M"
                            }
                    ]
                }


	Response :
            if Successfully updated then movieID will be returned in this case : 15 but if it not found then -1 will be returned 

4. 

Requirement : Get the movie with movie id
	
	EndPoint : Get Request to https://localhost:44328/api/Movie/15

	Response :
            if it is found then it will be returning the movie object :

                    {
                        "movieId": 15,
                        "movieName": "Drishyam Updated",
                        "plot": "Drishyam Updated",
                        "dateOfRelease": "2020-05-12T00:00:00",
                        "producerId": 2,
                        "posterUrl": "url hi "
                    }

            if it is not found then 404 status as not found will be shown to user

                    {
                        "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                        "title": "Not Found",
                        "status": 404,
                        "traceId": "|45d0ed1d-46f37c6806fe4368."
                    }