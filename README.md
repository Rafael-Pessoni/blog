# Blog API

Project based on [**.NET 8**](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). An example API for managing blog posts and their comments.

---
### How to Run the Application

Using the [docker-compose.yml](docker-compose.yml) file, you can set up the entire environment. You need [Docker](https://www.docker.com/) and [Docker Compose](https://docs.docker.com/compose/) installed and configured on your machine. Then, simply run the following command:

```sh
docker compose up --build
```

The following steps will be executed:

1. An instance of SQL Server will be created on port 1434.
2. An instance of the [Application](http://localhost:7000) will be created on port 7000.
3. An instance of the [Aspire Dashboard](http://localhost:18888) will be created on port 18888.

You can access the [API Documentation](http://localhost:7000/swagger) via the application's `/swagger` endpoint.

To run the application outside the Docker environment, simply navigate to the project's root folder and execute the following command:

```sh
dotnet run --project Blog.Api/
```
---

### Project Structure

#### [Blog.Api](Blog.Api/)

Layer responsible for handling the API endpoints. This layer defines the interfaces for external communication. The RESTful pattern was used to create the endpoints.

#### [Blog.Core](Blog.Core/)

Layer responsible for business logic. It contains the entities and services that handle the application's business rules.

#### [Blog.Data](Blog.Data/)

Layer responsible for data access. The database access is managed using Entity Framework, and the database modeling is done through Migrations (Code First). The purpose of this layer is to map the relational model to the object-oriented model and vice versa.

#### [Blog.Test](Blog.Test/)

Layer responsible for automated tests. The testing library used is XUnit. Within the test project, classes are organized following the folder structure of the other projects. Each test class is placed in the corresponding path of the class being tested.

#### [.github/workflows](./.github/workflows/)

The `.github/workflows` folder contains the pipelines. These pipelines are created using [GitHub Actions](https://github.com/features/actions), and executions for this repository can be checked [here](https://github.com/rafael-pessoni/blog/actions).

---
### Upcoming Implementations

- Implement a caching layer using a NoSQL database.
- Implement more unit tests.
- Implement integration tests.
- Add a pipeline for [code validation](https://github.com/marketplace/actions/official-sonarqube-scan).
- Add authentication using [JWT tokens](https://jwt.io/).
- Add [API versioning](https://restfulapi.net/versioning/).
- And more rsrsrs.

