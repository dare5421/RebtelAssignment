# Rebtel Assignment

## Table of Contents
* [Architecture](#architecture)
* [Services](#services)
* [Technologies](#technologies)
* [Microservices Communication](#microservices_communication)
* [Screenshots](#screenshots)

# Architecture <a name="architecture"/>
Microservices - also known as the microservice architecture - is an architectural style that structures an application as a collection of services that are

* Highly maintainable and testable
* Loosely coupled
* Independently deployable
* Organized around business capabilities
* Owned by a small team

The microservice architecture enables the rapid, frequent and reliable delivery of large, complex applications. It also enables an organization to evolve its technology stack. 
This project consists of 2 microservices one for **users** or **borrowers** and the other for **books** and **borrowing records** which in bouth services gRPC framework has been used.

# Services <a name="services"/>
1. **Borrower.API:** This service is responsible for retrieving users data such as Name, Address and so on. It gets bunch of users-ids and send users details back. 
2. **Library.API:** Any data about book and borrowing will be accessed through this service. It is responsible for most of the queries in the assignment.

# Technologies <a name="technologies"/>
The following technologies and framework has been used:
* ASP.Net Core 6.0
* Microsoft SQL Server
* Entityframework.Core 6.0
* gRPC framework
* JWT access Token

# Microservices Communication <a name="microservices_communication"/>
RESTful services can be quite bulky, inefficient, and limiting for lots of use cases. The bulkiness of RESTful services is because of the fact that most implementation relies on JSON, a text-based encoding format. The JSON format uses lots of space compared to the binary format. 

The gRPC framework is based on binary encoding format protocol buffer and implemented on top of HTTP/2. It’s strongly typed, polyglot, and provides both client and server-side streaming. 

The gRPC is much faster compared to traditional JSON-based REST APIs.

One of the possible gRPC based architectures can be – to have API Gateway/BFF in front of the microservices and make all internal communication using gRPC.

A gRPC application consists of three important components:
* Protocol Buffers: it defines messages and services exposed by the server application. gRPC services send and receive data as Protocol Buffer (Protobuf) messages.
* Server: the server application implements and exposes RPC services.
* Client: the client application consumes RPC services exposed by the server. 

# Screenshots <a name="screenshots"/>
![screenshot1](/Screenshots/1.png)
![screenshot1](./Screenshots/2.png)
![screenshot1](./Screenshots/3.png)
![screenshot1](./Screenshots/4.png)
