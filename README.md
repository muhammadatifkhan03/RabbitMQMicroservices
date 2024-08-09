**Architecture Details**

I have used the Microservice Architecture with Onion to Implement this Solution.
**Layers**
 * Core Layer
 * Infrastructure Layer
 * DTOs Layer
 * WebAPI Layer

**Core Layer** 

This Layer contains the Domain Core Entities.

**Infrastructure Layer**

This Layer contains the ApplicationDbContext , Interfaces and Services

**DTOs Layer**

This Layer contains the DTOs Configuration and required DTOs to POST , GET data.

**WebAPI Layer **

This Layer contains the Controller and endpoints to handle all the requests.

**Follow these steps to run the Microservices Project**

**Step 01:**

Clone the Project.

**Step 02:**

Add the connection string property according to your database.

**Step 03:**

Run the Migrations to add the required tables.

**Step 04:**

Install the RabbitMQ Docker file
1.docker pull rabbitmq:3-management
2.docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

**Step 05:**

Run Docker compose project to run the microservices.

**Thanks**
