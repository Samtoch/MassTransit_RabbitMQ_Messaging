This is a .Net 8 Microservices using MassTransit and RabbitMQ for Messaging. The RabbitMQ was configured to run inside docker
It Has two services, SenderAPP and RecieverAPP with a Class library for common models that is referenced in the services.
The rabbit MQ is configured to use either admin or guest user with same name as password in each case.
The RabbitMQ runs on port 15672 as hosted with docker using below command.
docker run -d --name my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management 
