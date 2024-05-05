# ead-csharp-cp3

## Instructions

1. Clone this repository to your local machine.
2. Open the solution file `ead-csharp-cp3.sln` in Visual Studio.
3. Run the project by using docker-compose or running the project directly in Visual Studio.
3.1. To run the project using docker-compose, open a terminal and navigate to the root of the project and run the following command:
```shell
docker compose up
```
4. The project will be available at `http://localhost:8080` and the API documentation will be available at `http://localhost:8080/swagger/index.html`.
5. A [Postman collection](/postman_collection.json) is available in the root of the project to test the API.

## Movies API Overview

The Movies API is a simple API that allows you to manage movies. The API has the following endpoints:

### POST /movies

This endpoint allows you to create a new movie. The request body should be a JSON object, below is an example of a valid request body:

```json
{
    "title": "The Lord of the Rings: The Return of the King",
    "original_title": "The Lord of the Rings: The Return of the King",
    "original_language": "English",
    "release_year": 2003,
    "duration": 201,
    "content_rating": "PG-13",
    "genre": "Adventure",
    "budget": 94000000,
    "revenue": 1118888979
}
```

The response will be the movie object that was created.

```json
{
    "id": 1,
    "title": "The Lord of the Rings: The Return of the King",
    "original_title": "The Lord of the Rings: The Return of the King",
    "original_language": "English",
    "release_year": 2003,
    "duration": 201,
    "content_rating": "PG-13",
    "genre": "Adventure",
    "budget": 94000000,
    "revenue": 1118888979
}
```

### GET /movies

This endpoint allows you to retrieve a list of all movies. The response will be a JSON array of movie objects.

```json
[
    {
        "id": 1,
        "title": "The Lord of the Rings: The Return of the King",
        "original_title": "The Lord of the Rings: The Return of the King",
        "original_language": "English",
        "release_year": 2003,
        "duration": 201,
        "content_rating": "PG-13",
        "genre": "Adventure",
        "budget": 94000000,
        "revenue": 1118888979
    }
]
```

### GET /movies/{id}

This endpoint allows you to retrieve a single movie by its ID. The response will be a JSON object representing the movie.

```json
{
    "id": 1,
    "title": "The Lord of the Rings: The Return of the King",
    "original_title": "The Lord of the Rings: The Return of the King",
    "original_language": "English",
    "release_year": 2003,
    "duration": 201,
    "content_rating": "PG-13",
    "genre": "Adventure",
    "budget": 94000000,
    "revenue": 1118888979
}
```

### PUT /movies/{id}

This endpoint allows you to update a movie by its ID. The request body should be a JSON object with the fields you want to update. Below is an example of a valid request body:

```json
{
    "title": "The Lord of the Rings: The Return of the King",
    "original_title": "The Lord of the Rings: The Return of the King",
    "original_language": "English",
    "release_year": 2003,
    "duration": 201,
    "content_rating": "PG-13",
    "genre": "Adventure",
    "budget": 94000000,
    "revenue": 1118888979
}

```

The response will be the updated movie object.

```json
{
    "id": 1,
    "title": "The Lord of the Rings: The Return of the King",
    "original_title": "The Lord of the Rings: The Return of the King",
    "original_language": "English",
    "release_year": 2003,
    "duration": 201,
    "content_rating": "PG-13",
    "genre": "Adventure",
    "budget": 94000000,
    "revenue": 1118888979
}
```

### DELETE /movies/{id}

This endpoint allows you to delete a movie by its ID. The response will be a 204 No Content status code.
