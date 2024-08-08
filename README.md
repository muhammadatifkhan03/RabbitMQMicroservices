Follow these steps to run the Microservices Project

Step 01:
Clone the Project.

Step 02:
Add the connection string property according to your database.

Step 03:
Run the Migrations to add the required tables.

Step 04:
Install the RabbitMQ Docker file
1.docker pull rabbitmq:3-management
2.docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

Step 05:
Run Docker compose project to run the microservices.

Thanks
